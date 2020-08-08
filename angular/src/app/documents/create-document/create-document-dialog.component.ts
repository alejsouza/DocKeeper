import {  Component, Injector, OnInit, EventEmitter, Output} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {  DocumentsServiceProxy,  CreateDocumentDto} from '@shared/service-proxies/service-proxies';
import { AbpValidationError } from '@shared/components/validation/abp-validation.api';

@Component({
  templateUrl: './create-document-dialog.component.html'
})
export class CreateDocumentDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  document = new CreateDocumentDto();
  checkedRolesMap: { [key: string]: boolean } = {};
  defaultRoleCheckedStatus = false;
  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _documentService: DocumentsServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }

  save(): void {
    this.saving = true;

    this._documentService
      .create(this.document)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
}
