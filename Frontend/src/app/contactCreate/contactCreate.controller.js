export class ContactCreateController {
  constructor($scope, $http, $log, $location, configurationService) {
    'ngInject';

    configurationService.configurationService()
        .init()
        .then(config => {
            var appUrl = config.appUrl;
            this.createContact($scope, $http, $location, $log, appUrl);
        })
        .catch(err => {
            $log.log('fail'+ err);
        })
  }

  createContact($scope, $http, $location, $log, appUrl) {
    $scope.createContact = function () {
      if ($scope.contactCreateForm.$valid) {
        var req = {
          method: 'POST',
          url: appUrl + '/api/contact',
          headers: {
            'Content-Type': 'application/json'
          },
          data: {
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

}
