export class ContactEditController {
    constructor($http, $scope, $log, $stateParams, $location,$state) {
        'ngInject';

        this.getContactData($http, $scope, $log, $stateParams.id);
        this.editContact($scope, $http, $location, $log);

        this.editAddress($scope, $location);
        this.addAddress($scope, $location, $state, $stateParams);
        this.deleteAddress($http, $scope, $log, $state);
    }

    getContactData($http, $scope, $log, id) {
        $http({
            method: 'GET',
            url: 'http://localhost:59649/api/contact/' + id
        }).then(function successCallback(response) {

            $scope.Id = response.data.Id;
            $scope.Title = response.data.Title;
            $scope.FirstName = response.data.FirstName;
            $scope.LastName = response.data.LastName;
            $scope.Email = response.data.Email;
            $scope.Addresses = response.data.Addresses

            $log.log(response.data);

        }, function errorCallback() {
        });
    }

    editContact($scope, $http, $location, $log) {
        $scope.editContact = function () {
            if ($scope.contactEditForm.$valid) {
                var req = {
                    method: 'PATCH',
                    url: 'http://localhost:59649/api/contact/edit',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    data: {
                        Id: $scope.Id,
                        Title: $scope.Title,
                        FirstName: $scope.FirstName,
                        LastName: $scope.LastName,
                        Email: $scope.Email,
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

    deleteAddress($http, $scope, $log, $state) {
        $scope.deleteAddress = function (id) {
            var req = {
                method: 'POST',
                url: 'http://localhost:59649/api/address/delete',
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