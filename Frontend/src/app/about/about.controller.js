export class AboutController {
    constructor($http,$log) {
        'ngInject';

        // Simple GET request example:
        $http({
            method: 'GET',
            url: 'http://localhost:59649/api/address'
        }).then(function successCallback(response) {
            $log.log(response);
            
            // this callback will be called asynchronously
            // when the response is available
        }, function errorCallback() {
            // called asynchronously if an error occurs
            // or server returns response with an error status.
        });

    }


}
