import { Component } from '@angular/core';

import { IdentityService } from 'src/app/services/identity.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent {
  constructor(public identityService: IdentityService) { }
}
