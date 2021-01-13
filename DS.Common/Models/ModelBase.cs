using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DS.Common.Models
{
    [Serializable]
    public abstract class ModelBase
    {

        // 建檔人員
        public int CreatedBy { get; set; }

        // 建檔時間
        public DateTime CreatedAt { get; set; }

        // 異動人員
        public int UpdatedBy { get; set; }

        // 異動時間
        public DateTime UpdatedAt { get; set; }

        // 設定資料庫相關 PK Index 欄位大小等
        public abstract void ModelBuilder(ModelBuilder modelBuilder);
    }
}