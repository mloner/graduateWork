using System;
using SectionModels.Pdf;

namespace ReportingFramework.Structure.SectionHelpers
{
    public static class PdfSectionHelperHelper
    {
        public static PdfSectionHelper GetSectionHelper(int sectionType)
        {
            switch ((PdfSectionEnum)sectionType)
            {
                // case PdfSectionEnum.ExecSum_AlgoComp:
                //     return new ExSumAlgoComparisonJabbaSectionHelper(); 
                // case PdfSectionEnum.Title:
                //     return new TitleBatSimShortDefaultSecHelper();
                // case PdfSectionEnum.PeakShavComp_AlgoComp:
                //     return new PeakShavingComparisonAlgoComparisonJabbaSectionHelper();
                default:
                    throw new Exception();
            }
            // switch (section.Name)
            // {
            //     case PdfSectionNameEnum.ExecSum_AlgoComp_Jabba:
            //         return ExSumAlgoComparisonJabbaSectionHelper.GetSection(section);
            //     case PdfSectionNameEnum.PeakShavingComparison_AlgoComp_Jabba:
            //         return PeakShavingComparisonAlgoComparisonJabbaSectionHelper.GetSection(section);
            //     case PdfSectionNameEnum.Conclusion_AlgoComp_Jabba:
            //         return ConclusionAlgoComparisonJabbaHelper.GetSection(section);
            //     case PdfSectionNameEnum.Disclaimer_AlgoComp_Jabba:
            //         return DisclaimerAlgoComparisonJabbaHelper.GetSection(section);
            //     
            //     case PdfSectionNameEnum.Title_BatSim_Bliq:
            //         return TitleBatSimBliqSecHelper.GetSection(section);
            //     case PdfSectionNameEnum.ExecSum_BatSimShort_Default_BE:
            //         return ExSumBatSimShortDefaultBESecHelper.GetSection(section);
            //     case PdfSectionNameEnum.ExecSum_BatSimShort_Default_NL:
            //         return ExSumBatSimShortDefaultNLSecHelper.GetSection(section);
            //     case PdfSectionNameEnum.AlgoPerfExplRes_BatSimShort_Default:
            //         return SelfConsPeakShavBatSimShortDefaultSecHelper.GetSection(section);
            //     case PdfSectionNameEnum.CompScen_BatSimShort_Default:
            //         return CompScenBatSimShortDefaultSecHelper.GetSection(section);
            //     //NL
            //     case PdfSectionNameEnum.ExecSum_BatSim_Default_BE:
            //         return ExSumBatSimDefaultBESecHelper.GetSection(section);
            //     case PdfSectionNameEnum.ExecSum_BatSim_Default_NL:
            //         return ExSumBatSimDefaultNLSecHelper.GetSection(section);
            //     case PdfSectionNameEnum.Advice_BatSim_Default_NL:
            //         return AdviceBatSimBliqNLSecHelper.GetSection(section);
            //     case PdfSectionNameEnum.Advice_BatSim_Default_BE:
            //         return AdviceBatSimBliqBESecHelper.GetSection(section);
            //     case PdfSectionNameEnum.CompScen_BatSim_Default:
            //         return CompScenBatSimDefaultNlSecHelper.GetSection(section);
            //     case PdfSectionNameEnum.SimPar_BatSim_Default:
            //         return SimParBatSimDefaultSecHelper.GetSection(section);
            //     case PdfSectionNameEnum.InpDataAnalysis_BatSim_Default:
            //         return InpDataAnalysisBatSimDefaultSecHelper.GetSection(section);
            //     case PdfSectionNameEnum.PerfExplAvgDay_BatSim_Default:
            //         return AlgoExplBatSimDefaultSecHelper.GetSection(section);
            //     case PdfSectionNameEnum.CumCashflow_BatSim_Default:
            //         return CumCashflowBatSimDefaultSecHelper.GetSection(section);
            //     case PdfSectionNameEnum.SenMark_BatSim_Default:
            //         return SenMarkBatSimDefaultSecHelper.GetSection(section);
            //     case PdfSectionNameEnum.SenElectrMark_BatSim_Default:
            //         return SenElectrMarkBatSimDefaultSecHelper.GetSection(section);
            //     case PdfSectionNameEnum.EarnModels_BatSim_Default_NL:
            //         return EarnModelsBatSimDefaultNLSecHelper.GetSection(section);
            //     case PdfSectionNameEnum.EarnModels_BatSim_Default_BE:
            //         return EarnModelsBatSimDefaultBESecHelper.GetSection(section);
            //     case PdfSectionNameEnum.SelfCons_BatSim_Default:
            //         return SelfConsBatSimDefaultSecHelper.GetSection(section);
            //     case PdfSectionNameEnum.PeakShav_BatSim_Default_BE:
            //         return PeakShavBatSimDefaultBESecHelper.GetSection(section);
            //     case PdfSectionNameEnum.PeakShav_BatSim_Default_NL:
            //         return PeakShavBatSimDefaultNLSecHelper.GetSection(section);
            //     case PdfSectionNameEnum.DynTarExpl_BatSim_Default:
            //         return DynTarExplBatSimDefaultSecHelper.GetSection(section);
            //     case PdfSectionNameEnum.NetMet_BatSim_Default:
            //         return NetMetBatSimDefaultSecHelper.GetSection(section);
            //     case PdfSectionNameEnum.Glossary_BatSim_Default:
            //         return GlossaryBatSimDefaultSecHelper.GetSection(section);
            //     case PdfSectionNameEnum.Subsidy_BatSim_Default:
            //         return SubsidyBatSimBliqNLSecHelper.GetSection(section);
            //     case PdfSectionNameEnum.BuySellEn_BatSimShort_Default:
            //         return BuySellEnBatSimShortDefaultSecHelper.GetSection(section);
            //     //HeatSav
            //     case PdfSectionNameEnum.ExecSum_HeatSav_Default:
            //         return ExSumHeatSavSecHelper.GetSection(section);
            //     case PdfSectionNameEnum.PerfExplWeek_BatSim_Default:
            //         return PerfExplBatSimShortDefaultSecHelper.GetSection(section);
            //     
            //     case PdfSectionNameEnum.Title_BatSim_Default:
            //         return TitleBatSimDefaultSecHelper.GetSection(section);
            //     
            //     default:
            //         throw new Exception("PdfSectionHelper");
            // }
        }
    }
}