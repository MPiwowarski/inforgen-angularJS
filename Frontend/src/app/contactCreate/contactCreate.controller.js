export class ContactCreateController {
  constructor($scope, $http, $log, $location) {
    'ngInject';

    this.createContact($scope, $http, $location, $log);
  }

  createContact($scope, $http, $location, $log) {
    $scope.createContact = function () {
      if ($scope.contactCreateForm.$valid) {
        var req = {
          method: 'POST',
          url: 'http://localhost:59649/api/contact',
          headers: {
            'Content-Type': 'application/json'
          },
          data: {
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
