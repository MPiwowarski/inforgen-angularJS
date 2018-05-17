export class ContactListController {
  constructor($http, $scope, $log, $location) {
    'ngInject';

    this.getContacts($http, $scope, $log);
    this.createNewContact($scope, $location);
    this.editContact($scope, $location);
  }

  editContact($scope, $location) {
    $scope.editContact = function (id) {
      $location.path('/contactEdit/' + id);
    };
  }

  createNewContact($scope, $location) {
    $scope.createNewContact = function () {
      $location.path('/contactCreate');
    };
  }

  getContacts($http, $scope, $log) {
    $http({
      method: 'GET',
      url: 'http://localhost:59649/api/contact'
    }).then(function successCallback(response) {
      $scope.contactList = response.data;
    }, function errorCallback() {
    });
  }


}
