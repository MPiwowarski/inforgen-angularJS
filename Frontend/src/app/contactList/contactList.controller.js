export class ContactListController {
  constructor($http, $scope, $location, $state, configurationService,$log) {
    'ngInject';

    configurationService.configurationService()
    .init()
    .then(config => {
      var appUrl = config.appUrl;
      this.getContacts($http, $scope, appUrl);
      this.createNewContact($scope, $location);
      this.editContact($scope, $location);
      this.deleteContact($http, $scope, $state, appUrl);
      this.contactDetails($scope, $location);
    })
    .catch(err => {
      $log.log('fail'+ err);
    })

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

  deleteContact($http, $scope, $state,appUrl) {
    $scope.deleteContact = function (id) {
      var req = {
        method: 'POST',
        url: appUrl+'/api/contact/delete',
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

  getContacts($http, $scope, appUrl) {
    $http({
      method: 'GET',
      url: appUrl+'/api/contact'
    }).then(function successCallback(response) {
      $scope.contactList = response.data;
    }, function errorCallback() {
    });
  }


}
