export class ConfigurationService {
    constructor() {

    }

    configurationService() {
        var configurationObject = {};
        function init() {
            const configRequest = new Request('config.json');
            
            return fetch(configRequest)
                    .then(response => {
                        return response.json()
                    })
        }
        function getConfigByKey(key) {
            return configurationObject[key];
        }
        return {
            init: init,
            getConfigByKey: getConfigByKey
        };
    }
}
