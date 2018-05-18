/* global malarkey:false, moment:false */

import { config } from './index.config';
import { routerConfig } from './index.route';
import { runBlock } from './index.run';
import { MainController } from './main/main.controller';
import { GithubContributorService } from '../app/components/githubContributor/githubContributor.service';
import { WebDevTecService } from '../app/components/webDevTec/webDevTec.service';
import { NavbarDirective } from '../app/components/navbar/navbar.directive';
import { MalarkeyDirective } from '../app/components/malarkey/malarkey.directive';
import { ContactListController } from './contactList/contactList.controller';
import { ContactCreateController } from './contactCreate/contactCreate.controller';
import { ContactEditController } from './contactEdit/contactEdit.controller';
import { AddressCreateController } from './addressCreate/addressCreate.controller';
import { AddressEditController } from './addressEdit/addressEdit.controller';
import { ContactDetailsController } from './contactDetails/contactDetails.controller';
import { ConfigurationService } from './configurationService';

angular.module('gulpAngular', ['ngAnimate', 'ngCookies', 'ngTouch', 'ngSanitize', 'ngMessages', 'ngAria', 'ngResource', 'ui.router', 'ui.bootstrap', 'toastr'])
  .constant('malarkey', malarkey)
  .constant('moment', moment)
  .config(config)
  .config(routerConfig)
  .run(runBlock)
  .service('githubContributor', GithubContributorService)
  .service('webDevTec', WebDevTecService)
  .service('configurationService', ConfigurationService)
  .controller('MainController', MainController)
  .controller('ContactListController', ContactListController)
  .controller('ContactCreateController', ContactCreateController)
  .controller('ContactEditController', ContactEditController)
  .controller('AddressCreateController', AddressCreateController)
  .controller('AddressEditController', AddressEditController)
  .controller('ContactDetailsController', ContactDetailsController)
  .directive('acmeNavbar', NavbarDirective)
  .directive('acmeMalarkey', MalarkeyDirective);
