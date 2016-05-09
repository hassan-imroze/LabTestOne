using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace RequestModel
{
    public class StudentRequestModel : RequestModel<Student>
    {
        public StudentRequestModel(string keyword, string orderBy, string isAscending) : base(keyword, orderBy, isAscending)
        {
        }

        protected override Expression<Func<Student, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = x => x.Name.ToLower().Contains(Keyword) || x.Roll.ToLower().Contains(Keyword) || x.Address.ToLower().Contains(Keyword)
                                    || x.Email.Contains(Keyword);
            }
            if (!string.IsNullOrWhiteSpace(ParentId))
            {
                ExpressionObj = ExpressionObj.And(x => x.PaidFees.Any(y=>y.Id == ParentId));
            }
            //if (StartDate != new DateTime() && EndDate != new DateTime())
            //{
            //    StartDate = StartDate.Date;
            //    EndDate = EndDate.Date.AddDays(1).AddMinutes(-1);
            //    ExpressionObj = ExpressionObj.And(x => x.Created >= StartDate && x.Created <= EndDate);
            //}
            return ExpressionObj;
        }
    }
}
