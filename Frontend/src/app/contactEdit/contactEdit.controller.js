export class ContactEditController {
    constructor($http, $scope, $log, $stateParams) {
        'ngInject';

        $log.log($stateParams.id);
        this.getContactData($http, $scope, $log, $stateParams.id);       
        
    }

    getContactData($http, $scope, $log, id) {
        $http({
            method: 'GET',
            url: 'http://localhost:59649/api/contact/' + id
        }).then(function successCallback(response) {
            $scope.contactData = response.data;
            $log.log(response.data);

        }, function errorCallback() {
        });
    }
}  