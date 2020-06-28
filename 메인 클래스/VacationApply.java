public class VacationApply {
	public int id;
	public int kind;
	public int specialVacationID;
	public int usedGeneralVacation;
	public int departDate;
	public int arriveDate;
	public int approvalCheck;
	public int soldierID;	
	public int vacationID;	
	
	public VacationApply(int id, int kind, int specialVacationID, int usedGeneralVacation, int departDate, int arriveDate, 
			int approvalCheck, int soldierID, int vacationID) {
		this.id = id;
		this.kind = kind;
		this.specialVacationID = specialVacationID;
		this.usedGeneralVacation = usedGeneralVacation;
		this.departDate = departDate;
		this.arriveDate = arriveDate;
		this.approvalCheck = approvalCheck;
		this.soldierID = soldierID;
		this.vacationID = vacationID;
	}
}
