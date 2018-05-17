export function routerConfig ($stateProvider, $urlRouterProvider) {
  'ngInject';
  $stateProvider
    .state('home', {
      url: '/',
      templateUrl: 'app/main/main.html',
      controller: 'MainController',
      controllerAs: 'main'
    })
    .state('contactList', {
      url: '/contactList',
      templateUrl: 'app/contactList/contactList.html',
      controller: 'ContactListController',
      controllerAs: 'contactList'
    })
    .state('contactCreate', {
      url: '/contactCreate',
      templateUrl: 'app/contactCreate/contactCreate.html',
      controller: 'ContactCreateController',
      controllerAs: 'contactCreate'
    })
    .state('contactEdit', {
      url: '/contactEdit/:id',
      templateUrl: 'app/contactEdit/contactEdit.html',
      controller: 'ContactEditController',
      controllerAs: 'contactEdit'
    })
    .state('addressEdit', {
      url: '/addressEdit/:id',
      templateUrl: 'app/addressEdit/addressEdit.html',
      controller: 'AddressEditController',
      controllerAs: 'addressEdit'
    })
    .state('addressCreate', {
      url: '/contactEdit/addressCreate/:contactId',
      templateUrl: 'app/addressCreate/addressCreate.html',
      controller: 'AddressCreateController',
      controllerAs: 'addressCreate'
    })
    .state('contactDetails', {
      url: '/contactDetails/:id',
      templateUrl: 'app/contactDetails/contactDetails.html',
      controller: 'ContactDetailsController',
      controllerAs: 'contactDetails'
    })
    ;

  $urlRouterProvider.otherwise('/');
}
