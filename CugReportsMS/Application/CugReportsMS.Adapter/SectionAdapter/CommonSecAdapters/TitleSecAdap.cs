using System;
using ReportingFramework.DataModels.CustomerData;
using SectionModels;
using SectionModels.Pdf.SectionModels;

namespace ReportingFramework.SectionAdapter.CommonSecAdapters
{
    public abstract class TitleSecAdap : PdfSectionAdapter
    {
        protected TitleSectionModel SectionModel;

        public TitleSecAdap()
        {
            SectionModel = new TitleSectionModel();
        }

        public CustomerData CustomerData;
        public override void LoadData()
        {
            base.LoadData();
            CustomerData = (CustomerData)CommonData["CustomerData"];
        }

        public override SectionModel CreateSectionModel()
        {
            SectionModel.ReportDate = DateTime.Now;
            SectionModel.CustomerName = CustomerData.CustomerMetadata_.Task.Cug.Building.Customer;
            
            
            return SectionModel;
        }
    }
}