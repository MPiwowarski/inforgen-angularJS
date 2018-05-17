export class ContactDetailsController {
    constructor($http, $scope, $log, $stateParams, $location, $state) {
        'ngInject';

        this.getContactData($http, $scope, $log, $stateParams.id);
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

        }, function errorCallback() {
        });
    }
}