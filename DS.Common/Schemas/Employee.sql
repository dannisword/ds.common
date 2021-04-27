create table Employees
(
 Id						int identity				  not null, -- 員工編碼 
 Code					nvarchar(10)				  not null, -- 員工代號
 Name					nvarchar(48)				  not null, -- 員工姓名
 Category				nvarchar(08)				  not null,	-- 員工
 IdNo					nvarchar(32)				  not null, -- 身分證號
 Email					nvarchar(100)				  		  , -- 員工Mail
 Birthday				datetime                      not null, -- 生日
 Sex					nvarchar(1)					  not null, -- 性別
																-------------------------------------
																-- F : 女
																-- M : 男
																-------------------------------------
 Tel					nvarchar(16)				  		  , -- 電話
 Mobile					nvarchar(16)				  		  , -- 行動電話
 ZipNo					nvarchar(8)					  		  , -- 郵遞區號
 Adress					nvarchar(255)				  not null, -- 通訊地址
 ResidentZip			nvarchar(8)					  		  , -- 戶籍區號
 ResidentShip			nvarchar(255)				  not null, -- 戶籍地址
 MarriageStatus         smallint					  not null, -- 婚姻狀態
  																-------------------------------------
																-- 10 : 未婚
																-- 20 : 已婚
																-- 90 : 其他
																-------------------------------------
 StartDate				datetime                      not null, -- 任用日期
 EndDate				datetime                      not null, -- 離職日期
 Introducer				int							  not null, -- 介紹人
 EmergencyKin 			nvarchar(48)				  		  , -- 緊急聯絡人
 EmergencyTel			nvarchar(16)				  		  , -- 緊急聯絡電話
 EmergencyMobile		nvarchar(16)				  		  , -- 緊急聯絡手機1
 IsActive               boolean                       not null, --
 Status					smallint					  not null, -- 狀態
  																-------------------------------------
																-- 60 : 正常
																-- 80 : 離職
																-- 81 : 自離
																-- 82 : 解雇
																-- 83 : 開除
																-- 91 : 留職停薪
																-- 以此類推
																-------------------------------------
 LeaveReason			smallint					  not null, -- 離職類別
																-------------------------------------
                                                                -- 依OptionMts.OptionID 對應 OptionDts.OptionID
																-- 取得各廠離職類別
																-------------------------------------
 Remark					nvarchar(255)				  		  , -- 備註		
 ResignRemark			nvarchar(255)				  		  , -- 離職備註
 CreatedBy 				int							  not null, -- 建檔人員 
 CreatedAt				datetime                      not null, -- 建檔時間
 UpdatedBy				int                           not null, -- 異動人員
 UpdatedAt 				datetime                      not null, -- 異動時間 

 constraint EmployeesPKey primary key(EmployeeID)
);
create Index Employees_IX1 on Employees(EmployeeCode, IsActive);
