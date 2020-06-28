import java.util.Scanner;

public class SpecialVacationManager extends Manager{
	int soldierID =-1;
	Soldier s;
	SpecialVacation sv;
	public void start() {
		System.out.println("<Ư���ް� ������>�Դϴ�.");
		Scanner sc = new Scanner(System.in);
		
		System.out.println("Ư���ް��� ������ �庴 �̸�");
		String __name = sc.next();
		findSoldierID(__name);
		
		boolean ch = true;
		
		while(ch) {
			System.out.println("[0] Ư���ް� ����Ʈ");
			System.out.println("[1] Ư���ް� �߰�");
			System.out.println("[2] Ư���ް� ����");
			System.out.println("[3] Ư���ް� ����");
			System.out.println("[9] ����");
			
			System.out.println("�Է� : ");
			int button;
			int spVacationID;
			button = sc.nextInt();
			SpecialVacation spvaca;
			
			int length;
			String vacationKind;
			String vacationName;
			int vacationID;
			
			switch(button) {
				case 0:					
					System.out.println("<Ư���ް� ����Ʈ>");
					getSpecialVacationList("where soldierID="+ soldierID);
					for(int i=0;i<specialVacationList.size();i++) {
						spvaca = specialVacationList.get(i);
						String temp;
						if (spvaca.vacationID == 0)
							temp = "X";	
						else if (spvaca.vacationID == -1)
							temp = "��";	
						else
							temp = "O";
						System.out.println("id:"+spvaca.id+" �ް��̸�:"+spvaca.vacationName+" ����:"+spvaca.length +" ��뿩��:"+temp);
					}
					break;
				
				case 1:
					System.out.println("<Ư���ް� �߰�>");
					System.out.println("�ް� ����");
					length = sc.nextInt();
					System.out.println("�ް� ����");
					vacationKind = sc.next();	
					System.out.println("�ް� �̸�");
					vacationName = sc.next();
					
					addSpecialVacation(length, vacationKind, vacationName, soldierID);
					break;
				
				case 2:
					System.out.println("<Ư���ް� ����>");
					System.out.println("������ Ư���ް� id");
					spVacationID = sc.nextInt();					
					getSpecialVacationList("where _id="+spVacationID);
					spvaca = specialVacationList.get(0);
					spvaca.showSpecialVacationInfo();
					
					System.out.println("�ް� ����");
					length = sc.nextInt();
					System.out.println("�ް� ����");
					vacationKind = sc.next();	
					System.out.println("�ް� �̸�");
					vacationName = sc.next();
					System.out.println("��� ����");
					vacationID = sc.nextInt();
					
					updateSpecialVacation(spvaca.id,length,vacationKind,vacationName,vacationID);
					break;
					
				case 3:
					System.out.println("<Ư���ް� ����>");
					System.out.println("������ Ư���ް� id");
					spVacationID = sc.nextInt();					
					getSpecialVacationList("where _id="+spVacationID);
					spvaca = specialVacationList.get(0);
					spvaca.showSpecialVacationInfo();
					
					System.out.println("���� �����Ͻðڽ��ϱ� (Y/N)");
					String temp = sc.next();
					if(temp.equals("Y")||temp.equals("y")) {
						deleteSpecialVacation(spvaca);
					}
					break;
					
				case 9:
					ch = false;
					break;
			}
		}
		
	}
	
	private void findSoldierID(String name) {
		getSoldierList("where name='"+name+"'");
		if(soldierList.size()==1) {
			s = soldierList.get(0);
			soldierID = s.id;
			
			s.showSoldierInfo();	
		}
		else {
			System.out.println("�������� �ʴ� �̸��Դϴ�.");			
		}
	}
	
	private void addSpecialVacation(int length, String vacationKind, String vacationName, int soldierID) {	
		updateQuery("INSERT INTO specialVacation(length, vacationKind, vacationName, soldierID) "
				+ "VALUES("+length+",'"+vacationKind+"','"+vacationName+"', "+soldierID+")");
	}
	
	private void updateSpecialVacation(int id, int length, String vacationKind, String vacationName, int vacationID)
	{
		updateQuery("UPDATE specialVacation SET"
				+ " length=" + length + ", vacationKind='" + vacationKind + "' ,vacationName='"+vacationName
				+ "' ,vacationID="+vacationID + " WHERE _id=" + id);
	}	
	
	private void deleteSpecialVacation(SpecialVacation spvaca)
	{
		updateQuery("DELETE FROM specialVacation WHERE _id = " + spvaca.id);
	}
}
