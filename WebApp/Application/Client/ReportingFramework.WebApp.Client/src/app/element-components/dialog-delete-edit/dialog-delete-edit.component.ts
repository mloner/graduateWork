import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {ApiUrl} from '../../app.module';

@Component({
  selector: 'app-dialog-delete-edit',
  templateUrl: './dialog-delete-edit.component.html',
  styleUrls: ['./dialog-delete-edit.component.css']
})
export class DialogDeleteEditComponent implements OnInit {

  public localData: any;
  public resultData: any;
  response: any;
  loading = false;
  path = '';
  constructor(private http: HttpClient,
              public dialogRef: MatDialogRef<DialogDeleteEditComponent>,
              @Inject(MAT_DIALOG_DATA) public data: any, @Inject(ApiUrl) private apiUrl: string) {
    this.localData = {...data.data};
  }

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  onNoClick(): void {
    this.dialogRef.close('false');
  }

  onSendClick(): void {
    if (this.localData !== undefined || this.localData != null){
      if (this.data.type === 5)
      {
        this.path = '/edit/delete';
      }
      if (this.data.type === 6)
      {
        this.path = '/edit-invoice/delete';
      }
      const item = this.localData;
      this.loading = true;
      this.http.post<any>(this.apiUrl + this.path,  item).subscribe(data => {
        if (data.result === true) {

          this.resultData = data.input;
          this.loading = false;
          this.dialogRef.close(this.resultData);
        } else {
          this.loading = false;
          this.dialogRef.close(this.resultData);
          alert('Something went wrong: \n\r' + data.response);
        }
      }, error => {
        if (error.result === true) {
          console.log(error.response);
          this.loading = false;
          this.dialogRef.close(this.localData);
        } else {
          this.loading = false;
          this.dialogRef.close(this.localData);
          alert(error.response);
        }
      });
    }else
    {
      alert('Empty data');
    }
  }

}
