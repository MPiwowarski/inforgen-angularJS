export function routerConfig ($stateProvider, $urlRouterProvider) {
  'ngInject';
  $stateProvider
    .state('home', {
      url: '/',
      templateUrl: 'app/main/main.html',
      controller: 'MainController',
      controllerAs: 'main'
    })
    .state('about', {
      url: '/about',
      templateUrl: 'app/about/about.html',
      controller: 'AboutController',
      controllerAs: 'about'
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
    
    ;

  $urlRouterProvider.otherwise('/');
}
