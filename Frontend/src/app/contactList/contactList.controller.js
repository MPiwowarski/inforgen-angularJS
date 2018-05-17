export class ContactListController {
  constructor($http, $scope, $log, $location, $state) {
    'ngInject';

    this.getContacts($http, $scope, $log);
    this.createNewContact($scope, $location);
    this.editContact($scope, $location);
    this.deleteContact($http, $scope, $log, $state);
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

  deleteContact($http, $scope, $log,$state) {
    $scope.deleteContact = function (id) {
      var req = {
        method: 'POST',
        url: 'http://localhost:59649/api/contact/delete',
        headers: {
          'Content-Type': 'application/json'
        },
        data:id
      }
      
      $http(req).then(function () {
        $state.reload();
        //throw popup window
      }, function () {

      });
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
