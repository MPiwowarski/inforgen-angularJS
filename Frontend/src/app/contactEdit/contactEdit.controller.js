export class ContactEditController {
    constructor($http, $scope, $log, $stateParams, $location) {
        'ngInject';

        $log.log($stateParams.id);
        this.getContactData($http, $scope, $log, $stateParams.id);
        this.editContact($scope, $http, $location, $log)

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


}  