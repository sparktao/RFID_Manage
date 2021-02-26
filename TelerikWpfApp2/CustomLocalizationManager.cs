using System;
using System.Collections.Generic;
using System.Text;
using Telerik.Windows.Controls;

namespace Org.Tao.QuickStart
{
    public class CustomLocalizationManager : LocalizationManager
    {
        private IDictionary<string, string> dictionary;

        public CustomLocalizationManager()
        {
            this.dictionary = new Dictionary<string, string>();

            this.dictionary["Pivot_Row"] = "行";
            this.dictionary["Pivot_Column"] = "列";
            this.dictionary["Pivot_Value"] = "值: {0}";

            this.dictionary["PivotFieldList_ShowItemsForWhichTheLabel"] = "Show items for which the label";
            this.dictionary["PivotFieldList_And"] = "和";
            this.dictionary["PivotFieldList_AscendingBy"] = "升序排序 (A 到 Z):";
            this.dictionary["PivotFieldList_BaseField"] = "基本字段:";
            this.dictionary["PivotFieldList_BaseItem"] = "基本项:";
            this.dictionary["PivotFieldList_By"] = "by:";
            this.dictionary["PivotFieldList_ChooseAggregateFunction"] = "选择要用于汇总所选字段数据的计算类型.";
            this.dictionary["PivotFieldList_ChooseFieldsToAddToReport"] = "选择要添加到报表的字段:";
            this.dictionary["PivotFieldList_ColumnLabels"] = "列标注";
            this.dictionary["PivotFieldList_DeferLayoutUpdate"] = "延迟布局更新";
            this.dictionary["PivotFieldList_DescendingBy"] = "降序排序 (Z到A):";
            this.dictionary["PivotFieldList_DragFieldsBetweenAreasBelow"] = "在下方区域之间拖动字段:";
            this.dictionary["PivotFieldList_Format"] = "格式:";
            this.dictionary["PivotFieldList_GeneralFormat"] = "通用格式";
            this.dictionary["PivotFieldList_IgnoreCase"] = "忽略大小写";
            this.dictionary["PivotFieldList_PleaseRefreshThePivot"] = "请刷新报表.";
            this.dictionary["PivotFieldList_Refresh"] = "刷新";
            this.dictionary["PivotFieldList_ReportFilter"] = "报表筛选器";
            this.dictionary["PivotFieldList_RowLabels"] = "行标签";
            this.dictionary["PivotFieldList_SelectItem"] = "选择项";
            this.dictionary["PivotFieldList_Show"] = "显示";
            this.dictionary["PivotFieldList_ShowItemsForWhich"] = "PivotFieldList_ShowItemsForWhich";
            this.dictionary["PivotFieldList_ShowValuesAs"] = "Show Values As";
            this.dictionary["PivotFieldList_SortOptions"] = "排序选项";
            this.dictionary["PivotFieldList_StringFormatDescription"] = "格式应标识值的测量类型。格式将用于一般计算，如总和，平均值，最小值，最大值和其他.";
            this.dictionary["PivotFieldList_SummarizeValuesBy"] = "按汇总值";
            this.dictionary["PivotFieldList_TheActionRequiresMoreRecentInformation"] = "The action requires more recent information.";
            this.dictionary["PivotFieldList_Update"] = "Update";
            this.dictionary["PivotFiledList_Values"] = "值";

            this.dictionary["Ok"] = "确定";
            this.dictionary["Cancel"] = "取消";

            this.dictionary["PivotFieldList_SetSumAggregate"] = "汇总";
            this.dictionary["PivotFieldList_SetCountAggregate"] = "计数";
            this.dictionary["PivotFieldList_SetAverageAggregate"] = "平均";
            this.dictionary["PivotFieldList_SetIndexTotalFormat"] = "Index";
            this.dictionary["PivotFieldList_SetPercentOfGrandTotalFormat"] = "% of Grand Total";
            this.dictionary["PivotFieldList_SortAtoZ"] = "从A到Z排序";
            this.dictionary["PivotFieldList_SortZtoA"] = "从Z到A排序";
            this.dictionary["PivotFieldList_MoreSortingOptions"] = "更多排序选项...";
            this.dictionary["PivotFieldList_LabelFilter"] = "Label Filter";
            this.dictionary["PivotFieldList_ValueFilter"] = "Value Filter";
            this.dictionary["PivotFieldList_TopTenFilter"] = "Top 10 Filter";
            this.dictionary["PivotFieldList_ClearFilter"] = "Clear Filter";
            this.dictionary["PivotFieldList_ShowEmptyGroups"] = "Show Empty Groups";
            this.dictionary["PivotFieldList_ShowSubTotals "] = "Show Subtotals";
            this.dictionary["PivotFieldList_SelectItems"] = "Select Items";
            this.dictionary["PivotFieldList_MoreAggregateOptions"] = "More Aggregate Options...";
            this.dictionary["PivotFieldList_MoreCalculationOptions"] = "More Calculation Options...";
            this.dictionary["PivotFieldList_ClearCalculations"] = "Clear Calculations";
            this.dictionary["PivotFieldList_NumberFormat"] = "Number Format";

            this.dictionary["Pivot_GrandTotal"] = "总计";
            this.dictionary["Pivot_Values"] = "Values";
            this.dictionary["Pivot_Error"] = "Error";
            this.dictionary["Pivot_TotalP0"] = "总计 {0}";
            this.dictionary["Pivot_P0Total"] = "{0} 总计";

            this.dictionary["Pivot_GroupP0AggregateP1"] = "{0} {1}";

            this.dictionary["Pivot_AggregateP0ofP1"] = "{0} of {1}";

            this.dictionary["Pivot_AggregateSum"] = "汇总";
            this.dictionary["Pivot_AggregateCount"] = "总计";
            this.dictionary["Pivot_AggregateAverage"] = "平均";
            this.dictionary["Pivot_AggregateMin"] = "最小";
            this.dictionary["Pivot_AggregateMax"] = "最大";
            this.dictionary["Pivot_AggregateProduct"] = "Product";
            this.dictionary["Pivot_AggregateVar"] = "Var";
            this.dictionary["Pivot_AggregateVarP"] = "VarP";
            this.dictionary["Pivot_AggregateStdDev"] = "StdDev";
            this.dictionary["Pivot_AggregateStdDevP"] = "StdDevP";
            this.dictionary["Pivot_HourGroup"] = "{0} - 时";
            this.dictionary["Pivot_MinuteGroup"] = "{0} - 分";
            this.dictionary["Pivot_MonthGroup"] = "{0} - 月";
            this.dictionary["Pivot_QuarterGroup"] = "{0} - 季";
            this.dictionary["Pivot_SecondGroup"] = "{0} - 秒";
            this.dictionary["Pivot_WeekGroup"] = "{0} - 周";
            this.dictionary["Pivot_YearGroup"] = "{0} - 年";
            this.dictionary["Pivot_DayGroup"] = "{0} - 天";
            this.dictionary["PivotFieldList_PercentOfColumnTotal"] = "% of Column Total";
            this.dictionary["PivotFieldList_PercentOfRowTotal"] = "% of Row Total";
            this.dictionary["PivotFieldList_PercentOfGrandTotal"] = "% of Grand Total";
            this.dictionary["PivotFieldList_NoCalculation"] = "No Calculation";
            this.dictionary["PivotFieldList_DifferenceFrom"] = "Difference From";
            this.dictionary["PivotFieldList_PercentDifferenceFrom"] = "% Difference From";
            this.dictionary["PivotFieldList_PercentOf"] = "% Of";
            this.dictionary["PivotFieldList_RankSmallestToLargest"] = "Rank Smallest to Largest";
            this.dictionary["PivotFieldList_RankLargestToSmallest"] = "Rank Largest to Smallest";
            this.dictionary["PivotFieldList_PercentRunningTotalIn"] = "% Running Total In";
            this.dictionary["PivotFieldList_RunningTotalIn"] = "Running Total In";
            this.dictionary["PivotFieldList_Index"] = "Index";

            this.dictionary["PivotFieldList_RelativeToPrevious"] = "(previous)";
            this.dictionary["PivotFieldList_RelativeToNext"] = "(next)";

            this.dictionary["PivotFieldList_ConditionEquals"] = "equals";
            this.dictionary["PivotFieldList_DoesNotEqual"] = "does not equal";
            this.dictionary["PivotFieldList_IsGreaterThan"] = "is greater than";
            this.dictionary["PivotFieldList_IsGreaterThanOrEqualTo"] = "is greater than or equal to";
            this.dictionary["PivotFieldList_IsLessThan"] = "is less than";
            this.dictionary["PivotFieldList_IsLessThanOrEqualTo"] = "is less than or equal to";
            this.dictionary["PivotFieldList_BeginsWith"] = "begins with";
            this.dictionary["PivotFieldList_DoesNotBeginWith"] = "does not begin with";
            this.dictionary["PivotFieldList_EndsWith"] = "ends with";
            this.dictionary["PivotFieldList_DoesNotEndWith"] = "does not end with";
            this.dictionary["PivotFieldList_Contains"] = "contains";
            this.dictionary["PivotFieldList_DoesNotContains"] = "does not contain";
            this.dictionary["PivotFieldList_IsBetween"] = "is between";
            this.dictionary["PivotFieldList_IsNotBetween"] = "is not between";

            this.dictionary["PivotFieldList_SelectAll"] = "(选择所有)";

            this.dictionary["PivotFieldList_Top10Items"] = "Items";
            this.dictionary["PivotFieldList_Top10Percent"] = "百分比";
            this.dictionary["PivotFieldList_Top10Sum"] = "总计";

            this.dictionary["PivotFieldList_TopItems"] = "顶部";
            this.dictionary["PivotFieldList_BottomItems"] = "底部";

            this.dictionary["PivotFieldList_FilterItemsP0"] = "Fitler Items ({0})";
            this.dictionary["PivotFieldList_LabelFilterP0"] = "Label Filter ({0})";
            this.dictionary["PivotFieldList_SortP0"] = "Sort ({0})";
            this.dictionary["PivotFieldList_FormatCellsP0"] = "Format Cells ({0})";
            this.dictionary["PivotFieldList_ValueSummarizationP0"] = "Value Summarization ({0})";
            this.dictionary["PivotFieldList_Top10FilterP0"] = "Top10 Filter ({0})";
            this.dictionary["PivotFieldList_ShowValuesAsP0"] = "Show Values As ({0})";
            this.dictionary["PivotFieldList_ValueFilterP0"] = "值过滤器 ({0})";
            this.dictionary["PivotFieldList_Null"] = "(null)";

            this.dictionary["Pivot_CalculatedFields"] = "计算字段";
            this.dictionary["PivotFieldList_ItemFilterConditionCaption"] = "Show items with value that";
            this.dictionary["PivotFieldList_None"] = "数据源顺序";
            this.dictionary["PivotFieldList_Sort_BySortKeys"] = "by Sort Keys";
        }

        public override string GetStringOverride(string key)
        {
            string localized;

            if (this.dictionary.TryGetValue(key, out localized))
            {
                return localized;
            }
            else
            {
                return base.GetStringOverride(key);
            }
        }
    }
}
