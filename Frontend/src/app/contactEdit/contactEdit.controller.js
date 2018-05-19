export class ContactEditController {
    constructor($http, $scope, $log, $stateParams, $location,$state, configurationService) {
        'ngInject';

        configurationService.configurationService()
        .init()
        .then(config => {
            var appUrl = config.appUrl;
            this.getContactData($http, $scope, $log, $stateParams.id, appUrl);
            this.editContact($scope, $http, $location, $log, appUrl);
            this.editAddress($scope, $location);
            this.addAddress($scope, $location, $state, $stateParams);
            this.deleteAddress($http, $scope, $log, $state, appUrl);
        })
        .catch(err => {
            $log.log('fail'+ err);
        })

    }

    getContactData($http, $scope, $log, id, appUrl) {
        $http({
            method: 'GET',
            url: appUrl + '/api/contact/' + id
        }).then(function successCallback(response) {

            $scope.Id = response.data.Id;
            $scope.Title = response.data.Title;
            $scope.FirstName = response.data.FirstName;
            $scope.LastName = response.data.LastName;
            $scope.Email = response.data.Email;
            $scope.Addresses = response.data.Addresses

        }, function errorCallback() {
        });
    }

    editContact($scope, $http, $location, $log, appUrl) {
        $scope.editContact = function () {
            if ($scope.contactEditForm.$valid) {
                var req = {
                    method: 'PATCH',
                    url: appUrl + '/api/contact/edit',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    data: {
                        Id: $scope.Id,
                        Title: $scope.Title,
                        FirstName: $scope.FirstName,
                        LastName: $scope.LastName,
                        Email: $scope.Email
                    }
                };
                $http(req).then(function () {
                    $location.path('/contactList');
                }, function () {
                });
            }
            else {
                $log.log('invalid form');
                //throw popup
            }
        };
    }

    editAddress($scope, $location) {
        $scope.editContact = function (id) {
            $location.path('/addressEdit/' + id);
        };
    }

    addAddress($scope, $location, $state, $stateParams) {
        $scope.addAddress = function () {
            $location.path('/contactEdit/addressCreate/' + $stateParams.id);
        };
    }

    deleteAddress($http, $scope, $log, $state, appUrl) {
        $scope.deleteAddress = function (id) {
            var req = {
                method: 'POST',
                url: appUrl + '/api/address/delete',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: id
            }

            $http(req).then(function () {
                $state.reload();
                //throw popup window "Contact has been deleted successfully."
            }, function () {

            });
        };
    }
}  