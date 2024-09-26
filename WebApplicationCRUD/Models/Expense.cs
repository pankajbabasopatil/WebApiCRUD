using System;
using System.Collections.Generic;

namespace WebApplicationCRUD.Models;

public partial class Expense
{
    public int Id { get; set; }

    public string ExpenseDate { get; set; } = null!;

    public string DayOfWeek { get; set; } = null!;

    public decimal SpentAmount { get; set; }

    public decimal TotalAmount { get; set; }
}
