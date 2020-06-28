public class Soldier {
	public int id;
	public String name;
	public String soldierNumber;
	public int generalVacation;	
	public String birth;
	
	public Soldier(int id, String name, String soldierNumber, int generalVacation, String birth) {
		this.id = id;
		this.name = name;
		this.soldierNumber = soldierNumber;
		this.generalVacation = generalVacation;		
		this.birth = birth;
	}
	
	public void showSoldierInfo() {
		System.out.println("---------------------------");
		System.out.println("id : " + id);
		System.out.println("�̸� : " + name);
		System.out.println("���� : " + soldierNumber);
		System.out.println("���� : " + generalVacation);
		System.out.println("���� : " + birth);
		System.out.println("---------------------------");
	}
}

