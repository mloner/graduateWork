import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/_shared/services/auth.service';

@Component({
  selector: 'app-silent-renew-callback',
  templateUrl: './silent-renew-callback.component.html',
  styleUrls: ['./silent-renew-callback.component.scss'],
})
export class SilentRenewCallbackComponent implements OnInit {
  constructor(private route: ActivatedRoute, private router: Router, private authService: AuthService) {}

  async ngOnInit() {
    if (this.route.snapshot.fragment){
      if (this.route.snapshot.fragment?.indexOf('error') >= 0) {
        console.error('Error while renewing Identity Token', console.info(this.route));
        return;
      }
    }

    await this.authService.completeSilentRenewal();
  }
}
