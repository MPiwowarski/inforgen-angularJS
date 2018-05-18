export class ContactDetailsController {
    constructor($http, $scope, $log, $stateParams, configurationService) {
        'ngInject';

        configurationService.configurationService()
        .init()
        .then(config => {
            var appUrl = config.appUrl;
            this.getContactData($http, $scope, $log, $stateParams.id, appUrl);
        })
        .catch(err => {
            $log.log('fail'+ err);
        })
    }

    getContactData($http, $scope, $log, id, appUrl) {
        $http({
            method: 'GET',
            url: appUrl + '/api/contact/' + id
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