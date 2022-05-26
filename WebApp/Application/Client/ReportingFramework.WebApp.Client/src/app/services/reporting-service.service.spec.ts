import { TestBed } from '@angular/core/testing';

import { ReportTemplateEditorService } from './reporting-service.service';

describe('ReportingServiceService', () => {
  let service: ReportTemplateEditorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReportTemplateEditorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
