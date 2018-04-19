﻿
    using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Text;
   namespace HCQ2_IDAL
   {
   public partial interface IDBSession
   {
   		IA01DAL IA01DAL{get;set;}
				IA02DAL IA02DAL{get;set;}
				IA03DAL IA03DAL{get;set;}
				IA04DAL IA04DAL{get;set;}
				IA19DAL IA19DAL{get;set;}
				IATTACHJOBDAL IATTACHJOBDAL{get;set;}
				IAuth_Define_DataScopeDAL IAuth_Define_DataScopeDAL{get;set;}
				IAuth_Define_DataScopeItemDAL IAuth_Define_DataScopeItemDAL{get;set;}
				IAuth_Define_FuncDAL IAuth_Define_FuncDAL{get;set;}
				IAuth_Define_SetDBDAL IAuth_Define_SetDBDAL{get;set;}
				IAuth_Define_SetItemDAL IAuth_Define_SetItemDAL{get;set;}
				IAuth_Define_SetTableDAL IAuth_Define_SetTableDAL{get;set;}
				IAuth_OrgRoleDAL IAuth_OrgRoleDAL{get;set;}
				IAuth_PermissionDAL IAuth_PermissionDAL{get;set;}
				IAuth_PermissionScopeDAL IAuth_PermissionScopeDAL{get;set;}
				IAuth_RoleDAL IAuth_RoleDAL{get;set;}
				IAuth_SecretLoginDAL IAuth_SecretLoginDAL{get;set;}
				IAuth_UserDAL IAuth_UserDAL{get;set;}
				IAuth_UserGroupDAL IAuth_UserGroupDAL{get;set;}
				IAuth_UserGroupRoleDAL IAuth_UserGroupRoleDAL{get;set;}
				IAuth_UserLogonDAL IAuth_UserLogonDAL{get;set;}
				IAuth_UserRoleDAL IAuth_UserRoleDAL{get;set;}
				IAuth_UserWeixinDAL IAuth_UserWeixinDAL{get;set;}
				IB01DAL IB01DAL{get;set;}
				IBB_CashDetailDAL IBB_CashDetailDAL{get;set;}
				IBB_DWDAL IBB_DWDAL{get;set;}
				IBB_DWLevelDAL IBB_DWLevelDAL{get;set;}
				IBB_DWLevelUserDAL IBB_DWLevelUserDAL{get;set;}
				IBB_DWStateDAL IBB_DWStateDAL{get;set;}
				IBB_DWStateCheckResultDAL IBB_DWStateCheckResultDAL{get;set;}
				IBB_DWTotalDAL IBB_DWTotalDAL{get;set;}
				IBB_FacilityPreserveDAL IBB_FacilityPreserveDAL{get;set;}
				IBB_FetchDataSetupDAL IBB_FetchDataSetupDAL{get;set;}
				IBB_FetchFCDAL IBB_FetchFCDAL{get;set;}
				IBB_FetchNumberFuncDAL IBB_FetchNumberFuncDAL{get;set;}
				IBB_FetchPoolLogDAL IBB_FetchPoolLogDAL{get;set;}
				IBB_InternalReciveLogDAL IBB_InternalReciveLogDAL{get;set;}
				IBB_InternalSendDAL IBB_InternalSendDAL{get;set;}
				IBB_ItemPreserveDAL IBB_ItemPreserveDAL{get;set;}
				IBB_PactDetailFlieDAL IBB_PactDetailFlieDAL{get;set;}
				IBB_ServiceUserDAL IBB_ServiceUserDAL{get;set;}
				IBB_SJ_DataSpecialDAL IBB_SJ_DataSpecialDAL{get;set;}
				IBB_SJ_NoteFloatDAL IBB_SJ_NoteFloatDAL{get;set;}
				IBB_SJ_NoteTextDAL IBB_SJ_NoteTextDAL{get;set;}
				IBB_TBDAL IBB_TBDAL{get;set;}
				IBB_TBClassDAL IBB_TBClassDAL{get;set;}
				IBB_TBDataHintDAL IBB_TBDataHintDAL{get;set;}
				IBB_TBItemsDAL IBB_TBItemsDAL{get;set;}
				IBB_TBRemarkUserLevelDAL IBB_TBRemarkUserLevelDAL{get;set;}
				IBB_TBRemarkUsersDAL IBB_TBRemarkUsersDAL{get;set;}
				IBB_TotalFCDAL IBB_TotalFCDAL{get;set;}
				IBB_TrackRecordDAL IBB_TrackRecordDAL{get;set;}
				IBB_TypeDAL IBB_TypeDAL{get;set;}
				IBB_TypeCycleDAL IBB_TypeCycleDAL{get;set;}
				IBB_UpDataLogDAL IBB_UpDataLogDAL{get;set;}
				IBB_ZBDAL IBB_ZBDAL{get;set;}
				IBB_ZBConditionDAL IBB_ZBConditionDAL{get;set;}
				IBB_ZBVarItemsDAL IBB_ZBVarItemsDAL{get;set;}
				IBMQ_DocumentDAL IBMQ_DocumentDAL{get;set;}
				IBPM_AgencyRuleDAL IBPM_AgencyRuleDAL{get;set;}
				IBPM_AgencyRuleAssigneeDAL IBPM_AgencyRuleAssigneeDAL{get;set;}
				IBPM_AgencyRuleProcessDAL IBPM_AgencyRuleProcessDAL{get;set;}
				IBPM_D_AskForLeaveDemo_MainDAL IBPM_D_AskForLeaveDemo_MainDAL{get;set;}
				IBPM_D_Leave_MainDAL IBPM_D_Leave_MainDAL{get;set;}
				IBPM_D_NewEmployees_MainDAL IBPM_D_NewEmployees_MainDAL{get;set;}
				IBPM_Define_ActionListenerDAL IBPM_Define_ActionListenerDAL{get;set;}
				IBPM_Define_ActorAdapterDAL IBPM_Define_ActorAdapterDAL{get;set;}
				IBPM_Define_ActorAdapter_bakDAL IBPM_Define_ActorAdapter_bakDAL{get;set;}
				IBPM_Define_CatalogDAL IBPM_Define_CatalogDAL{get;set;}
				IBPM_Define_ConstDAL IBPM_Define_ConstDAL{get;set;}
				IBPM_Define_DataModelDAL IBPM_Define_DataModelDAL{get;set;}
				IBPM_Define_FormDAL IBPM_Define_FormDAL{get;set;}
				IBPM_Define_PackageDAL IBPM_Define_PackageDAL{get;set;}
				IBPM_Define_ProcessDraftDAL IBPM_Define_ProcessDraftDAL{get;set;}
				IBPM_Define_ProcessPublishedDAL IBPM_Define_ProcessPublishedDAL{get;set;}
				IBPM_Define_SchemeDAL IBPM_Define_SchemeDAL{get;set;}
				IBPM_Run_InstanceDAL IBPM_Run_InstanceDAL{get;set;}
				IBPM_Run_ProcessLogDAL IBPM_Run_ProcessLogDAL{get;set;}
				IBPM_Run_SchemeJobDAL IBPM_Run_SchemeJobDAL{get;set;}
				IBPM_Run_SharedTaskDAL IBPM_Run_SharedTaskDAL{get;set;}
				IBPM_Run_TrackingDAL IBPM_Run_TrackingDAL{get;set;}
				IBPM_Run_UrgedDAL IBPM_Run_UrgedDAL{get;set;}
				IBPM_Run_VariableDAL IBPM_Run_VariableDAL{get;set;}
				IBPM_Run_WorkTaskDAL IBPM_Run_WorkTaskDAL{get;set;}
				IBPM_Run_WorkTaskOpinionDAL IBPM_Run_WorkTaskOpinionDAL{get;set;}
				IBPM_UserExtInfoDAL IBPM_UserExtInfoDAL{get;set;}
				IBPM_UsuallyOpinionDAL IBPM_UsuallyOpinionDAL{get;set;}
				ICache_BlobInfoDAL ICache_BlobInfoDAL{get;set;}
				ICache_StatDataDAL ICache_StatDataDAL{get;set;}
				ICom_CatalogDAL ICom_CatalogDAL{get;set;}
				ICom_FormulaDAL ICom_FormulaDAL{get;set;}
				ICom_JetTableItemsDAL ICom_JetTableItemsDAL{get;set;}
				ICom_JetTableMainDAL ICom_JetTableMainDAL{get;set;}
				ICom_LimitItemsDAL ICom_LimitItemsDAL{get;set;}
				ICom_LimitMainDAL ICom_LimitMainDAL{get;set;}
				ICom_MusterSimpleDAL ICom_MusterSimpleDAL{get;set;}
				ICom_MusterSimpleFieldsDAL ICom_MusterSimpleFieldsDAL{get;set;}
				ICom_RelationBodyDAL ICom_RelationBodyDAL{get;set;}
				ICom_RelationMainDAL ICom_RelationMainDAL{get;set;}
				ICom_SortItemsDAL ICom_SortItemsDAL{get;set;}
				ICom_SortMainDAL ICom_SortMainDAL{get;set;}
				ICom_StatAnalysisItemsDAL ICom_StatAnalysisItemsDAL{get;set;}
				ICom_StatAnalysisMainDAL ICom_StatAnalysisMainDAL{get;set;}
				ICom_StatLimitColumnsDAL ICom_StatLimitColumnsDAL{get;set;}
				ICom_StatLimitMainDAL ICom_StatLimitMainDAL{get;set;}
				ICom_StatLimitRowsDAL ICom_StatLimitRowsDAL{get;set;}
				IG01DAL IG01DAL{get;set;}
				IHR_MusterFieldsDAL IHR_MusterFieldsDAL{get;set;}
				IHR_MusterMainDAL IHR_MusterMainDAL{get;set;}
				IOP_ExcelForm_ArgsDAL IOP_ExcelForm_ArgsDAL{get;set;}
				IOP_ExcelForm_CatalogDAL IOP_ExcelForm_CatalogDAL{get;set;}
				IOP_ExcelForm_CellDAL IOP_ExcelForm_CellDAL{get;set;}
				IOP_ExcelForm_ColDAL IOP_ExcelForm_ColDAL{get;set;}
				IOP_ExcelForm_DataSourceDAL IOP_ExcelForm_DataSourceDAL{get;set;}
				IOP_ExcelForm_DataSourceParseDAL IOP_ExcelForm_DataSourceParseDAL{get;set;}
				IOP_ExcelForm_InputDAL IOP_ExcelForm_InputDAL{get;set;}
				IOP_ExcelForm_InputTableDAL IOP_ExcelForm_InputTableDAL{get;set;}
				IOP_ExcelForm_InputTableFieldDAL IOP_ExcelForm_InputTableFieldDAL{get;set;}
				IOP_ExcelForm_MainDAL IOP_ExcelForm_MainDAL{get;set;}
				IOP_ExcelForm_PrivilegeDAL IOP_ExcelForm_PrivilegeDAL{get;set;}
				IOP_ExcelForm_RowDAL IOP_ExcelForm_RowDAL{get;set;}
				IOP_ExcelForm_RowColDAL IOP_ExcelForm_RowColDAL{get;set;}
				IProject_LogApiDAL IProject_LogApiDAL{get;set;}
				IRC_DataHintDAL IRC_DataHintDAL{get;set;}
				IRC_DataHintStateDAL IRC_DataHintStateDAL{get;set;}
				IRC_DataLimitDAL IRC_DataLimitDAL{get;set;}
				IRC_ImportClientDataWayDAL IRC_ImportClientDataWayDAL{get;set;}
				IRC_InfoScriptDAL IRC_InfoScriptDAL{get;set;}
				IRC_InfoScriptOrderDAL IRC_InfoScriptOrderDAL{get;set;}
				IRC_JTMainDAL IRC_JTMainDAL{get;set;}
				IRC_MusterMainDAL IRC_MusterMainDAL{get;set;}
				IRC_PolicyAttachDAL IRC_PolicyAttachDAL{get;set;}
				IRC_PolicyDetailDAL IRC_PolicyDetailDAL{get;set;}
				IRC_PolicyGroupDAL IRC_PolicyGroupDAL{get;set;}
				IRC_SearchContainerResultDAL IRC_SearchContainerResultDAL{get;set;}
				IRC_StatMainDAL IRC_StatMainDAL{get;set;}
				IRC_StatMusterFieldDAL IRC_StatMusterFieldDAL{get;set;}
				ISM_CodeItemsDAL ISM_CodeItemsDAL{get;set;}
				ISM_CodeTableDAL ISM_CodeTableDAL{get;set;}
				ISM_CodeTableGroupDAL ISM_CodeTableGroupDAL{get;set;}
				ISM_ConsoleUIGroupDAL ISM_ConsoleUIGroupDAL{get;set;}
				ISM_ConsoleUIItemDAL ISM_ConsoleUIItemDAL{get;set;}
				ISM_ConsoleUIWayDAL ISM_ConsoleUIWayDAL{get;set;}
				ISM_ConsoleUIWayRoleDAL ISM_ConsoleUIWayRoleDAL{get;set;}
				ISM_DBConnectionDAL ISM_DBConnectionDAL{get;set;}
				ISM_GlobalScriptDAL ISM_GlobalScriptDAL{get;set;}
				ISM_IdentityDAL ISM_IdentityDAL{get;set;}
				ISM_LogDAL ISM_LogDAL{get;set;}
				ISM_LogCycleTimerDAL ISM_LogCycleTimerDAL{get;set;}
				ISM_LogDevelopDAL ISM_LogDevelopDAL{get;set;}
				ISM_LogSystemDAL ISM_LogSystemDAL{get;set;}
				ISM_PersonClassDAL ISM_PersonClassDAL{get;set;}
				ISM_PluginDAL ISM_PluginDAL{get;set;}
				ISM_Prototype_SimpleDAL ISM_Prototype_SimpleDAL{get;set;}
				ISM_PYDAL ISM_PYDAL{get;set;}
				ISM_SchedulerDAL ISM_SchedulerDAL{get;set;}
				ISM_SchedulerNotifyDAL ISM_SchedulerNotifyDAL{get;set;}
				ISM_SchedulerPlanDAL ISM_SchedulerPlanDAL{get;set;}
				ISM_SchedulerRunLogDAL ISM_SchedulerRunLogDAL{get;set;}
				ISM_SchedulerTaskDAL ISM_SchedulerTaskDAL{get;set;}
				ISM_SequenceManageDAL ISM_SequenceManageDAL{get;set;}
				ISM_SetDBDAL ISM_SetDBDAL{get;set;}
				ISM_SetItemCalcDAL ISM_SetItemCalcDAL{get;set;}
				ISM_SetItemsDAL ISM_SetItemsDAL{get;set;}
				ISM_SetItemUserConfigDAL ISM_SetItemUserConfigDAL{get;set;}
				ISM_SetTableDAL ISM_SetTableDAL{get;set;}
				ISM_SetTableUserConfigDAL ISM_SetTableUserConfigDAL{get;set;}
				ISM_SetWayUserConfigDAL ISM_SetWayUserConfigDAL{get;set;}
				ISM_SqlTemplet_ArgsDAL ISM_SqlTemplet_ArgsDAL{get;set;}
				ISM_SqlTemplet_CatalogDAL ISM_SqlTemplet_CatalogDAL{get;set;}
				ISM_SqlTemplet_MainDAL ISM_SqlTemplet_MainDAL{get;set;}
				ISM_Stamp_UnitDAL ISM_Stamp_UnitDAL{get;set;}
				ISM_Stamp_UnitUserDAL ISM_Stamp_UnitUserDAL{get;set;}
				ISM_SystemKeyValueDAL ISM_SystemKeyValueDAL{get;set;}
				ISM_SystemMessageDAL ISM_SystemMessageDAL{get;set;}
				ISM_SystemModuleKeyFileDAL ISM_SystemModuleKeyFileDAL{get;set;}
				ISM_SystemModuleKeyValueDAL ISM_SystemModuleKeyValueDAL{get;set;}
				ISM_Theme_ConfigV2DAL ISM_Theme_ConfigV2DAL{get;set;}
				ISM_Theme_ConfigV2_FileDAL ISM_Theme_ConfigV2_FileDAL{get;set;}
				ISM_Theme_ConfigV2_RoleDAL ISM_Theme_ConfigV2_RoleDAL{get;set;}
				ISM_Todo_DataWarnDAL ISM_Todo_DataWarnDAL{get;set;}
				ISM_Todo_NoticeDAL ISM_Todo_NoticeDAL{get;set;}
				ISM_UserKeyValueDAL ISM_UserKeyValueDAL{get;set;}
				ISM_UserKeyValueExDAL ISM_UserKeyValueExDAL{get;set;}
				ISM_UserOnlineLoggerDAL ISM_UserOnlineLoggerDAL{get;set;}
				ISM_UserRelationDAL ISM_UserRelationDAL{get;set;}
				ISM_UserRelationItemDAL ISM_UserRelationItemDAL{get;set;}
				ISM_VersionDAL ISM_VersionDAL{get;set;}
				ISM_Weixin_SystemConfigDAL ISM_Weixin_SystemConfigDAL{get;set;}
				ISM_WidgetHomepage_MainDAL ISM_WidgetHomepage_MainDAL{get;set;}
				ISM_WidgetHomepage_UserConfigDAL ISM_WidgetHomepage_UserConfigDAL{get;set;}
				ISM_WidgetModule_ArgsDAL ISM_WidgetModule_ArgsDAL{get;set;}
				ISM_WidgetModule_CatalogDAL ISM_WidgetModule_CatalogDAL{get;set;}
				ISM_WidgetModule_FilesDAL ISM_WidgetModule_FilesDAL{get;set;}
				ISM_WidgetModule_MainDAL ISM_WidgetModule_MainDAL{get;set;}
				ISM_WidgetModule_ObjectConfigDAL ISM_WidgetModule_ObjectConfigDAL{get;set;}
				ISM_WidgetModule_ToolDAL ISM_WidgetModule_ToolDAL{get;set;}
				ISM_WidgetModule_ToolBarDAL ISM_WidgetModule_ToolBarDAL{get;set;}
				IsysdiagramsDAL IsysdiagramsDAL{get;set;}
				IT_AreaInfoDAL IT_AreaInfoDAL{get;set;}
				IT_AreaPermissRelationDAL IT_AreaPermissRelationDAL{get;set;}
				IT_AskManagerDAL IT_AskManagerDAL{get;set;}
				IT_B01PermissRelationDAL IT_B01PermissRelationDAL{get;set;}
				IT_ComplaintsDAL IT_ComplaintsDAL{get;set;}
				IT_CompProInfoDAL IT_CompProInfoDAL{get;set;}
				IT_DocFolderPermissRelationDAL IT_DocFolderPermissRelationDAL{get;set;}
				IT_DocumentFolderDAL IT_DocumentFolderDAL{get;set;}
				IT_DocumentFolderRelationDAL IT_DocumentFolderRelationDAL{get;set;}
				IT_DocumentInfoDAL IT_DocumentInfoDAL{get;set;}
				IT_DocumentSetTypeDAL IT_DocumentSetTypeDAL{get;set;}
				IT_ElementPermissRelationDAL IT_ElementPermissRelationDAL{get;set;}
				IT_EnterDetailDAL IT_EnterDetailDAL{get;set;}
				IT_EquipmentDAL IT_EquipmentDAL{get;set;}
				IT_ExceptionLogDAL IT_ExceptionLogDAL{get;set;}
				IT_FilePermissRelationDAL IT_FilePermissRelationDAL{get;set;}
				IT_FolderPermissRelationDAL IT_FolderPermissRelationDAL{get;set;}
				IT_FunctionDAL IT_FunctionDAL{get;set;}
				IT_ImplementDAL IT_ImplementDAL{get;set;}
				IT_ItemCodeDAL IT_ItemCodeDAL{get;set;}
				IT_ItemCodeMenumDAL IT_ItemCodeMenumDAL{get;set;}
				IT_JobResumeRelationDAL IT_JobResumeRelationDAL{get;set;}
				IT_LimitUserDAL IT_LimitUserDAL{get;set;}
				IT_LoginDAL IT_LoginDAL{get;set;}
				IT_LogSetingDAL IT_LogSetingDAL{get;set;}
				IT_LogSetingDetailDAL IT_LogSetingDetailDAL{get;set;}
				IT_MessageNoticeDAL IT_MessageNoticeDAL{get;set;}
				IT_ModulePermissRelationDAL IT_ModulePermissRelationDAL{get;set;}
				IT_Org_UserDAL IT_Org_UserDAL{get;set;}
				IT_OrgFolderDAL IT_OrgFolderDAL{get;set;}
				IT_OrgUserRelationDAL IT_OrgUserRelationDAL{get;set;}
				IT_PageElementDAL IT_PageElementDAL{get;set;}
				IT_PageFileDAL IT_PageFileDAL{get;set;}
				IT_PageFolderDAL IT_PageFolderDAL{get;set;}
				IT_PayAccountDAL IT_PayAccountDAL{get;set;}
				IT_PerFuncRelationDAL IT_PerFuncRelationDAL{get;set;}
				IT_PermissConfigDAL IT_PermissConfigDAL{get;set;}
				IT_PermissionsDAL IT_PermissionsDAL{get;set;}
				IT_RoleDAL IT_RoleDAL{get;set;}
				IT_RoleGroupRelationDAL IT_RoleGroupRelationDAL{get;set;}
				IT_RolePermissRelationDAL IT_RolePermissRelationDAL{get;set;}
				IT_SetMainPageDAL IT_SetMainPageDAL{get;set;}
				IT_SynchronousDAL IT_SynchronousDAL{get;set;}
				IT_SysModuleDAL IT_SysModuleDAL{get;set;}
				IT_TableDAL IT_TableDAL{get;set;}
				IT_TableFieldDAL IT_TableFieldDAL{get;set;}
				IT_TodoListDAL IT_TodoListDAL{get;set;}
				IT_UserDAL IT_UserDAL{get;set;}
				IT_UserGroupDAL IT_UserGroupDAL{get;set;}
				IT_UserGroupRelationDAL IT_UserGroupRelationDAL{get;set;}
				IT_UserRoleRelationDAL IT_UserRoleRelationDAL{get;set;}
				IT_UserUnitRelationDAL IT_UserUnitRelationDAL{get;set;}
				IT_UseWorkerDAL IT_UseWorkerDAL{get;set;}
				IV_Auth_Per_00001_System_BPM_StartDAL IV_Auth_Per_00001_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_00001_System_Operation_StartDAL IV_Auth_Per_00001_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_00001_System_Org_TreeDAL IV_Auth_Per_00001_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_00001_System_Person_ReadwriteDAL IV_Auth_Per_00001_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_00001_System_PersonClassDAL IV_Auth_Per_00001_System_PersonClassDAL{get;set;}
				IV_Auth_Per_00002_System_BPM_StartDAL IV_Auth_Per_00002_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_00002_System_Operation_StartDAL IV_Auth_Per_00002_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_00002_System_Org_TreeDAL IV_Auth_Per_00002_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_00002_System_Person_ReadwriteDAL IV_Auth_Per_00002_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_00002_System_PersonClassDAL IV_Auth_Per_00002_System_PersonClassDAL{get;set;}
				IV_Auth_Per_anonymous_System_BPM_StartDAL IV_Auth_Per_anonymous_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_anonymous_System_Operation_StartDAL IV_Auth_Per_anonymous_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_anonymous_System_Org_TreeDAL IV_Auth_Per_anonymous_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_anonymous_System_Person_ReadwriteDAL IV_Auth_Per_anonymous_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_anonymous_System_PersonClassDAL IV_Auth_Per_anonymous_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000B_System_BPM_StartDAL IV_Auth_Per_U00000B_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000B_System_Operation_StartDAL IV_Auth_Per_U00000B_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000B_System_Org_TreeDAL IV_Auth_Per_U00000B_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000B_System_Person_ReadwriteDAL IV_Auth_Per_U00000B_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000B_System_PersonClassDAL IV_Auth_Per_U00000B_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000C_System_BPM_StartDAL IV_Auth_Per_U00000C_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000C_System_Operation_StartDAL IV_Auth_Per_U00000C_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000C_System_Org_TreeDAL IV_Auth_Per_U00000C_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000C_System_Person_ReadwriteDAL IV_Auth_Per_U00000C_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000C_System_PersonClassDAL IV_Auth_Per_U00000C_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000D_System_BPM_StartDAL IV_Auth_Per_U00000D_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000D_System_Operation_StartDAL IV_Auth_Per_U00000D_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000D_System_Org_TreeDAL IV_Auth_Per_U00000D_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000D_System_Person_ReadwriteDAL IV_Auth_Per_U00000D_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000D_System_PersonClassDAL IV_Auth_Per_U00000D_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000E_System_BPM_StartDAL IV_Auth_Per_U00000E_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000E_System_Operation_StartDAL IV_Auth_Per_U00000E_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000E_System_Org_TreeDAL IV_Auth_Per_U00000E_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000E_System_Person_ReadwriteDAL IV_Auth_Per_U00000E_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000E_System_PersonClassDAL IV_Auth_Per_U00000E_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000F_System_BPM_StartDAL IV_Auth_Per_U00000F_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000F_System_Operation_StartDAL IV_Auth_Per_U00000F_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000F_System_Org_TreeDAL IV_Auth_Per_U00000F_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000F_System_Person_ReadwriteDAL IV_Auth_Per_U00000F_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000F_System_PersonClassDAL IV_Auth_Per_U00000F_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000G_System_BPM_StartDAL IV_Auth_Per_U00000G_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000G_System_Operation_StartDAL IV_Auth_Per_U00000G_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000G_System_Org_TreeDAL IV_Auth_Per_U00000G_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000G_System_Person_ReadwriteDAL IV_Auth_Per_U00000G_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000G_System_PersonClassDAL IV_Auth_Per_U00000G_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000I_System_BPM_StartDAL IV_Auth_Per_U00000I_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000I_System_Operation_StartDAL IV_Auth_Per_U00000I_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000I_System_Org_TreeDAL IV_Auth_Per_U00000I_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000I_System_Person_ReadwriteDAL IV_Auth_Per_U00000I_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000I_System_PersonClassDAL IV_Auth_Per_U00000I_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000J_System_BPM_StartDAL IV_Auth_Per_U00000J_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000J_System_Operation_StartDAL IV_Auth_Per_U00000J_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000J_System_Org_TreeDAL IV_Auth_Per_U00000J_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000J_System_Person_ReadwriteDAL IV_Auth_Per_U00000J_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000J_System_PersonClassDAL IV_Auth_Per_U00000J_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000K_System_BPM_StartDAL IV_Auth_Per_U00000K_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000K_System_Operation_StartDAL IV_Auth_Per_U00000K_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000K_System_Org_TreeDAL IV_Auth_Per_U00000K_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000K_System_Person_ReadwriteDAL IV_Auth_Per_U00000K_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000K_System_PersonClassDAL IV_Auth_Per_U00000K_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000L_System_BPM_StartDAL IV_Auth_Per_U00000L_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000L_System_Operation_StartDAL IV_Auth_Per_U00000L_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000L_System_Org_TreeDAL IV_Auth_Per_U00000L_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000L_System_Person_ReadwriteDAL IV_Auth_Per_U00000L_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000L_System_PersonClassDAL IV_Auth_Per_U00000L_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000M_System_BPM_StartDAL IV_Auth_Per_U00000M_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000M_System_Operation_StartDAL IV_Auth_Per_U00000M_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000M_System_Org_TreeDAL IV_Auth_Per_U00000M_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000M_System_Person_ReadwriteDAL IV_Auth_Per_U00000M_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000M_System_PersonClassDAL IV_Auth_Per_U00000M_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000O_System_BPM_StartDAL IV_Auth_Per_U00000O_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000O_System_Operation_StartDAL IV_Auth_Per_U00000O_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000O_System_Org_TreeDAL IV_Auth_Per_U00000O_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000O_System_Person_ReadwriteDAL IV_Auth_Per_U00000O_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000O_System_PersonClassDAL IV_Auth_Per_U00000O_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000P_System_BPM_StartDAL IV_Auth_Per_U00000P_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000P_System_Operation_StartDAL IV_Auth_Per_U00000P_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000P_System_Org_TreeDAL IV_Auth_Per_U00000P_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000P_System_Person_ReadwriteDAL IV_Auth_Per_U00000P_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000P_System_PersonClassDAL IV_Auth_Per_U00000P_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000R_System_BPM_StartDAL IV_Auth_Per_U00000R_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000R_System_Operation_StartDAL IV_Auth_Per_U00000R_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000R_System_Org_TreeDAL IV_Auth_Per_U00000R_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000R_System_Person_ReadwriteDAL IV_Auth_Per_U00000R_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000R_System_PersonClassDAL IV_Auth_Per_U00000R_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000S_System_BPM_StartDAL IV_Auth_Per_U00000S_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000S_System_Operation_StartDAL IV_Auth_Per_U00000S_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000S_System_Org_TreeDAL IV_Auth_Per_U00000S_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000S_System_Person_ReadwriteDAL IV_Auth_Per_U00000S_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000S_System_PersonClassDAL IV_Auth_Per_U00000S_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000T_System_BPM_StartDAL IV_Auth_Per_U00000T_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000T_System_Operation_StartDAL IV_Auth_Per_U00000T_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000T_System_Org_TreeDAL IV_Auth_Per_U00000T_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000T_System_Person_ReadwriteDAL IV_Auth_Per_U00000T_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000T_System_PersonClassDAL IV_Auth_Per_U00000T_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000U_System_BPM_StartDAL IV_Auth_Per_U00000U_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000U_System_Operation_StartDAL IV_Auth_Per_U00000U_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000U_System_Org_TreeDAL IV_Auth_Per_U00000U_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000U_System_Person_ReadwriteDAL IV_Auth_Per_U00000U_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000U_System_PersonClassDAL IV_Auth_Per_U00000U_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000V_System_BPM_StartDAL IV_Auth_Per_U00000V_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000V_System_Operation_StartDAL IV_Auth_Per_U00000V_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000V_System_Org_TreeDAL IV_Auth_Per_U00000V_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000V_System_Person_ReadwriteDAL IV_Auth_Per_U00000V_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000V_System_PersonClassDAL IV_Auth_Per_U00000V_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000X_System_BPM_StartDAL IV_Auth_Per_U00000X_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000X_System_Operation_StartDAL IV_Auth_Per_U00000X_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000X_System_Org_TreeDAL IV_Auth_Per_U00000X_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000X_System_Person_ReadwriteDAL IV_Auth_Per_U00000X_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000X_System_PersonClassDAL IV_Auth_Per_U00000X_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000Y_System_BPM_StartDAL IV_Auth_Per_U00000Y_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000Y_System_Operation_StartDAL IV_Auth_Per_U00000Y_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000Y_System_Org_TreeDAL IV_Auth_Per_U00000Y_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000Y_System_Person_ReadwriteDAL IV_Auth_Per_U00000Y_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000Y_System_PersonClassDAL IV_Auth_Per_U00000Y_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U00000Z_System_BPM_StartDAL IV_Auth_Per_U00000Z_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U00000Z_System_Operation_StartDAL IV_Auth_Per_U00000Z_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U00000Z_System_Org_TreeDAL IV_Auth_Per_U00000Z_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U00000Z_System_Person_ReadwriteDAL IV_Auth_Per_U00000Z_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U00000Z_System_PersonClassDAL IV_Auth_Per_U00000Z_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U000010_System_BPM_StartDAL IV_Auth_Per_U000010_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U000010_System_Operation_StartDAL IV_Auth_Per_U000010_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U000010_System_Org_TreeDAL IV_Auth_Per_U000010_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U000010_System_Person_ReadwriteDAL IV_Auth_Per_U000010_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U000010_System_PersonClassDAL IV_Auth_Per_U000010_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U000011_System_BPM_StartDAL IV_Auth_Per_U000011_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U000011_System_Operation_StartDAL IV_Auth_Per_U000011_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U000011_System_Org_TreeDAL IV_Auth_Per_U000011_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U000011_System_Person_ReadwriteDAL IV_Auth_Per_U000011_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U000011_System_PersonClassDAL IV_Auth_Per_U000011_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U000012_System_BPM_StartDAL IV_Auth_Per_U000012_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U000012_System_Operation_StartDAL IV_Auth_Per_U000012_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U000012_System_Org_TreeDAL IV_Auth_Per_U000012_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U000012_System_Person_ReadwriteDAL IV_Auth_Per_U000012_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U000012_System_PersonClassDAL IV_Auth_Per_U000012_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U000014_System_BPM_StartDAL IV_Auth_Per_U000014_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U000014_System_Operation_StartDAL IV_Auth_Per_U000014_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U000014_System_Org_TreeDAL IV_Auth_Per_U000014_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U000014_System_Person_ReadwriteDAL IV_Auth_Per_U000014_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U000014_System_PersonClassDAL IV_Auth_Per_U000014_System_PersonClassDAL{get;set;}
				IV_Auth_Per_U000015_System_BPM_StartDAL IV_Auth_Per_U000015_System_BPM_StartDAL{get;set;}
				IV_Auth_Per_U000015_System_Operation_StartDAL IV_Auth_Per_U000015_System_Operation_StartDAL{get;set;}
				IV_Auth_Per_U000015_System_Org_TreeDAL IV_Auth_Per_U000015_System_Org_TreeDAL{get;set;}
				IV_Auth_Per_U000015_System_Person_ReadwriteDAL IV_Auth_Per_U000015_System_Person_ReadwriteDAL{get;set;}
				IV_Auth_Per_U000015_System_PersonClassDAL IV_Auth_Per_U000015_System_PersonClassDAL{get;set;}
				IV_My_WidgetModule_ObjectsDAL IV_My_WidgetModule_ObjectsDAL{get;set;}
				IView_A02DAL IView_A02DAL{get;set;}
				IView_Auth_UserDAL IView_Auth_UserDAL{get;set;}
				IView_CatalogDocumentDAL IView_CatalogDocumentDAL{get;set;}
				IView_Com_JetTableItemsDAL IView_Com_JetTableItemsDAL{get;set;}
				IView_QXTJDAL IView_QXTJDAL{get;set;}
				IWF_JobMainDAL IWF_JobMainDAL{get;set;}
				IWF_JobMainExcludeChooseDAL IWF_JobMainExcludeChooseDAL{get;set;}
				IWF_JobOpinionDAL IWF_JobOpinionDAL{get;set;}
				IWF_JobProxyDAL IWF_JobProxyDAL{get;set;}
				IWF_JobSaveOrgDAL IWF_JobSaveOrgDAL{get;set;}
				IWF_JobStepDAL IWF_JobStepDAL{get;set;}
				IWF_OperationCalcDAL IWF_OperationCalcDAL{get;set;}
				IWF_OperationDocumentDAL IWF_OperationDocumentDAL{get;set;}
				IWF_OperationGroupDAL IWF_OperationGroupDAL{get;set;}
				IWF_OperationKeyValueDAL IWF_OperationKeyValueDAL{get;set;}
				IWF_OperationMainDAL IWF_OperationMainDAL{get;set;}
				IWF_OperationOutPutDAL IWF_OperationOutPutDAL{get;set;}
				IWF_OperationSalaryOPItemDAL IWF_OperationSalaryOPItemDAL{get;set;}
				IWF_OperationSalaryOPMainDAL IWF_OperationSalaryOPMainDAL{get;set;}
				IWF_OperationSalaryOPSignItemDAL IWF_OperationSalaryOPSignItemDAL{get;set;}
				IWF_OperationSalaryOPSignMainDAL IWF_OperationSalaryOPSignMainDAL{get;set;}
				IWF_OperationSetItemOptionDAL IWF_OperationSetItemOptionDAL{get;set;}
				IWF_OperationSetItemsDAL IWF_OperationSetItemsDAL{get;set;}
				IWF_OperationSetTableDAL IWF_OperationSetTableDAL{get;set;}
				IWF_OperationSetTableOptionDAL IWF_OperationSetTableOptionDAL{get;set;}
				IWF_OperationSTCodeItemsDAL IWF_OperationSTCodeItemsDAL{get;set;}
				IWF_OperationSTDataDAL IWF_OperationSTDataDAL{get;set;}
				IWF_OperationStepDAL IWF_OperationStepDAL{get;set;}
				IWF_OperationStepPrivilegeDAL IWF_OperationStepPrivilegeDAL{get;set;}
				IWF_OperationSTMainDAL IWF_OperationSTMainDAL{get;set;}
				IWF_OperationSTSetItemsDAL IWF_OperationSTSetItemsDAL{get;set;}
				IWF_OperationTypeDAL IWF_OperationTypeDAL{get;set;}
				IWGJG_GRZXDAL IWGJG_GRZXDAL{get;set;}
				IWGJG_WarnDataDAL IWGJG_WarnDataDAL{get;set;}
				IWGJG_ZXDAL IWGJG_ZXDAL{get;set;}
				IWGJG01DAL IWGJG01DAL{get;set;}
				IWGJG01_TemplateDAL IWGJG01_TemplateDAL{get;set;}
				IWGJG02DAL IWGJG02DAL{get;set;}
				IWGJG02_TemplateDAL IWGJG02_TemplateDAL{get;set;}
				IXS_StudentDAL IXS_StudentDAL{get;set;}
				IXS_StudentScoreDAL IXS_StudentScoreDAL{get;set;}
			}
}