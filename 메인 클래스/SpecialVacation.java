public class SpecialVacation {
	public int id;	
	public int length;
	public String vacationKind;
	public String vacationName;
	public int vacationID;//��뿩��, �� Ư���ް��� ������� �� ���⿡ ���� �ް��� ID�� �ִ�
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
		System.out.println("�ް� ���� : " + length);
		System.out.println("�ް� ���� : " + vacationKind);
		System.out.println("�ް� �̸� : " + vacationName);
		System.out.println("��� ���� : " + vacationID);
		System.out.println("---------------------------");
	}
}
