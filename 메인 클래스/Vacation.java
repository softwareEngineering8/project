public class Vacation {
	public int id;
	public int specialVacationID;
	public int usedGeneralVacation;
	public int departDate;
	public int arriveDate;
	public int soldierID;	
	
	public Vacation(int id, int specialVacationID, int usedGeneralVacation, int departDate, int arriveDate, int soldierID) {
		this.id = id;
		this.specialVacationID = specialVacationID;
		this.usedGeneralVacation = usedGeneralVacation;
		this.departDate = departDate;
		this.arriveDate = arriveDate;
		this.soldierID = soldierID;
	}
}
