create table BulletinBoards
(
 BoardId				int identity(1,1)        		not null,	-- 最新公告編號
 Category				nvarchar(08)						not null,	-- 類別
 Title					nvarchar(32)     					not null,	-- 最新公告標題
 Contents				nvarchar(4000)     					not null,	-- 公告內文
 Authority				int									not null,	-- UserId
 PublicationAt			datetime    default ('2999/12/31')	not null,	-- 上載日期
 PostingAt				datetime	default ('2999/12/31')	not null,	-- 發文日期
 ExpirationAt			datetime	default ('2999/12/31')	not null,	-- 截止日期
 IsActive               boolean                     		not null,   -- 啟用
 Sataus                 smallint                            not null,   -- 狀態	0:新建 10:審核 20:發佈 90:取消						
 CreatedBy				int									not null,	-- 建檔人員 
 CreatedAt				datetime							not null,	-- 建檔時間 
 UpdatedBy				int									not null,	-- 異動人員 
 UpdatedAt				datetime							not null,	-- 異動時間 
 constraint BulletinBoardsPKey primary key(BoardId)
)


