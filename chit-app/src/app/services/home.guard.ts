import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { Router } from '@angular/router';
import { NbAuthService } from '@nebular/auth';
import { tap } from 'rxjs/operators';

@Injectable()
export class HomeGuard implements CanActivate {

    canActivate() {
        return this.authService.isAuthenticated()
            .pipe(
                tap(authenticated => {
                    if (!authenticated) {
                        this.router.navigate(['/home']);
                    }
                    else {
                        this.router.navigate(['/app']);
                    }
                }),
            );
    }
    //Constructor 
    constructor(private router: Router, private authService: NbAuthService) { }
}