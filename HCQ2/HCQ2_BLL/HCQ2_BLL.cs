
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCQ2_IBLL;
namespace HCQ2_BLL
{
	public partial class A01BLL : BaseBLL<HCQ2_Model.A01>,IA01BLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IA01DAL;
		}
    }
	public partial class A02BLL : BaseBLL<HCQ2_Model.A02>,IA02BLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IA02DAL;
		}
    }
	public partial class A03BLL : BaseBLL<HCQ2_Model.A03>,IA03BLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IA03DAL;
		}
    }
	public partial class A04BLL : BaseBLL<HCQ2_Model.A04>,IA04BLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IA04DAL;
		}
    }
	public partial class A19BLL : BaseBLL<HCQ2_Model.A19>,IA19BLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IA19DAL;
		}
    }
	public partial class ATTACHJOBBLL : BaseBLL<HCQ2_Model.ATTACHJOB>,IATTACHJOBBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IATTACHJOBDAL;
		}
    }
	public partial class Auth_Define_DataScopeBLL : BaseBLL<HCQ2_Model.Auth_Define_DataScope>,IAuth_Define_DataScopeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IAuth_Define_DataScopeDAL;
		}
    }
	public partial class Auth_Define_DataScopeItemBLL : BaseBLL<HCQ2_Model.Auth_Define_DataScopeItem>,IAuth_Define_DataScopeItemBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IAuth_Define_DataScopeItemDAL;
		}
    }
	public partial class Auth_Define_FuncBLL : BaseBLL<HCQ2_Model.Auth_Define_Func>,IAuth_Define_FuncBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IAuth_Define_FuncDAL;
		}
    }
	public partial class Auth_Define_SetDBBLL : BaseBLL<HCQ2_Model.Auth_Define_SetDB>,IAuth_Define_SetDBBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IAuth_Define_SetDBDAL;
		}
    }
	public partial class Auth_Define_SetItemBLL : BaseBLL<HCQ2_Model.Auth_Define_SetItem>,IAuth_Define_SetItemBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IAuth_Define_SetItemDAL;
		}
    }
	public partial class Auth_Define_SetTableBLL : BaseBLL<HCQ2_Model.Auth_Define_SetTable>,IAuth_Define_SetTableBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IAuth_Define_SetTableDAL;
		}
    }
	public partial class Auth_OrgRoleBLL : BaseBLL<HCQ2_Model.Auth_OrgRole>,IAuth_OrgRoleBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IAuth_OrgRoleDAL;
		}
    }
	public partial class Auth_PermissionBLL : BaseBLL<HCQ2_Model.Auth_Permission>,IAuth_PermissionBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IAuth_PermissionDAL;
		}
    }
	public partial class Auth_PermissionScopeBLL : BaseBLL<HCQ2_Model.Auth_PermissionScope>,IAuth_PermissionScopeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IAuth_PermissionScopeDAL;
		}
    }
	public partial class Auth_RoleBLL : BaseBLL<HCQ2_Model.Auth_Role>,IAuth_RoleBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IAuth_RoleDAL;
		}
    }
	public partial class Auth_SecretLoginBLL : BaseBLL<HCQ2_Model.Auth_SecretLogin>,IAuth_SecretLoginBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IAuth_SecretLoginDAL;
		}
    }
	public partial class Auth_UserBLL : BaseBLL<HCQ2_Model.Auth_User>,IAuth_UserBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IAuth_UserDAL;
		}
    }
	public partial class Auth_UserGroupBLL : BaseBLL<HCQ2_Model.Auth_UserGroup>,IAuth_UserGroupBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IAuth_UserGroupDAL;
		}
    }
	public partial class Auth_UserGroupRoleBLL : BaseBLL<HCQ2_Model.Auth_UserGroupRole>,IAuth_UserGroupRoleBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IAuth_UserGroupRoleDAL;
		}
    }
	public partial class Auth_UserLogonBLL : BaseBLL<HCQ2_Model.Auth_UserLogon>,IAuth_UserLogonBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IAuth_UserLogonDAL;
		}
    }
	public partial class Auth_UserRoleBLL : BaseBLL<HCQ2_Model.Auth_UserRole>,IAuth_UserRoleBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IAuth_UserRoleDAL;
		}
    }
	public partial class Auth_UserWeixinBLL : BaseBLL<HCQ2_Model.Auth_UserWeixin>,IAuth_UserWeixinBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IAuth_UserWeixinDAL;
		}
    }
	public partial class B01BLL : BaseBLL<HCQ2_Model.B01>,IB01BLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IB01DAL;
		}
    }
	public partial class BB_CashDetailBLL : BaseBLL<HCQ2_Model.BB_CashDetail>,IBB_CashDetailBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_CashDetailDAL;
		}
    }
	public partial class BB_DWBLL : BaseBLL<HCQ2_Model.BB_DW>,IBB_DWBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_DWDAL;
		}
    }
	public partial class BB_DWLevelBLL : BaseBLL<HCQ2_Model.BB_DWLevel>,IBB_DWLevelBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_DWLevelDAL;
		}
    }
	public partial class BB_DWLevelUserBLL : BaseBLL<HCQ2_Model.BB_DWLevelUser>,IBB_DWLevelUserBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_DWLevelUserDAL;
		}
    }
	public partial class BB_DWStateBLL : BaseBLL<HCQ2_Model.BB_DWState>,IBB_DWStateBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_DWStateDAL;
		}
    }
	public partial class BB_DWStateCheckResultBLL : BaseBLL<HCQ2_Model.BB_DWStateCheckResult>,IBB_DWStateCheckResultBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_DWStateCheckResultDAL;
		}
    }
	public partial class BB_DWTotalBLL : BaseBLL<HCQ2_Model.BB_DWTotal>,IBB_DWTotalBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_DWTotalDAL;
		}
    }
	public partial class BB_FacilityPreserveBLL : BaseBLL<HCQ2_Model.BB_FacilityPreserve>,IBB_FacilityPreserveBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_FacilityPreserveDAL;
		}
    }
	public partial class BB_FetchDataSetupBLL : BaseBLL<HCQ2_Model.BB_FetchDataSetup>,IBB_FetchDataSetupBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_FetchDataSetupDAL;
		}
    }
	public partial class BB_FetchFCBLL : BaseBLL<HCQ2_Model.BB_FetchFC>,IBB_FetchFCBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_FetchFCDAL;
		}
    }
	public partial class BB_FetchNumberFuncBLL : BaseBLL<HCQ2_Model.BB_FetchNumberFunc>,IBB_FetchNumberFuncBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_FetchNumberFuncDAL;
		}
    }
	public partial class BB_FetchPoolLogBLL : BaseBLL<HCQ2_Model.BB_FetchPoolLog>,IBB_FetchPoolLogBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_FetchPoolLogDAL;
		}
    }
	public partial class BB_InternalReciveLogBLL : BaseBLL<HCQ2_Model.BB_InternalReciveLog>,IBB_InternalReciveLogBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_InternalReciveLogDAL;
		}
    }
	public partial class BB_InternalSendBLL : BaseBLL<HCQ2_Model.BB_InternalSend>,IBB_InternalSendBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_InternalSendDAL;
		}
    }
	public partial class BB_ItemPreserveBLL : BaseBLL<HCQ2_Model.BB_ItemPreserve>,IBB_ItemPreserveBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_ItemPreserveDAL;
		}
    }
	public partial class BB_PactDetailFlieBLL : BaseBLL<HCQ2_Model.BB_PactDetailFlie>,IBB_PactDetailFlieBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_PactDetailFlieDAL;
		}
    }
	public partial class BB_ServiceUserBLL : BaseBLL<HCQ2_Model.BB_ServiceUser>,IBB_ServiceUserBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_ServiceUserDAL;
		}
    }
	public partial class BB_SJ_DataSpecialBLL : BaseBLL<HCQ2_Model.BB_SJ_DataSpecial>,IBB_SJ_DataSpecialBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_SJ_DataSpecialDAL;
		}
    }
	public partial class BB_SJ_NoteFloatBLL : BaseBLL<HCQ2_Model.BB_SJ_NoteFloat>,IBB_SJ_NoteFloatBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_SJ_NoteFloatDAL;
		}
    }
	public partial class BB_SJ_NoteTextBLL : BaseBLL<HCQ2_Model.BB_SJ_NoteText>,IBB_SJ_NoteTextBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_SJ_NoteTextDAL;
		}
    }
	public partial class BB_TBBLL : BaseBLL<HCQ2_Model.BB_TB>,IBB_TBBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_TBDAL;
		}
    }
	public partial class BB_TBClassBLL : BaseBLL<HCQ2_Model.BB_TBClass>,IBB_TBClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_TBClassDAL;
		}
    }
	public partial class BB_TBDataHintBLL : BaseBLL<HCQ2_Model.BB_TBDataHint>,IBB_TBDataHintBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_TBDataHintDAL;
		}
    }
	public partial class BB_TBItemsBLL : BaseBLL<HCQ2_Model.BB_TBItems>,IBB_TBItemsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_TBItemsDAL;
		}
    }
	public partial class BB_TBRemarkUserLevelBLL : BaseBLL<HCQ2_Model.BB_TBRemarkUserLevel>,IBB_TBRemarkUserLevelBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_TBRemarkUserLevelDAL;
		}
    }
	public partial class BB_TBRemarkUsersBLL : BaseBLL<HCQ2_Model.BB_TBRemarkUsers>,IBB_TBRemarkUsersBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_TBRemarkUsersDAL;
		}
    }
	public partial class BB_TotalFCBLL : BaseBLL<HCQ2_Model.BB_TotalFC>,IBB_TotalFCBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_TotalFCDAL;
		}
    }
	public partial class BB_TrackRecordBLL : BaseBLL<HCQ2_Model.BB_TrackRecord>,IBB_TrackRecordBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_TrackRecordDAL;
		}
    }
	public partial class BB_TypeBLL : BaseBLL<HCQ2_Model.BB_Type>,IBB_TypeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_TypeDAL;
		}
    }
	public partial class BB_TypeCycleBLL : BaseBLL<HCQ2_Model.BB_TypeCycle>,IBB_TypeCycleBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_TypeCycleDAL;
		}
    }
	public partial class BB_UpDataLogBLL : BaseBLL<HCQ2_Model.BB_UpDataLog>,IBB_UpDataLogBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_UpDataLogDAL;
		}
    }
	public partial class BB_ZBBLL : BaseBLL<HCQ2_Model.BB_ZB>,IBB_ZBBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_ZBDAL;
		}
    }
	public partial class BB_ZBConditionBLL : BaseBLL<HCQ2_Model.BB_ZBCondition>,IBB_ZBConditionBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_ZBConditionDAL;
		}
    }
	public partial class BB_ZBVarItemsBLL : BaseBLL<HCQ2_Model.BB_ZBVarItems>,IBB_ZBVarItemsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBB_ZBVarItemsDAL;
		}
    }
	public partial class BMQ_DocumentBLL : BaseBLL<HCQ2_Model.BMQ_Document>,IBMQ_DocumentBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBMQ_DocumentDAL;
		}
    }
	public partial class BPM_AgencyRuleBLL : BaseBLL<HCQ2_Model.BPM_AgencyRule>,IBPM_AgencyRuleBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_AgencyRuleDAL;
		}
    }
	public partial class BPM_AgencyRuleAssigneeBLL : BaseBLL<HCQ2_Model.BPM_AgencyRuleAssignee>,IBPM_AgencyRuleAssigneeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_AgencyRuleAssigneeDAL;
		}
    }
	public partial class BPM_AgencyRuleProcessBLL : BaseBLL<HCQ2_Model.BPM_AgencyRuleProcess>,IBPM_AgencyRuleProcessBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_AgencyRuleProcessDAL;
		}
    }
	public partial class BPM_D_AskForLeaveDemo_MainBLL : BaseBLL<HCQ2_Model.BPM_D_AskForLeaveDemo_Main>,IBPM_D_AskForLeaveDemo_MainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_D_AskForLeaveDemo_MainDAL;
		}
    }
	public partial class BPM_D_Leave_MainBLL : BaseBLL<HCQ2_Model.BPM_D_Leave_Main>,IBPM_D_Leave_MainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_D_Leave_MainDAL;
		}
    }
	public partial class BPM_D_NewEmployees_MainBLL : BaseBLL<HCQ2_Model.BPM_D_NewEmployees_Main>,IBPM_D_NewEmployees_MainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_D_NewEmployees_MainDAL;
		}
    }
	public partial class BPM_Define_ActionListenerBLL : BaseBLL<HCQ2_Model.BPM_Define_ActionListener>,IBPM_Define_ActionListenerBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_Define_ActionListenerDAL;
		}
    }
	public partial class BPM_Define_ActorAdapterBLL : BaseBLL<HCQ2_Model.BPM_Define_ActorAdapter>,IBPM_Define_ActorAdapterBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_Define_ActorAdapterDAL;
		}
    }
	public partial class BPM_Define_ActorAdapter_bakBLL : BaseBLL<HCQ2_Model.BPM_Define_ActorAdapter_bak>,IBPM_Define_ActorAdapter_bakBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_Define_ActorAdapter_bakDAL;
		}
    }
	public partial class BPM_Define_CatalogBLL : BaseBLL<HCQ2_Model.BPM_Define_Catalog>,IBPM_Define_CatalogBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_Define_CatalogDAL;
		}
    }
	public partial class BPM_Define_ConstBLL : BaseBLL<HCQ2_Model.BPM_Define_Const>,IBPM_Define_ConstBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_Define_ConstDAL;
		}
    }
	public partial class BPM_Define_DataModelBLL : BaseBLL<HCQ2_Model.BPM_Define_DataModel>,IBPM_Define_DataModelBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_Define_DataModelDAL;
		}
    }
	public partial class BPM_Define_FormBLL : BaseBLL<HCQ2_Model.BPM_Define_Form>,IBPM_Define_FormBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_Define_FormDAL;
		}
    }
	public partial class BPM_Define_PackageBLL : BaseBLL<HCQ2_Model.BPM_Define_Package>,IBPM_Define_PackageBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_Define_PackageDAL;
		}
    }
	public partial class BPM_Define_ProcessDraftBLL : BaseBLL<HCQ2_Model.BPM_Define_ProcessDraft>,IBPM_Define_ProcessDraftBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_Define_ProcessDraftDAL;
		}
    }
	public partial class BPM_Define_ProcessPublishedBLL : BaseBLL<HCQ2_Model.BPM_Define_ProcessPublished>,IBPM_Define_ProcessPublishedBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_Define_ProcessPublishedDAL;
		}
    }
	public partial class BPM_Define_SchemeBLL : BaseBLL<HCQ2_Model.BPM_Define_Scheme>,IBPM_Define_SchemeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_Define_SchemeDAL;
		}
    }
	public partial class BPM_Run_InstanceBLL : BaseBLL<HCQ2_Model.BPM_Run_Instance>,IBPM_Run_InstanceBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_Run_InstanceDAL;
		}
    }
	public partial class BPM_Run_ProcessLogBLL : BaseBLL<HCQ2_Model.BPM_Run_ProcessLog>,IBPM_Run_ProcessLogBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_Run_ProcessLogDAL;
		}
    }
	public partial class BPM_Run_SchemeJobBLL : BaseBLL<HCQ2_Model.BPM_Run_SchemeJob>,IBPM_Run_SchemeJobBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_Run_SchemeJobDAL;
		}
    }
	public partial class BPM_Run_SharedTaskBLL : BaseBLL<HCQ2_Model.BPM_Run_SharedTask>,IBPM_Run_SharedTaskBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_Run_SharedTaskDAL;
		}
    }
	public partial class BPM_Run_TrackingBLL : BaseBLL<HCQ2_Model.BPM_Run_Tracking>,IBPM_Run_TrackingBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_Run_TrackingDAL;
		}
    }
	public partial class BPM_Run_UrgedBLL : BaseBLL<HCQ2_Model.BPM_Run_Urged>,IBPM_Run_UrgedBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_Run_UrgedDAL;
		}
    }
	public partial class BPM_Run_VariableBLL : BaseBLL<HCQ2_Model.BPM_Run_Variable>,IBPM_Run_VariableBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_Run_VariableDAL;
		}
    }
	public partial class BPM_Run_WorkTaskBLL : BaseBLL<HCQ2_Model.BPM_Run_WorkTask>,IBPM_Run_WorkTaskBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_Run_WorkTaskDAL;
		}
    }
	public partial class BPM_Run_WorkTaskOpinionBLL : BaseBLL<HCQ2_Model.BPM_Run_WorkTaskOpinion>,IBPM_Run_WorkTaskOpinionBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_Run_WorkTaskOpinionDAL;
		}
    }
	public partial class BPM_UserExtInfoBLL : BaseBLL<HCQ2_Model.BPM_UserExtInfo>,IBPM_UserExtInfoBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_UserExtInfoDAL;
		}
    }
	public partial class BPM_UsuallyOpinionBLL : BaseBLL<HCQ2_Model.BPM_UsuallyOpinion>,IBPM_UsuallyOpinionBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IBPM_UsuallyOpinionDAL;
		}
    }
	public partial class Cache_BlobInfoBLL : BaseBLL<HCQ2_Model.Cache_BlobInfo>,ICache_BlobInfoBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ICache_BlobInfoDAL;
		}
    }
	public partial class Cache_StatDataBLL : BaseBLL<HCQ2_Model.Cache_StatData>,ICache_StatDataBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ICache_StatDataDAL;
		}
    }
	public partial class Com_CatalogBLL : BaseBLL<HCQ2_Model.Com_Catalog>,ICom_CatalogBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ICom_CatalogDAL;
		}
    }
	public partial class Com_FormulaBLL : BaseBLL<HCQ2_Model.Com_Formula>,ICom_FormulaBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ICom_FormulaDAL;
		}
    }
	public partial class Com_JetTableItemsBLL : BaseBLL<HCQ2_Model.Com_JetTableItems>,ICom_JetTableItemsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ICom_JetTableItemsDAL;
		}
    }
	public partial class Com_JetTableMainBLL : BaseBLL<HCQ2_Model.Com_JetTableMain>,ICom_JetTableMainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ICom_JetTableMainDAL;
		}
    }
	public partial class Com_LimitItemsBLL : BaseBLL<HCQ2_Model.Com_LimitItems>,ICom_LimitItemsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ICom_LimitItemsDAL;
		}
    }
	public partial class Com_LimitMainBLL : BaseBLL<HCQ2_Model.Com_LimitMain>,ICom_LimitMainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ICom_LimitMainDAL;
		}
    }
	public partial class Com_MusterSimpleBLL : BaseBLL<HCQ2_Model.Com_MusterSimple>,ICom_MusterSimpleBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ICom_MusterSimpleDAL;
		}
    }
	public partial class Com_MusterSimpleFieldsBLL : BaseBLL<HCQ2_Model.Com_MusterSimpleFields>,ICom_MusterSimpleFieldsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ICom_MusterSimpleFieldsDAL;
		}
    }
	public partial class Com_RelationBodyBLL : BaseBLL<HCQ2_Model.Com_RelationBody>,ICom_RelationBodyBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ICom_RelationBodyDAL;
		}
    }
	public partial class Com_RelationMainBLL : BaseBLL<HCQ2_Model.Com_RelationMain>,ICom_RelationMainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ICom_RelationMainDAL;
		}
    }
	public partial class Com_SortItemsBLL : BaseBLL<HCQ2_Model.Com_SortItems>,ICom_SortItemsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ICom_SortItemsDAL;
		}
    }
	public partial class Com_SortMainBLL : BaseBLL<HCQ2_Model.Com_SortMain>,ICom_SortMainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ICom_SortMainDAL;
		}
    }
	public partial class Com_StatAnalysisItemsBLL : BaseBLL<HCQ2_Model.Com_StatAnalysisItems>,ICom_StatAnalysisItemsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ICom_StatAnalysisItemsDAL;
		}
    }
	public partial class Com_StatAnalysisMainBLL : BaseBLL<HCQ2_Model.Com_StatAnalysisMain>,ICom_StatAnalysisMainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ICom_StatAnalysisMainDAL;
		}
    }
	public partial class Com_StatLimitColumnsBLL : BaseBLL<HCQ2_Model.Com_StatLimitColumns>,ICom_StatLimitColumnsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ICom_StatLimitColumnsDAL;
		}
    }
	public partial class Com_StatLimitMainBLL : BaseBLL<HCQ2_Model.Com_StatLimitMain>,ICom_StatLimitMainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ICom_StatLimitMainDAL;
		}
    }
	public partial class Com_StatLimitRowsBLL : BaseBLL<HCQ2_Model.Com_StatLimitRows>,ICom_StatLimitRowsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ICom_StatLimitRowsDAL;
		}
    }
	public partial class G01BLL : BaseBLL<HCQ2_Model.G01>,IG01BLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IG01DAL;
		}
    }
	public partial class HR_MusterFieldsBLL : BaseBLL<HCQ2_Model.HR_MusterFields>,IHR_MusterFieldsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IHR_MusterFieldsDAL;
		}
    }
	public partial class HR_MusterMainBLL : BaseBLL<HCQ2_Model.HR_MusterMain>,IHR_MusterMainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IHR_MusterMainDAL;
		}
    }
	public partial class OP_ExcelForm_ArgsBLL : BaseBLL<HCQ2_Model.OP_ExcelForm_Args>,IOP_ExcelForm_ArgsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IOP_ExcelForm_ArgsDAL;
		}
    }
	public partial class OP_ExcelForm_CatalogBLL : BaseBLL<HCQ2_Model.OP_ExcelForm_Catalog>,IOP_ExcelForm_CatalogBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IOP_ExcelForm_CatalogDAL;
		}
    }
	public partial class OP_ExcelForm_CellBLL : BaseBLL<HCQ2_Model.OP_ExcelForm_Cell>,IOP_ExcelForm_CellBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IOP_ExcelForm_CellDAL;
		}
    }
	public partial class OP_ExcelForm_ColBLL : BaseBLL<HCQ2_Model.OP_ExcelForm_Col>,IOP_ExcelForm_ColBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IOP_ExcelForm_ColDAL;
		}
    }
	public partial class OP_ExcelForm_DataSourceBLL : BaseBLL<HCQ2_Model.OP_ExcelForm_DataSource>,IOP_ExcelForm_DataSourceBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IOP_ExcelForm_DataSourceDAL;
		}
    }
	public partial class OP_ExcelForm_DataSourceParseBLL : BaseBLL<HCQ2_Model.OP_ExcelForm_DataSourceParse>,IOP_ExcelForm_DataSourceParseBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IOP_ExcelForm_DataSourceParseDAL;
		}
    }
	public partial class OP_ExcelForm_InputBLL : BaseBLL<HCQ2_Model.OP_ExcelForm_Input>,IOP_ExcelForm_InputBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IOP_ExcelForm_InputDAL;
		}
    }
	public partial class OP_ExcelForm_InputTableBLL : BaseBLL<HCQ2_Model.OP_ExcelForm_InputTable>,IOP_ExcelForm_InputTableBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IOP_ExcelForm_InputTableDAL;
		}
    }
	public partial class OP_ExcelForm_InputTableFieldBLL : BaseBLL<HCQ2_Model.OP_ExcelForm_InputTableField>,IOP_ExcelForm_InputTableFieldBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IOP_ExcelForm_InputTableFieldDAL;
		}
    }
	public partial class OP_ExcelForm_MainBLL : BaseBLL<HCQ2_Model.OP_ExcelForm_Main>,IOP_ExcelForm_MainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IOP_ExcelForm_MainDAL;
		}
    }
	public partial class OP_ExcelForm_PrivilegeBLL : BaseBLL<HCQ2_Model.OP_ExcelForm_Privilege>,IOP_ExcelForm_PrivilegeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IOP_ExcelForm_PrivilegeDAL;
		}
    }
	public partial class OP_ExcelForm_RowBLL : BaseBLL<HCQ2_Model.OP_ExcelForm_Row>,IOP_ExcelForm_RowBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IOP_ExcelForm_RowDAL;
		}
    }
	public partial class OP_ExcelForm_RowColBLL : BaseBLL<HCQ2_Model.OP_ExcelForm_RowCol>,IOP_ExcelForm_RowColBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IOP_ExcelForm_RowColDAL;
		}
    }
	public partial class Project_LogApiBLL : BaseBLL<HCQ2_Model.Project_LogApi>,IProject_LogApiBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IProject_LogApiDAL;
		}
    }
	public partial class RC_DataHintBLL : BaseBLL<HCQ2_Model.RC_DataHint>,IRC_DataHintBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IRC_DataHintDAL;
		}
    }
	public partial class RC_DataHintStateBLL : BaseBLL<HCQ2_Model.RC_DataHintState>,IRC_DataHintStateBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IRC_DataHintStateDAL;
		}
    }
	public partial class RC_DataLimitBLL : BaseBLL<HCQ2_Model.RC_DataLimit>,IRC_DataLimitBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IRC_DataLimitDAL;
		}
    }
	public partial class RC_ImportClientDataWayBLL : BaseBLL<HCQ2_Model.RC_ImportClientDataWay>,IRC_ImportClientDataWayBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IRC_ImportClientDataWayDAL;
		}
    }
	public partial class RC_InfoScriptBLL : BaseBLL<HCQ2_Model.RC_InfoScript>,IRC_InfoScriptBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IRC_InfoScriptDAL;
		}
    }
	public partial class RC_InfoScriptOrderBLL : BaseBLL<HCQ2_Model.RC_InfoScriptOrder>,IRC_InfoScriptOrderBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IRC_InfoScriptOrderDAL;
		}
    }
	public partial class RC_JTMainBLL : BaseBLL<HCQ2_Model.RC_JTMain>,IRC_JTMainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IRC_JTMainDAL;
		}
    }
	public partial class RC_MusterMainBLL : BaseBLL<HCQ2_Model.RC_MusterMain>,IRC_MusterMainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IRC_MusterMainDAL;
		}
    }
	public partial class RC_PolicyAttachBLL : BaseBLL<HCQ2_Model.RC_PolicyAttach>,IRC_PolicyAttachBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IRC_PolicyAttachDAL;
		}
    }
	public partial class RC_PolicyDetailBLL : BaseBLL<HCQ2_Model.RC_PolicyDetail>,IRC_PolicyDetailBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IRC_PolicyDetailDAL;
		}
    }
	public partial class RC_PolicyGroupBLL : BaseBLL<HCQ2_Model.RC_PolicyGroup>,IRC_PolicyGroupBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IRC_PolicyGroupDAL;
		}
    }
	public partial class RC_SearchContainerResultBLL : BaseBLL<HCQ2_Model.RC_SearchContainerResult>,IRC_SearchContainerResultBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IRC_SearchContainerResultDAL;
		}
    }
	public partial class RC_StatMainBLL : BaseBLL<HCQ2_Model.RC_StatMain>,IRC_StatMainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IRC_StatMainDAL;
		}
    }
	public partial class RC_StatMusterFieldBLL : BaseBLL<HCQ2_Model.RC_StatMusterField>,IRC_StatMusterFieldBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IRC_StatMusterFieldDAL;
		}
    }
	public partial class SM_CodeItemsBLL : BaseBLL<HCQ2_Model.SM_CodeItems>,ISM_CodeItemsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_CodeItemsDAL;
		}
    }
	public partial class SM_CodeTableBLL : BaseBLL<HCQ2_Model.SM_CodeTable>,ISM_CodeTableBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_CodeTableDAL;
		}
    }
	public partial class SM_CodeTableGroupBLL : BaseBLL<HCQ2_Model.SM_CodeTableGroup>,ISM_CodeTableGroupBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_CodeTableGroupDAL;
		}
    }
	public partial class SM_ConsoleUIGroupBLL : BaseBLL<HCQ2_Model.SM_ConsoleUIGroup>,ISM_ConsoleUIGroupBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_ConsoleUIGroupDAL;
		}
    }
	public partial class SM_ConsoleUIItemBLL : BaseBLL<HCQ2_Model.SM_ConsoleUIItem>,ISM_ConsoleUIItemBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_ConsoleUIItemDAL;
		}
    }
	public partial class SM_ConsoleUIWayBLL : BaseBLL<HCQ2_Model.SM_ConsoleUIWay>,ISM_ConsoleUIWayBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_ConsoleUIWayDAL;
		}
    }
	public partial class SM_ConsoleUIWayRoleBLL : BaseBLL<HCQ2_Model.SM_ConsoleUIWayRole>,ISM_ConsoleUIWayRoleBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_ConsoleUIWayRoleDAL;
		}
    }
	public partial class SM_DBConnectionBLL : BaseBLL<HCQ2_Model.SM_DBConnection>,ISM_DBConnectionBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_DBConnectionDAL;
		}
    }
	public partial class SM_GlobalScriptBLL : BaseBLL<HCQ2_Model.SM_GlobalScript>,ISM_GlobalScriptBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_GlobalScriptDAL;
		}
    }
	public partial class SM_IdentityBLL : BaseBLL<HCQ2_Model.SM_Identity>,ISM_IdentityBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_IdentityDAL;
		}
    }
	public partial class SM_LogBLL : BaseBLL<HCQ2_Model.SM_Log>,ISM_LogBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_LogDAL;
		}
    }
	public partial class SM_LogCycleTimerBLL : BaseBLL<HCQ2_Model.SM_LogCycleTimer>,ISM_LogCycleTimerBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_LogCycleTimerDAL;
		}
    }
	public partial class SM_LogDevelopBLL : BaseBLL<HCQ2_Model.SM_LogDevelop>,ISM_LogDevelopBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_LogDevelopDAL;
		}
    }
	public partial class SM_LogSystemBLL : BaseBLL<HCQ2_Model.SM_LogSystem>,ISM_LogSystemBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_LogSystemDAL;
		}
    }
	public partial class SM_PersonClassBLL : BaseBLL<HCQ2_Model.SM_PersonClass>,ISM_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_PersonClassDAL;
		}
    }
	public partial class SM_PluginBLL : BaseBLL<HCQ2_Model.SM_Plugin>,ISM_PluginBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_PluginDAL;
		}
    }
	public partial class SM_Prototype_SimpleBLL : BaseBLL<HCQ2_Model.SM_Prototype_Simple>,ISM_Prototype_SimpleBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_Prototype_SimpleDAL;
		}
    }
	public partial class SM_PYBLL : BaseBLL<HCQ2_Model.SM_PY>,ISM_PYBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_PYDAL;
		}
    }
	public partial class SM_SchedulerBLL : BaseBLL<HCQ2_Model.SM_Scheduler>,ISM_SchedulerBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_SchedulerDAL;
		}
    }
	public partial class SM_SchedulerNotifyBLL : BaseBLL<HCQ2_Model.SM_SchedulerNotify>,ISM_SchedulerNotifyBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_SchedulerNotifyDAL;
		}
    }
	public partial class SM_SchedulerPlanBLL : BaseBLL<HCQ2_Model.SM_SchedulerPlan>,ISM_SchedulerPlanBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_SchedulerPlanDAL;
		}
    }
	public partial class SM_SchedulerRunLogBLL : BaseBLL<HCQ2_Model.SM_SchedulerRunLog>,ISM_SchedulerRunLogBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_SchedulerRunLogDAL;
		}
    }
	public partial class SM_SchedulerTaskBLL : BaseBLL<HCQ2_Model.SM_SchedulerTask>,ISM_SchedulerTaskBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_SchedulerTaskDAL;
		}
    }
	public partial class SM_SequenceManageBLL : BaseBLL<HCQ2_Model.SM_SequenceManage>,ISM_SequenceManageBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_SequenceManageDAL;
		}
    }
	public partial class SM_SetDBBLL : BaseBLL<HCQ2_Model.SM_SetDB>,ISM_SetDBBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_SetDBDAL;
		}
    }
	public partial class SM_SetItemCalcBLL : BaseBLL<HCQ2_Model.SM_SetItemCalc>,ISM_SetItemCalcBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_SetItemCalcDAL;
		}
    }
	public partial class SM_SetItemsBLL : BaseBLL<HCQ2_Model.SM_SetItems>,ISM_SetItemsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_SetItemsDAL;
		}
    }
	public partial class SM_SetItemUserConfigBLL : BaseBLL<HCQ2_Model.SM_SetItemUserConfig>,ISM_SetItemUserConfigBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_SetItemUserConfigDAL;
		}
    }
	public partial class SM_SetTableBLL : BaseBLL<HCQ2_Model.SM_SetTable>,ISM_SetTableBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_SetTableDAL;
		}
    }
	public partial class SM_SetTableUserConfigBLL : BaseBLL<HCQ2_Model.SM_SetTableUserConfig>,ISM_SetTableUserConfigBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_SetTableUserConfigDAL;
		}
    }
	public partial class SM_SetWayUserConfigBLL : BaseBLL<HCQ2_Model.SM_SetWayUserConfig>,ISM_SetWayUserConfigBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_SetWayUserConfigDAL;
		}
    }
	public partial class SM_SqlTemplet_ArgsBLL : BaseBLL<HCQ2_Model.SM_SqlTemplet_Args>,ISM_SqlTemplet_ArgsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_SqlTemplet_ArgsDAL;
		}
    }
	public partial class SM_SqlTemplet_CatalogBLL : BaseBLL<HCQ2_Model.SM_SqlTemplet_Catalog>,ISM_SqlTemplet_CatalogBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_SqlTemplet_CatalogDAL;
		}
    }
	public partial class SM_SqlTemplet_MainBLL : BaseBLL<HCQ2_Model.SM_SqlTemplet_Main>,ISM_SqlTemplet_MainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_SqlTemplet_MainDAL;
		}
    }
	public partial class SM_Stamp_UnitBLL : BaseBLL<HCQ2_Model.SM_Stamp_Unit>,ISM_Stamp_UnitBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_Stamp_UnitDAL;
		}
    }
	public partial class SM_Stamp_UnitUserBLL : BaseBLL<HCQ2_Model.SM_Stamp_UnitUser>,ISM_Stamp_UnitUserBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_Stamp_UnitUserDAL;
		}
    }
	public partial class SM_SystemKeyValueBLL : BaseBLL<HCQ2_Model.SM_SystemKeyValue>,ISM_SystemKeyValueBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_SystemKeyValueDAL;
		}
    }
	public partial class SM_SystemMessageBLL : BaseBLL<HCQ2_Model.SM_SystemMessage>,ISM_SystemMessageBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_SystemMessageDAL;
		}
    }
	public partial class SM_SystemModuleKeyFileBLL : BaseBLL<HCQ2_Model.SM_SystemModuleKeyFile>,ISM_SystemModuleKeyFileBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_SystemModuleKeyFileDAL;
		}
    }
	public partial class SM_SystemModuleKeyValueBLL : BaseBLL<HCQ2_Model.SM_SystemModuleKeyValue>,ISM_SystemModuleKeyValueBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_SystemModuleKeyValueDAL;
		}
    }
	public partial class SM_Theme_ConfigV2BLL : BaseBLL<HCQ2_Model.SM_Theme_ConfigV2>,ISM_Theme_ConfigV2BLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_Theme_ConfigV2DAL;
		}
    }
	public partial class SM_Theme_ConfigV2_FileBLL : BaseBLL<HCQ2_Model.SM_Theme_ConfigV2_File>,ISM_Theme_ConfigV2_FileBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_Theme_ConfigV2_FileDAL;
		}
    }
	public partial class SM_Theme_ConfigV2_RoleBLL : BaseBLL<HCQ2_Model.SM_Theme_ConfigV2_Role>,ISM_Theme_ConfigV2_RoleBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_Theme_ConfigV2_RoleDAL;
		}
    }
	public partial class SM_Todo_DataWarnBLL : BaseBLL<HCQ2_Model.SM_Todo_DataWarn>,ISM_Todo_DataWarnBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_Todo_DataWarnDAL;
		}
    }
	public partial class SM_Todo_NoticeBLL : BaseBLL<HCQ2_Model.SM_Todo_Notice>,ISM_Todo_NoticeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_Todo_NoticeDAL;
		}
    }
	public partial class SM_UserKeyValueBLL : BaseBLL<HCQ2_Model.SM_UserKeyValue>,ISM_UserKeyValueBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_UserKeyValueDAL;
		}
    }
	public partial class SM_UserKeyValueExBLL : BaseBLL<HCQ2_Model.SM_UserKeyValueEx>,ISM_UserKeyValueExBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_UserKeyValueExDAL;
		}
    }
	public partial class SM_UserOnlineLoggerBLL : BaseBLL<HCQ2_Model.SM_UserOnlineLogger>,ISM_UserOnlineLoggerBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_UserOnlineLoggerDAL;
		}
    }
	public partial class SM_UserRelationBLL : BaseBLL<HCQ2_Model.SM_UserRelation>,ISM_UserRelationBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_UserRelationDAL;
		}
    }
	public partial class SM_UserRelationItemBLL : BaseBLL<HCQ2_Model.SM_UserRelationItem>,ISM_UserRelationItemBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_UserRelationItemDAL;
		}
    }
	public partial class SM_VersionBLL : BaseBLL<HCQ2_Model.SM_Version>,ISM_VersionBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_VersionDAL;
		}
    }
	public partial class SM_Weixin_SystemConfigBLL : BaseBLL<HCQ2_Model.SM_Weixin_SystemConfig>,ISM_Weixin_SystemConfigBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_Weixin_SystemConfigDAL;
		}
    }
	public partial class SM_WidgetHomepage_MainBLL : BaseBLL<HCQ2_Model.SM_WidgetHomepage_Main>,ISM_WidgetHomepage_MainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_WidgetHomepage_MainDAL;
		}
    }
	public partial class SM_WidgetHomepage_UserConfigBLL : BaseBLL<HCQ2_Model.SM_WidgetHomepage_UserConfig>,ISM_WidgetHomepage_UserConfigBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_WidgetHomepage_UserConfigDAL;
		}
    }
	public partial class SM_WidgetModule_ArgsBLL : BaseBLL<HCQ2_Model.SM_WidgetModule_Args>,ISM_WidgetModule_ArgsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_WidgetModule_ArgsDAL;
		}
    }
	public partial class SM_WidgetModule_CatalogBLL : BaseBLL<HCQ2_Model.SM_WidgetModule_Catalog>,ISM_WidgetModule_CatalogBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_WidgetModule_CatalogDAL;
		}
    }
	public partial class SM_WidgetModule_FilesBLL : BaseBLL<HCQ2_Model.SM_WidgetModule_Files>,ISM_WidgetModule_FilesBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_WidgetModule_FilesDAL;
		}
    }
	public partial class SM_WidgetModule_MainBLL : BaseBLL<HCQ2_Model.SM_WidgetModule_Main>,ISM_WidgetModule_MainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_WidgetModule_MainDAL;
		}
    }
	public partial class SM_WidgetModule_ObjectConfigBLL : BaseBLL<HCQ2_Model.SM_WidgetModule_ObjectConfig>,ISM_WidgetModule_ObjectConfigBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_WidgetModule_ObjectConfigDAL;
		}
    }
	public partial class SM_WidgetModule_ToolBLL : BaseBLL<HCQ2_Model.SM_WidgetModule_Tool>,ISM_WidgetModule_ToolBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_WidgetModule_ToolDAL;
		}
    }
	public partial class SM_WidgetModule_ToolBarBLL : BaseBLL<HCQ2_Model.SM_WidgetModule_ToolBar>,ISM_WidgetModule_ToolBarBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.ISM_WidgetModule_ToolBarDAL;
		}
    }
	public partial class sysdiagramsBLL : BaseBLL<HCQ2_Model.sysdiagrams>,IsysdiagramsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IsysdiagramsDAL;
		}
    }
	public partial class T_AreaInfoBLL : BaseBLL<HCQ2_Model.T_AreaInfo>,IT_AreaInfoBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_AreaInfoDAL;
		}
    }
	public partial class T_AreaPermissRelationBLL : BaseBLL<HCQ2_Model.T_AreaPermissRelation>,IT_AreaPermissRelationBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_AreaPermissRelationDAL;
		}
    }
	public partial class T_AskManagerBLL : BaseBLL<HCQ2_Model.T_AskManager>,IT_AskManagerBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_AskManagerDAL;
		}
    }
	public partial class T_B01PermissRelationBLL : BaseBLL<HCQ2_Model.T_B01PermissRelation>,IT_B01PermissRelationBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_B01PermissRelationDAL;
		}
    }
	public partial class T_ComplaintsBLL : BaseBLL<HCQ2_Model.T_Complaints>,IT_ComplaintsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_ComplaintsDAL;
		}
    }
	public partial class T_CompProInfoBLL : BaseBLL<HCQ2_Model.T_CompProInfo>,IT_CompProInfoBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_CompProInfoDAL;
		}
    }
	public partial class T_DocFolderPermissRelationBLL : BaseBLL<HCQ2_Model.T_DocFolderPermissRelation>,IT_DocFolderPermissRelationBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_DocFolderPermissRelationDAL;
		}
    }
	public partial class T_DocumentFolderBLL : BaseBLL<HCQ2_Model.T_DocumentFolder>,IT_DocumentFolderBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_DocumentFolderDAL;
		}
    }
	public partial class T_DocumentFolderRelationBLL : BaseBLL<HCQ2_Model.T_DocumentFolderRelation>,IT_DocumentFolderRelationBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_DocumentFolderRelationDAL;
		}
    }
	public partial class T_DocumentInfoBLL : BaseBLL<HCQ2_Model.T_DocumentInfo>,IT_DocumentInfoBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_DocumentInfoDAL;
		}
    }
	public partial class T_DocumentSetTypeBLL : BaseBLL<HCQ2_Model.T_DocumentSetType>,IT_DocumentSetTypeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_DocumentSetTypeDAL;
		}
    }
	public partial class T_ElementPermissRelationBLL : BaseBLL<HCQ2_Model.T_ElementPermissRelation>,IT_ElementPermissRelationBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_ElementPermissRelationDAL;
		}
    }
	public partial class T_EnterDetailBLL : BaseBLL<HCQ2_Model.T_EnterDetail>,IT_EnterDetailBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_EnterDetailDAL;
		}
    }
	public partial class T_EquipmentBLL : BaseBLL<HCQ2_Model.T_Equipment>,IT_EquipmentBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_EquipmentDAL;
		}
    }
	public partial class T_ExceptionLogBLL : BaseBLL<HCQ2_Model.T_ExceptionLog>,IT_ExceptionLogBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_ExceptionLogDAL;
		}
    }
	public partial class T_FilePermissRelationBLL : BaseBLL<HCQ2_Model.T_FilePermissRelation>,IT_FilePermissRelationBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_FilePermissRelationDAL;
		}
    }
	public partial class T_FolderPermissRelationBLL : BaseBLL<HCQ2_Model.T_FolderPermissRelation>,IT_FolderPermissRelationBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_FolderPermissRelationDAL;
		}
    }
	public partial class T_FunctionBLL : BaseBLL<HCQ2_Model.T_Function>,IT_FunctionBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_FunctionDAL;
		}
    }
	public partial class T_ImplementBLL : BaseBLL<HCQ2_Model.T_Implement>,IT_ImplementBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_ImplementDAL;
		}
    }
	public partial class T_ItemCodeBLL : BaseBLL<HCQ2_Model.T_ItemCode>,IT_ItemCodeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_ItemCodeDAL;
		}
    }
	public partial class T_ItemCodeMenumBLL : BaseBLL<HCQ2_Model.T_ItemCodeMenum>,IT_ItemCodeMenumBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_ItemCodeMenumDAL;
		}
    }
	public partial class T_JobResumeRelationBLL : BaseBLL<HCQ2_Model.T_JobResumeRelation>,IT_JobResumeRelationBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_JobResumeRelationDAL;
		}
    }
	public partial class T_LimitUserBLL : BaseBLL<HCQ2_Model.T_LimitUser>,IT_LimitUserBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_LimitUserDAL;
		}
    }
	public partial class T_LoginBLL : BaseBLL<HCQ2_Model.T_Login>,IT_LoginBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_LoginDAL;
		}
    }
	public partial class T_LogSetingBLL : BaseBLL<HCQ2_Model.T_LogSeting>,IT_LogSetingBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_LogSetingDAL;
		}
    }
	public partial class T_LogSetingDetailBLL : BaseBLL<HCQ2_Model.T_LogSetingDetail>,IT_LogSetingDetailBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_LogSetingDetailDAL;
		}
    }
	public partial class T_MessageNoticeBLL : BaseBLL<HCQ2_Model.T_MessageNotice>,IT_MessageNoticeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_MessageNoticeDAL;
		}
    }
	public partial class T_ModulePermissRelationBLL : BaseBLL<HCQ2_Model.T_ModulePermissRelation>,IT_ModulePermissRelationBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_ModulePermissRelationDAL;
		}
    }
	public partial class T_Org_UserBLL : BaseBLL<HCQ2_Model.T_Org_User>,IT_Org_UserBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_Org_UserDAL;
		}
    }
	public partial class T_OrgFolderBLL : BaseBLL<HCQ2_Model.T_OrgFolder>,IT_OrgFolderBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_OrgFolderDAL;
		}
    }
	public partial class T_OrgUserRelationBLL : BaseBLL<HCQ2_Model.T_OrgUserRelation>,IT_OrgUserRelationBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_OrgUserRelationDAL;
		}
    }
	public partial class T_PageElementBLL : BaseBLL<HCQ2_Model.T_PageElement>,IT_PageElementBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_PageElementDAL;
		}
    }
	public partial class T_PageFileBLL : BaseBLL<HCQ2_Model.T_PageFile>,IT_PageFileBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_PageFileDAL;
		}
    }
	public partial class T_PageFolderBLL : BaseBLL<HCQ2_Model.T_PageFolder>,IT_PageFolderBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_PageFolderDAL;
		}
    }
	public partial class T_PayAccountBLL : BaseBLL<HCQ2_Model.T_PayAccount>,IT_PayAccountBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_PayAccountDAL;
		}
    }
	public partial class T_PerFuncRelationBLL : BaseBLL<HCQ2_Model.T_PerFuncRelation>,IT_PerFuncRelationBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_PerFuncRelationDAL;
		}
    }
	public partial class T_PermissConfigBLL : BaseBLL<HCQ2_Model.T_PermissConfig>,IT_PermissConfigBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_PermissConfigDAL;
		}
    }
	public partial class T_PermissionsBLL : BaseBLL<HCQ2_Model.T_Permissions>,IT_PermissionsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_PermissionsDAL;
		}
    }
	public partial class T_RoleBLL : BaseBLL<HCQ2_Model.T_Role>,IT_RoleBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_RoleDAL;
		}
    }
	public partial class T_RoleGroupRelationBLL : BaseBLL<HCQ2_Model.T_RoleGroupRelation>,IT_RoleGroupRelationBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_RoleGroupRelationDAL;
		}
    }
	public partial class T_RolePermissRelationBLL : BaseBLL<HCQ2_Model.T_RolePermissRelation>,IT_RolePermissRelationBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_RolePermissRelationDAL;
		}
    }
	public partial class T_SetMainPageBLL : BaseBLL<HCQ2_Model.T_SetMainPage>,IT_SetMainPageBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_SetMainPageDAL;
		}
    }
	public partial class T_SynchronousBLL : BaseBLL<HCQ2_Model.T_Synchronous>,IT_SynchronousBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_SynchronousDAL;
		}
    }
	public partial class T_SysModuleBLL : BaseBLL<HCQ2_Model.T_SysModule>,IT_SysModuleBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_SysModuleDAL;
		}
    }
	public partial class T_TableBLL : BaseBLL<HCQ2_Model.T_Table>,IT_TableBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_TableDAL;
		}
    }
	public partial class T_TableFieldBLL : BaseBLL<HCQ2_Model.T_TableField>,IT_TableFieldBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_TableFieldDAL;
		}
    }
	public partial class T_TodoListBLL : BaseBLL<HCQ2_Model.T_TodoList>,IT_TodoListBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_TodoListDAL;
		}
    }
	public partial class T_UserBLL : BaseBLL<HCQ2_Model.T_User>,IT_UserBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_UserDAL;
		}
    }
	public partial class T_UserGroupBLL : BaseBLL<HCQ2_Model.T_UserGroup>,IT_UserGroupBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_UserGroupDAL;
		}
    }
	public partial class T_UserGroupRelationBLL : BaseBLL<HCQ2_Model.T_UserGroupRelation>,IT_UserGroupRelationBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_UserGroupRelationDAL;
		}
    }
	public partial class T_UserRoleRelationBLL : BaseBLL<HCQ2_Model.T_UserRoleRelation>,IT_UserRoleRelationBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_UserRoleRelationDAL;
		}
    }
	public partial class T_UserUnitRelationBLL : BaseBLL<HCQ2_Model.T_UserUnitRelation>,IT_UserUnitRelationBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_UserUnitRelationDAL;
		}
    }
	public partial class T_UseWorkerBLL : BaseBLL<HCQ2_Model.T_UseWorker>,IT_UseWorkerBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IT_UseWorkerDAL;
		}
    }
	public partial class V_Auth_Per_00001_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_00001_System_BPM_Start>,IV_Auth_Per_00001_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_00001_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_00001_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_00001_System_Operation_Start>,IV_Auth_Per_00001_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_00001_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_00001_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_00001_System_Org_Tree>,IV_Auth_Per_00001_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_00001_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_00001_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_00001_System_Person_Readwrite>,IV_Auth_Per_00001_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_00001_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_00001_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_00001_System_PersonClass>,IV_Auth_Per_00001_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_00001_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_00002_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_00002_System_BPM_Start>,IV_Auth_Per_00002_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_00002_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_00002_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_00002_System_Operation_Start>,IV_Auth_Per_00002_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_00002_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_00002_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_00002_System_Org_Tree>,IV_Auth_Per_00002_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_00002_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_00002_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_00002_System_Person_Readwrite>,IV_Auth_Per_00002_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_00002_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_00002_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_00002_System_PersonClass>,IV_Auth_Per_00002_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_00002_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_anonymous_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_anonymous_System_BPM_Start>,IV_Auth_Per_anonymous_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_anonymous_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_anonymous_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_anonymous_System_Operation_Start>,IV_Auth_Per_anonymous_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_anonymous_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_anonymous_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_anonymous_System_Org_Tree>,IV_Auth_Per_anonymous_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_anonymous_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_anonymous_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_anonymous_System_Person_Readwrite>,IV_Auth_Per_anonymous_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_anonymous_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_anonymous_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_anonymous_System_PersonClass>,IV_Auth_Per_anonymous_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_anonymous_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000B_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000B_System_BPM_Start>,IV_Auth_Per_U00000B_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000B_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000B_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000B_System_Operation_Start>,IV_Auth_Per_U00000B_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000B_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000B_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000B_System_Org_Tree>,IV_Auth_Per_U00000B_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000B_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000B_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000B_System_Person_Readwrite>,IV_Auth_Per_U00000B_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000B_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000B_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000B_System_PersonClass>,IV_Auth_Per_U00000B_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000B_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000C_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000C_System_BPM_Start>,IV_Auth_Per_U00000C_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000C_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000C_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000C_System_Operation_Start>,IV_Auth_Per_U00000C_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000C_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000C_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000C_System_Org_Tree>,IV_Auth_Per_U00000C_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000C_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000C_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000C_System_Person_Readwrite>,IV_Auth_Per_U00000C_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000C_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000C_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000C_System_PersonClass>,IV_Auth_Per_U00000C_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000C_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000D_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000D_System_BPM_Start>,IV_Auth_Per_U00000D_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000D_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000D_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000D_System_Operation_Start>,IV_Auth_Per_U00000D_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000D_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000D_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000D_System_Org_Tree>,IV_Auth_Per_U00000D_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000D_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000D_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000D_System_Person_Readwrite>,IV_Auth_Per_U00000D_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000D_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000D_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000D_System_PersonClass>,IV_Auth_Per_U00000D_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000D_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000E_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000E_System_BPM_Start>,IV_Auth_Per_U00000E_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000E_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000E_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000E_System_Operation_Start>,IV_Auth_Per_U00000E_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000E_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000E_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000E_System_Org_Tree>,IV_Auth_Per_U00000E_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000E_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000E_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000E_System_Person_Readwrite>,IV_Auth_Per_U00000E_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000E_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000E_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000E_System_PersonClass>,IV_Auth_Per_U00000E_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000E_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000F_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000F_System_BPM_Start>,IV_Auth_Per_U00000F_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000F_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000F_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000F_System_Operation_Start>,IV_Auth_Per_U00000F_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000F_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000F_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000F_System_Org_Tree>,IV_Auth_Per_U00000F_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000F_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000F_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000F_System_Person_Readwrite>,IV_Auth_Per_U00000F_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000F_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000F_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000F_System_PersonClass>,IV_Auth_Per_U00000F_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000F_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000G_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000G_System_BPM_Start>,IV_Auth_Per_U00000G_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000G_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000G_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000G_System_Operation_Start>,IV_Auth_Per_U00000G_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000G_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000G_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000G_System_Org_Tree>,IV_Auth_Per_U00000G_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000G_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000G_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000G_System_Person_Readwrite>,IV_Auth_Per_U00000G_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000G_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000G_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000G_System_PersonClass>,IV_Auth_Per_U00000G_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000G_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000I_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000I_System_BPM_Start>,IV_Auth_Per_U00000I_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000I_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000I_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000I_System_Operation_Start>,IV_Auth_Per_U00000I_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000I_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000I_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000I_System_Org_Tree>,IV_Auth_Per_U00000I_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000I_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000I_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000I_System_Person_Readwrite>,IV_Auth_Per_U00000I_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000I_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000I_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000I_System_PersonClass>,IV_Auth_Per_U00000I_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000I_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000J_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000J_System_BPM_Start>,IV_Auth_Per_U00000J_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000J_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000J_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000J_System_Operation_Start>,IV_Auth_Per_U00000J_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000J_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000J_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000J_System_Org_Tree>,IV_Auth_Per_U00000J_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000J_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000J_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000J_System_Person_Readwrite>,IV_Auth_Per_U00000J_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000J_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000J_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000J_System_PersonClass>,IV_Auth_Per_U00000J_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000J_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000K_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000K_System_BPM_Start>,IV_Auth_Per_U00000K_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000K_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000K_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000K_System_Operation_Start>,IV_Auth_Per_U00000K_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000K_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000K_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000K_System_Org_Tree>,IV_Auth_Per_U00000K_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000K_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000K_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000K_System_Person_Readwrite>,IV_Auth_Per_U00000K_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000K_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000K_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000K_System_PersonClass>,IV_Auth_Per_U00000K_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000K_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000L_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000L_System_BPM_Start>,IV_Auth_Per_U00000L_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000L_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000L_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000L_System_Operation_Start>,IV_Auth_Per_U00000L_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000L_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000L_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000L_System_Org_Tree>,IV_Auth_Per_U00000L_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000L_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000L_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000L_System_Person_Readwrite>,IV_Auth_Per_U00000L_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000L_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000L_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000L_System_PersonClass>,IV_Auth_Per_U00000L_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000L_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000M_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000M_System_BPM_Start>,IV_Auth_Per_U00000M_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000M_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000M_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000M_System_Operation_Start>,IV_Auth_Per_U00000M_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000M_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000M_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000M_System_Org_Tree>,IV_Auth_Per_U00000M_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000M_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000M_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000M_System_Person_Readwrite>,IV_Auth_Per_U00000M_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000M_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000M_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000M_System_PersonClass>,IV_Auth_Per_U00000M_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000M_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000O_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000O_System_BPM_Start>,IV_Auth_Per_U00000O_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000O_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000O_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000O_System_Operation_Start>,IV_Auth_Per_U00000O_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000O_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000O_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000O_System_Org_Tree>,IV_Auth_Per_U00000O_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000O_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000O_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000O_System_Person_Readwrite>,IV_Auth_Per_U00000O_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000O_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000O_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000O_System_PersonClass>,IV_Auth_Per_U00000O_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000O_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000P_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000P_System_BPM_Start>,IV_Auth_Per_U00000P_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000P_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000P_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000P_System_Operation_Start>,IV_Auth_Per_U00000P_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000P_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000P_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000P_System_Org_Tree>,IV_Auth_Per_U00000P_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000P_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000P_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000P_System_Person_Readwrite>,IV_Auth_Per_U00000P_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000P_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000P_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000P_System_PersonClass>,IV_Auth_Per_U00000P_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000P_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000R_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000R_System_BPM_Start>,IV_Auth_Per_U00000R_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000R_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000R_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000R_System_Operation_Start>,IV_Auth_Per_U00000R_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000R_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000R_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000R_System_Org_Tree>,IV_Auth_Per_U00000R_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000R_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000R_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000R_System_Person_Readwrite>,IV_Auth_Per_U00000R_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000R_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000R_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000R_System_PersonClass>,IV_Auth_Per_U00000R_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000R_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000S_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000S_System_BPM_Start>,IV_Auth_Per_U00000S_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000S_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000S_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000S_System_Operation_Start>,IV_Auth_Per_U00000S_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000S_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000S_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000S_System_Org_Tree>,IV_Auth_Per_U00000S_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000S_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000S_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000S_System_Person_Readwrite>,IV_Auth_Per_U00000S_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000S_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000S_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000S_System_PersonClass>,IV_Auth_Per_U00000S_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000S_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000T_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000T_System_BPM_Start>,IV_Auth_Per_U00000T_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000T_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000T_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000T_System_Operation_Start>,IV_Auth_Per_U00000T_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000T_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000T_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000T_System_Org_Tree>,IV_Auth_Per_U00000T_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000T_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000T_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000T_System_Person_Readwrite>,IV_Auth_Per_U00000T_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000T_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000T_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000T_System_PersonClass>,IV_Auth_Per_U00000T_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000T_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000U_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000U_System_BPM_Start>,IV_Auth_Per_U00000U_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000U_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000U_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000U_System_Operation_Start>,IV_Auth_Per_U00000U_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000U_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000U_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000U_System_Org_Tree>,IV_Auth_Per_U00000U_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000U_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000U_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000U_System_Person_Readwrite>,IV_Auth_Per_U00000U_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000U_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000U_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000U_System_PersonClass>,IV_Auth_Per_U00000U_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000U_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000V_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000V_System_BPM_Start>,IV_Auth_Per_U00000V_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000V_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000V_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000V_System_Operation_Start>,IV_Auth_Per_U00000V_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000V_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000V_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000V_System_Org_Tree>,IV_Auth_Per_U00000V_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000V_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000V_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000V_System_Person_Readwrite>,IV_Auth_Per_U00000V_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000V_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000V_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000V_System_PersonClass>,IV_Auth_Per_U00000V_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000V_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000X_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000X_System_BPM_Start>,IV_Auth_Per_U00000X_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000X_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000X_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000X_System_Operation_Start>,IV_Auth_Per_U00000X_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000X_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000X_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000X_System_Org_Tree>,IV_Auth_Per_U00000X_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000X_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000X_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000X_System_Person_Readwrite>,IV_Auth_Per_U00000X_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000X_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000X_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000X_System_PersonClass>,IV_Auth_Per_U00000X_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000X_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000Y_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000Y_System_BPM_Start>,IV_Auth_Per_U00000Y_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000Y_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000Y_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000Y_System_Operation_Start>,IV_Auth_Per_U00000Y_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000Y_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000Y_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000Y_System_Org_Tree>,IV_Auth_Per_U00000Y_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000Y_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000Y_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000Y_System_Person_Readwrite>,IV_Auth_Per_U00000Y_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000Y_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000Y_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000Y_System_PersonClass>,IV_Auth_Per_U00000Y_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000Y_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U00000Z_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000Z_System_BPM_Start>,IV_Auth_Per_U00000Z_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000Z_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000Z_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000Z_System_Operation_Start>,IV_Auth_Per_U00000Z_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000Z_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U00000Z_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000Z_System_Org_Tree>,IV_Auth_Per_U00000Z_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000Z_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U00000Z_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000Z_System_Person_Readwrite>,IV_Auth_Per_U00000Z_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000Z_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U00000Z_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U00000Z_System_PersonClass>,IV_Auth_Per_U00000Z_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U00000Z_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U000010_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000010_System_BPM_Start>,IV_Auth_Per_U000010_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000010_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U000010_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000010_System_Operation_Start>,IV_Auth_Per_U000010_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000010_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U000010_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000010_System_Org_Tree>,IV_Auth_Per_U000010_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000010_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U000010_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000010_System_Person_Readwrite>,IV_Auth_Per_U000010_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000010_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U000010_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000010_System_PersonClass>,IV_Auth_Per_U000010_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000010_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U000011_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000011_System_BPM_Start>,IV_Auth_Per_U000011_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000011_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U000011_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000011_System_Operation_Start>,IV_Auth_Per_U000011_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000011_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U000011_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000011_System_Org_Tree>,IV_Auth_Per_U000011_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000011_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U000011_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000011_System_Person_Readwrite>,IV_Auth_Per_U000011_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000011_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U000011_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000011_System_PersonClass>,IV_Auth_Per_U000011_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000011_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U000012_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000012_System_BPM_Start>,IV_Auth_Per_U000012_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000012_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U000012_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000012_System_Operation_Start>,IV_Auth_Per_U000012_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000012_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U000012_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000012_System_Org_Tree>,IV_Auth_Per_U000012_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000012_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U000012_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000012_System_Person_Readwrite>,IV_Auth_Per_U000012_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000012_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U000012_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000012_System_PersonClass>,IV_Auth_Per_U000012_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000012_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U000014_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000014_System_BPM_Start>,IV_Auth_Per_U000014_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000014_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U000014_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000014_System_Operation_Start>,IV_Auth_Per_U000014_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000014_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U000014_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000014_System_Org_Tree>,IV_Auth_Per_U000014_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000014_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U000014_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000014_System_Person_Readwrite>,IV_Auth_Per_U000014_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000014_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U000014_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000014_System_PersonClass>,IV_Auth_Per_U000014_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000014_System_PersonClassDAL;
		}
    }
	public partial class V_Auth_Per_U000015_System_BPM_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000015_System_BPM_Start>,IV_Auth_Per_U000015_System_BPM_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000015_System_BPM_StartDAL;
		}
    }
	public partial class V_Auth_Per_U000015_System_Operation_StartBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000015_System_Operation_Start>,IV_Auth_Per_U000015_System_Operation_StartBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000015_System_Operation_StartDAL;
		}
    }
	public partial class V_Auth_Per_U000015_System_Org_TreeBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000015_System_Org_Tree>,IV_Auth_Per_U000015_System_Org_TreeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000015_System_Org_TreeDAL;
		}
    }
	public partial class V_Auth_Per_U000015_System_Person_ReadwriteBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000015_System_Person_Readwrite>,IV_Auth_Per_U000015_System_Person_ReadwriteBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000015_System_Person_ReadwriteDAL;
		}
    }
	public partial class V_Auth_Per_U000015_System_PersonClassBLL : BaseBLL<HCQ2_Model.V_Auth_Per_U000015_System_PersonClass>,IV_Auth_Per_U000015_System_PersonClassBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_Auth_Per_U000015_System_PersonClassDAL;
		}
    }
	public partial class V_My_WidgetModule_ObjectsBLL : BaseBLL<HCQ2_Model.V_My_WidgetModule_Objects>,IV_My_WidgetModule_ObjectsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IV_My_WidgetModule_ObjectsDAL;
		}
    }
	public partial class View_A02BLL : BaseBLL<HCQ2_Model.View_A02>,IView_A02BLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IView_A02DAL;
		}
    }
	public partial class View_Auth_UserBLL : BaseBLL<HCQ2_Model.View_Auth_User>,IView_Auth_UserBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IView_Auth_UserDAL;
		}
    }
	public partial class View_CatalogDocumentBLL : BaseBLL<HCQ2_Model.View_CatalogDocument>,IView_CatalogDocumentBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IView_CatalogDocumentDAL;
		}
    }
	public partial class View_Com_JetTableItemsBLL : BaseBLL<HCQ2_Model.View_Com_JetTableItems>,IView_Com_JetTableItemsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IView_Com_JetTableItemsDAL;
		}
    }
	public partial class View_QXTJBLL : BaseBLL<HCQ2_Model.View_QXTJ>,IView_QXTJBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IView_QXTJDAL;
		}
    }
	public partial class WF_JobMainBLL : BaseBLL<HCQ2_Model.WF_JobMain>,IWF_JobMainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_JobMainDAL;
		}
    }
	public partial class WF_JobMainExcludeChooseBLL : BaseBLL<HCQ2_Model.WF_JobMainExcludeChoose>,IWF_JobMainExcludeChooseBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_JobMainExcludeChooseDAL;
		}
    }
	public partial class WF_JobOpinionBLL : BaseBLL<HCQ2_Model.WF_JobOpinion>,IWF_JobOpinionBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_JobOpinionDAL;
		}
    }
	public partial class WF_JobProxyBLL : BaseBLL<HCQ2_Model.WF_JobProxy>,IWF_JobProxyBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_JobProxyDAL;
		}
    }
	public partial class WF_JobSaveOrgBLL : BaseBLL<HCQ2_Model.WF_JobSaveOrg>,IWF_JobSaveOrgBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_JobSaveOrgDAL;
		}
    }
	public partial class WF_JobStepBLL : BaseBLL<HCQ2_Model.WF_JobStep>,IWF_JobStepBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_JobStepDAL;
		}
    }
	public partial class WF_OperationCalcBLL : BaseBLL<HCQ2_Model.WF_OperationCalc>,IWF_OperationCalcBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationCalcDAL;
		}
    }
	public partial class WF_OperationDocumentBLL : BaseBLL<HCQ2_Model.WF_OperationDocument>,IWF_OperationDocumentBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationDocumentDAL;
		}
    }
	public partial class WF_OperationGroupBLL : BaseBLL<HCQ2_Model.WF_OperationGroup>,IWF_OperationGroupBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationGroupDAL;
		}
    }
	public partial class WF_OperationKeyValueBLL : BaseBLL<HCQ2_Model.WF_OperationKeyValue>,IWF_OperationKeyValueBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationKeyValueDAL;
		}
    }
	public partial class WF_OperationMainBLL : BaseBLL<HCQ2_Model.WF_OperationMain>,IWF_OperationMainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationMainDAL;
		}
    }
	public partial class WF_OperationOutPutBLL : BaseBLL<HCQ2_Model.WF_OperationOutPut>,IWF_OperationOutPutBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationOutPutDAL;
		}
    }
	public partial class WF_OperationSalaryOPItemBLL : BaseBLL<HCQ2_Model.WF_OperationSalaryOPItem>,IWF_OperationSalaryOPItemBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationSalaryOPItemDAL;
		}
    }
	public partial class WF_OperationSalaryOPMainBLL : BaseBLL<HCQ2_Model.WF_OperationSalaryOPMain>,IWF_OperationSalaryOPMainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationSalaryOPMainDAL;
		}
    }
	public partial class WF_OperationSalaryOPSignItemBLL : BaseBLL<HCQ2_Model.WF_OperationSalaryOPSignItem>,IWF_OperationSalaryOPSignItemBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationSalaryOPSignItemDAL;
		}
    }
	public partial class WF_OperationSalaryOPSignMainBLL : BaseBLL<HCQ2_Model.WF_OperationSalaryOPSignMain>,IWF_OperationSalaryOPSignMainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationSalaryOPSignMainDAL;
		}
    }
	public partial class WF_OperationSetItemOptionBLL : BaseBLL<HCQ2_Model.WF_OperationSetItemOption>,IWF_OperationSetItemOptionBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationSetItemOptionDAL;
		}
    }
	public partial class WF_OperationSetItemsBLL : BaseBLL<HCQ2_Model.WF_OperationSetItems>,IWF_OperationSetItemsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationSetItemsDAL;
		}
    }
	public partial class WF_OperationSetTableBLL : BaseBLL<HCQ2_Model.WF_OperationSetTable>,IWF_OperationSetTableBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationSetTableDAL;
		}
    }
	public partial class WF_OperationSetTableOptionBLL : BaseBLL<HCQ2_Model.WF_OperationSetTableOption>,IWF_OperationSetTableOptionBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationSetTableOptionDAL;
		}
    }
	public partial class WF_OperationSTCodeItemsBLL : BaseBLL<HCQ2_Model.WF_OperationSTCodeItems>,IWF_OperationSTCodeItemsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationSTCodeItemsDAL;
		}
    }
	public partial class WF_OperationSTDataBLL : BaseBLL<HCQ2_Model.WF_OperationSTData>,IWF_OperationSTDataBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationSTDataDAL;
		}
    }
	public partial class WF_OperationStepBLL : BaseBLL<HCQ2_Model.WF_OperationStep>,IWF_OperationStepBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationStepDAL;
		}
    }
	public partial class WF_OperationStepPrivilegeBLL : BaseBLL<HCQ2_Model.WF_OperationStepPrivilege>,IWF_OperationStepPrivilegeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationStepPrivilegeDAL;
		}
    }
	public partial class WF_OperationSTMainBLL : BaseBLL<HCQ2_Model.WF_OperationSTMain>,IWF_OperationSTMainBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationSTMainDAL;
		}
    }
	public partial class WF_OperationSTSetItemsBLL : BaseBLL<HCQ2_Model.WF_OperationSTSetItems>,IWF_OperationSTSetItemsBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationSTSetItemsDAL;
		}
    }
	public partial class WF_OperationTypeBLL : BaseBLL<HCQ2_Model.WF_OperationType>,IWF_OperationTypeBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWF_OperationTypeDAL;
		}
    }
	public partial class WGJG_GRZXBLL : BaseBLL<HCQ2_Model.WGJG_GRZX>,IWGJG_GRZXBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWGJG_GRZXDAL;
		}
    }
	public partial class WGJG_WarnDataBLL : BaseBLL<HCQ2_Model.WGJG_WarnData>,IWGJG_WarnDataBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWGJG_WarnDataDAL;
		}
    }
	public partial class WGJG_ZXBLL : BaseBLL<HCQ2_Model.WGJG_ZX>,IWGJG_ZXBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWGJG_ZXDAL;
		}
    }
	public partial class WGJG01BLL : BaseBLL<HCQ2_Model.WGJG01>,IWGJG01BLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWGJG01DAL;
		}
    }
	public partial class WGJG01_TemplateBLL : BaseBLL<HCQ2_Model.WGJG01_Template>,IWGJG01_TemplateBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWGJG01_TemplateDAL;
		}
    }
	public partial class WGJG02BLL : BaseBLL<HCQ2_Model.WGJG02>,IWGJG02BLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWGJG02DAL;
		}
    }
	public partial class WGJG02_TemplateBLL : BaseBLL<HCQ2_Model.WGJG02_Template>,IWGJG02_TemplateBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IWGJG02_TemplateDAL;
		}
    }
	public partial class XS_StudentBLL : BaseBLL<HCQ2_Model.XS_Student>,IXS_StudentBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IXS_StudentDAL;
		}
    }
	public partial class XS_StudentScoreBLL : BaseBLL<HCQ2_Model.XS_StudentScore>,IXS_StudentScoreBLL
    {
		public override void SetDal()
		{
			Dal = DBSession.IXS_StudentScoreDAL;
		}
    }
}