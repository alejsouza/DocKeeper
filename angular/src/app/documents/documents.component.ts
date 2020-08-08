import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from 'shared/paged-listing-component-base';
import {
  DocumentsServiceProxy,
  DocumentDto,
  DocumentDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { CreateDocumentDialogComponent } from './create-document/create-document-dialog.component';
import { EditDocumentDialogComponent } from './edit-document/edit-document-dialog.component';

class PagedDocumentsRequestDto extends PagedRequestDto {
  filter: string;
  nameFilter: string;
  locationFilter: string;
  descriptionFilter: string;
  sorting: string;
}

@Component({
  templateUrl: './documents.component.html',
  animations: [appModuleAnimation()]
})
export class DocumentsComponent extends PagedListingComponentBase<DocumentDto> {
  documents: DocumentDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _documentService: DocumentsServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  create(): void {
    this.showCreateOrEditDialog();
  }

  edit(user: DocumentDto): void {
    this.showCreateOrEditDialog(user.id);
  }
  
  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }

  protected list(
    request: PagedDocumentsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
  
    this._documentService
      .getAll(
        request.filter,
        request.nameFilter,
        request.locationFilter,
        request.descriptionFilter,
        request.sorting,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: DocumentDtoPagedResultDto) => {
        this.documents = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected delete(user: DocumentDto): void {
    abp.message.confirm(
      this.l('UserDeleteWarningMessage', user.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._documentService.delete(user.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

  private showCreateOrEditDialog(id?: number): void {
    let createOrEditUserDialog: BsModalRef;
    if (!id) {
      createOrEditUserDialog = this._modalService.show(
        CreateDocumentDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditUserDialog = this._modalService.show(
        EditDocumentDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditUserDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
