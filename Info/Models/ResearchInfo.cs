using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;

namespace Info.Models
{
    //[TableName("research_application_tb")]
    //[Table("research_application_tb")]
    public partial class research_application_tb
    {
        //[Display(Name="序号")]
        //public long Xh { get; set; }
        public long Id { get; set; }
        [Display(Name = "客户全称")]
        public string CustomerName { get; set; }
        [Display(Name = "联系人")]
        public string ContactPerson { get; set; }
        [Display(Name = "手机")]
        [Required(ErrorMessage = "手机号必须的")]
        public string ContactPhone { get; set; }
        [Display(Name = "公司地址")]
        public string CompanyAddress { get; set; }
        //[Display(Name = "介绍人")]
        //public string Referrals { get; set; }
        //[Display(Name = "手机")]
        //public string ReferralsNumber { get; set; }
        [Display(Name = "省份")]
        public string Province { get; set; }
        [Display(Name = "城市")]
        public string City { get; set; }
        [Display(Name = "业务负责人")]
        public string BCompany { get; set; }
        //[Display(Name = "客户座机")]
        //public string CustomerTel { get; set; }
        //[Display(Name = "填表人(公司)")]
        //public string TbWriter { get; set; }
        //[Display(Name = "代理品牌1")]
        //public string PinPai1 { get; set; }
        //[Display(Name = "代理品牌2")]
        //public string PinPai2 { get; set; }
        //[Display(Name = "代理品牌3")]
        //public string PinPai3 { get; set; }
        //[Display(Name = "传真")]
        //public string Fax { get; set; }
        //[Display(Name = "经营模式")]
        //public string Model { get; set; }
        //[Display(Name = "卖场面积")]
        //public Nullable<int> StoreArea { get; set; }
        //[Display(Name = "本季拟开店总数(间)")]
        //public Nullable<int> StoreNum { get; set; }
        //[Display(Name = "拟开发的卖场名称(含楼层与位置信息)")]
        //public string StoreName { get; set; }
        //[Display(Name = "是否有在以上卖场经营记录")]
        //public string BusinessRecords { get; set; }
        //[Display(Name = "品牌")]
        //public string BrandName { get; set; }
        //[Display(Name = "卖场是否有可参考的友商品牌")]
        //public string FriendBrand { get; set; }
        //[Display(Name = "卖场是否有可参考的友商品牌")]
        //public string FriendBrandName { get; set; }
        //[Display(Name = "9月")]
        //public Nullable<int> Sales9 { get; set; }
        //[Display(Name = "10月")]
        //public Nullable<int> Sales10 { get; set; }
        //[Display(Name = "11月")]
        //public Nullable<int> Sales11 { get; set; }
        //[Display(Name = "12月")]
        //public Nullable<int> Sales12 { get; set; }
        //[Display(Name = "1月")]
        //public Nullable<int> Sales1 { get; set; }
        //[Display(Name = "2月")]
        //public Nullable<int> Sales2 { get; set; }
        //[Display(Name = "合作方式")]
        //public string CooperationMode { get; set; }
        //[Display(Name = "是否需要公司配合开店")]
        //public string Coordinate { get; set; }
        //[Display(Name = "派员时间")]
        //public Nullable<System.DateTime> SendTime { get; set; }
        //[Display(Name = "本季初次投资的金额预期")]
        //public string AmountExpected { get; set; }
        //[Display(Name = "代理优势")]
        //public string AgentAdvantages { get; set; }
        //[Display(Name = "如本公司批准您的加盟申请，是否可以在一周内确定合作意向并参加订货会")]
        //public string FranchiseApplication { get; set; }
        //[Display(Name = "是否在业务员指导下阅读《盈利预测分析表》")]
        //public string ProfitForecast { get; set; }
        //[Display(Name = "请提出对本公司运营的宝贵建议")]
        //public string Suggestions { get; set; }
        [Display(Name = "上传图片")]
        public byte[] Image { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ImageType { get; set; }
        [Display(Name="备注")]
        public string Remark { get; set; }

    }

    public class CreateInfo
    {
        public long Id { get; set; }
        [Display(Name = "业务负责人")]
        public string BCompany { get; set; }
        [Display(Name = "客户全称")]
        public string CustomerName { get; set; }
        [Display(Name = "联系人")]
        public string ContactPerson { get; set; }
        [Display(Name = "手机")]
        [Required(ErrorMessage = "手机号必须的")]
        //[RegularExpression(@"\d{11}",ErrorMessage="手机号错误")]
        public string ContactPhone { get; set; }
        [Display(Name = "省份")]
        public string Province { get; set; }
        [Display(Name = "城市")]
        public string City { get; set; }
        [Display(Name = "公司地址")]
        public string CompanyAddress { get; set; }
        
        public byte[] Image { get; set; }
        [Display(Name = "上传图片")]
        //[Required(ErrorMessage = "图片必选的")]
        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name = "备注")]
        public string Remark { get; set; }
    }
}