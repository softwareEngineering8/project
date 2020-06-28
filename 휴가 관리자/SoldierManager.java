import java.util.*;

public class SoldierManager extends Manager {
	public void start() {
		System.out.println("<�������� ������>�Դϴ�.");
		int id;
		String name;
		String soldierNumber;
		int generalVacation;
		String birth;
		
		boolean ch = true;
		
		Scanner sc = new Scanner(System.in);
		while(ch) {
			System.out.println("[0] �ο� ����Ʈ ���");
			System.out.println("[1] �ο� �߰�");
			System.out.println("[2] �ο� ���� ����");
			System.out.println("[3] �ο� ����");
			System.out.println("[4] �ο� �� ����");
			System.out.println("[9] ���");
			
			System.out.println("�Է� : ");
			int button;
			button = sc.nextInt();
			
			Soldier s;
			switch(button) {
				case 0:
					System.out.println("<�ο� ����Ʈ ���>");
					showSoldierList();
				break;
				
				case 1:
					System.out.println("<�ο� �߰�>");
					System.out.println("�̸�");
					name = sc.next();
					System.out.println("����");
					soldierNumber = sc.next();	
					System.out.println("����");
					birth = sc.next();
					addSoldier(name, soldierNumber, birth);
				break;
				
				case 2:
					System.out.println("<�ο� ����>");
					System.out.println("������ �ο��� �̸�");
					name = sc.next();					
					getSoldierList("where name='"+name+"'");
					s = soldierList.get(0);
					s.showSoldierInfo();
					
					System.out.println("������ �̸�");
					name = sc.next();
					System.out.println("������ ����");
					soldierNumber = sc.next();
					System.out.println("������ ����");
					generalVacation= sc.nextInt();
					System.out.println("������ ����");
					birth= sc.next();
					updateSoldier(s.id,name,soldierNumber, generalVacation, birth);
				break;
				
				case 3:
					System.out.println("<�ο� ����>");
					System.out.println("������ �ο��� �̸�");
					name = sc.next();					
					getSoldierList("where name='"+name+"'");
					s = soldierList.get(0);
					s.showSoldierInfo();
					
					System.out.println("���� �����Ͻðڽ��ϱ� (Y/N)");
					String temp = sc.next();
					if(temp.equals("Y")||temp.equals("y")) {
						deleteSoldier(s.id);
					}
					
				break;
				
				case 4:
					System.out.println("<�ο� �� ����>");
					System.out.println("�ڼ��� �� �ο��� �̸�");
					name = sc.next();					
					getSoldierList("where name='"+name+"'");
					s = soldierList.get(0);
					s.showSoldierInfo();	
					
					System.out.println("<Ư���ް� ����Ʈ>");
					getSpecialVacationList("where soldierID="+ s.id);
					
					for(int i=0;i<specialVacationList.size();i++) {
						SpecialVacation spvaca = specialVacationList.get(i);
						if (spvaca.vacationID == 0)
							temp = "X";	
						else if (spvaca.vacationID == -1)
							temp = "��";	
						else
							temp = "O";
						System.out.println("id:"+spvaca.id+" �ް��̸�:"+spvaca.vacationName+" ����:"+spvaca.length +" ��뿩��:"+temp);
					}
				break;
				
				case 9:
					ch = false;
				break;
			}
		}		
	}	
	
	private void showSoldierList(){	
		getSoldierList("");
		System.out.println("---------------------------");
		for(int i=0; i<soldierList.size();i++) {
			//System.out.println("[id : "+soldierList.get(i).id);
			System.out.println("["+(i+1)+"] name : "+soldierList.get(i).name);
			//System.out.println("soldierNumber : "+soldierList.get(i).soldierNumber);
			//System.out.println("generalVacation : "+soldierList.get(i).generalVacation);
		}
		System.out.println("---------------------------");
	}
	
	private void addSoldier(String name, String soldierNumber, String birth) {	
		updateQuery("INSERT INTO soldier(name, soldierNUMBER, birth, password) "
				+ "VALUES('"+name+"','"+soldierNumber+"','"+birth+"','"+birth+"')");
	}
	
	private void updateSoldier(int id, String name, String soldierNumber, int generalVacation, String birth)
	{
		updateQuery("UPDATE soldier SET"
				+ " name='" + name + "', soldierNumber='" + soldierNumber + "' ,generalVacation="+generalVacation
				+ " ,birth='"+birth + "' WHERE _id=" + id);
	}	
	
	private void deleteSoldier(int id)
	{
		updateQuery("DELETE FROM soldier WHERE _id = " + id);
	}
}
