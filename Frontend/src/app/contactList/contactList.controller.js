export class ContactListController {
  constructor($http, $scope, $log, $location) {
    'ngInject';

    this.getContacts($http, $scope, $log);

    $scope.createNewContact = function () {
      $log.log('createNewContact click');
    }

    $scope.editContact = function () {
      $log.log('editContact click');
      $location.path('/contactEdit/' + 1);
    }

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
