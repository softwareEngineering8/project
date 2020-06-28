public class SpecialVacation {
	public int id;	
	public int length;
	public String vacationKind;
	public String vacationName;
	public int vacationID;//사용여부, 이 특별휴가를 사용했을 시 여기에 사용된 휴가의 ID를 넣는
	public int soldierID;
	
	public SpecialVacation(int id, int length, String vacationKind, String vacationName, int vacationID, int soldierID) {
		this.id = id;
		this.length = length;
		this.vacationKind = vacationKind;		
		this.vacationName = vacationName;
		this.vacationID = vacationID;
		this.soldierID = soldierID;
	}
	
	public void showSpecialVacationInfo() {
		System.out.println("---------------------------");
		System.out.println("id : " + id);
		System.out.println("휴가 길이 : " + length);
		System.out.println("휴가 종류 : " + vacationKind);
		System.out.println("휴가 이름 : " + vacationName);
		System.out.println("사용 여부 : " + vacationID);
		System.out.println("---------------------------");
	}
}
