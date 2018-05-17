export class AddressCreateController {
  constructor($scope, $http, $log, $location, $stateParams) {
    'ngInject';

    $log.log($stateParams);
    this.createAddress($scope, $http, $location, $log, $stateParams);

    $scope.addressTypes = [
      { number: 0, type: "Type1" },
      { number: 1, type: "Type2" },
      { number: 2, type: "Type3" }
    ];
  }

  createAddress($scope, $http, $location, $log, $stateParams) {
    $scope.createAddress = function () {
      if ($scope.addressCreateForm.$valid) {
        var req = {
          method: 'POST',
          url: 'http://localhost:59649/api/contact/AddAddress',
          headers: {
            'Content-Type': 'application/json'
          },
          data: {
            Line1: $scope.Line1,
            Line2: $scope.Line2,
            Line3: $scope.Line3,
            City: $scope.City,
            Country: $scope.Country,
            PostCode: $scope.PostCode,
            AddressType: $scope.AddressType,
            ContactId: $stateParams.contactId
          }
        };
        $http(req).then(function () {
          $location.path('/contactEdit/' + $stateParams.contactId);
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