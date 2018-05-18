export class ContactListController {
  constructor($http, $scope, $location, $state, configurationService) {
    'ngInject';

    configurationService.configurationService()
    .init()
    .then(config => {
      console.log(config.appUrl);
    })
    .catch(err => {
      console.log('fail'+ err);
    })

    this.getContacts($http, $scope);
    this.createNewContact($scope, $location);
    this.editContact($scope, $location);
    this.deleteContact($http, $scope, $state);
    this.contactDetails($scope, $location);
  }

  editContact($scope, $location) {
    $scope.editContact = function (id) {
      $location.path('/contactEdit/' + id);
    };
  }

  contactDetails($scope, $location) {
    $scope.contactDetails = function (id) {
      $location.path('/contactDetails/' + id);
    };
  }

  createNewContact($scope, $location) {
    $scope.createNewContact = function () {
      $location.path('/contactCreate');
    };
  }

  deleteContact($http, $scope, $state) {
    $scope.deleteContact = function (id) {
      var req = {
        method: 'POST',
        url: 'http://localhost:59649/api/contact/delete',
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

  getContacts($http, $scope) {
    $http({
      method: 'GET',
      url: 'http://localhost:59649/api/contact'
    }).then(function successCallback(response) {
      $scope.contactList = response.data;
    }, function errorCallback() {
    });
  }


}
