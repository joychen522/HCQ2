//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HCQ2_Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SM_SetItems
    {
        public string SetID { get; set; }
        public string ItemID { get; set; }
        public Nullable<int> ItemOrder { get; set; }
        public int Selected { get; set; }
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public int Itemlen { get; set; }
        public int Itemdecimal { get; set; }
        public string CodeID { get; set; }
        public int IsMustInput { get; set; }
        public int IsMustCreate { get; set; }
        public string DispFormat { get; set; }
        public Nullable<int> DispWidth { get; set; }
        public string Descript { get; set; }
        public int IsSystem { get; set; }
        public int IsPrimaryKey { get; set; }
        public int IsHide { get; set; }
        public int IsReadonly { get; set; }
        public int IsNotNull { get; set; }
        public int IsForeignKey { get; set; }
        public string ForeignTableID { get; set; }
        public string ForeignFieldID { get; set; }
        public int IsDeleteCascade { get; set; }
        public int IsUpdateCascade { get; set; }
        public string ItemDefaultValue { get; set; }
        public string DrawControl { get; set; }
        public string DrawControlConfig { get; set; }
        public string InputControl { get; set; }
        public string InputControlConfig { get; set; }
        public string CheckControl { get; set; }
        public string CheckControlConfig { get; set; }
        public string FormGroupName { get; set; }
        public Nullable<int> FormLabelWidth { get; set; }
        public Nullable<int> FormControlWidth { get; set; }
        public Nullable<int> FormNewLine { get; set; }
        public string DrawStyleControl { get; set; }
        public string DrawStyleControlConfig { get; set; }
        public int IsVirtualField { get; set; }
        public string ItemAlign { get; set; }
        public int IsLoadBlobName { get; set; }
        public string VirtualFieldExpr { get; set; }
        public int CodeMultiSelect { get; set; }
    }
}
