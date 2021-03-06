import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { IdentityService } from 'src/app/services/identity.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent {
  constructor(public identityService: IdentityService,
    private router: Router) { }

  public newQuiz() {
    this.redirectTo('/quiz');
  }

  private redirectTo(uri:string) {
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
      this.router.navigate([ uri ]);
    });
  }

  public logout() {
    this.identityService.logout().subscribe(_ => {
      localStorage.clear();
      this.router.navigate([ '/login' ]);
    });
  }
}
