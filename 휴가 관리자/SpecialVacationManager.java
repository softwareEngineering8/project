import java.util.Scanner;

public class SpecialVacationManager extends Manager{
	int soldierID =-1;
	Soldier s;
	SpecialVacation sv;
	public void start() {
		System.out.println("<특별휴가 관리자>입니다.");
		Scanner sc = new Scanner(System.in);
		
		System.out.println("특별휴가를 관리할 장병 이름");
		String __name = sc.next();
		findSoldierID(__name);
		
		boolean ch = true;
		
		while(ch) {
			System.out.println("[0] 특별휴가 리스트");
			System.out.println("[1] 특별휴가 추가");
			System.out.println("[2] 특별휴가 정정");
			System.out.println("[3] 특별휴가 삭제");
			System.out.println("[9] 종료");
			
			System.out.println("입력 : ");
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
					System.out.println("<특별휴가 리스트>");
					getSpecialVacationList("where soldierID="+ soldierID);
					for(int i=0;i<specialVacationList.size();i++) {
						spvaca = specialVacationList.get(i);
						String temp;
						if (spvaca.vacationID == 0)
							temp = "X";	
						else if (spvaca.vacationID == -1)
							temp = "△";	
						else
							temp = "O";
						System.out.println("id:"+spvaca.id+" 휴가이름:"+spvaca.vacationName+" 길이:"+spvaca.length +" 사용여부:"+temp);
					}
					break;
				
				case 1:
					System.out.println("<특별휴가 추가>");
					System.out.println("휴가 길이");
					length = sc.nextInt();
					System.out.println("휴가 종류");
					vacationKind = sc.next();	
					System.out.println("휴가 이름");
					vacationName = sc.next();
					
					addSpecialVacation(length, vacationKind, vacationName, soldierID);
					break;
				
				case 2:
					System.out.println("<특별휴가 수정>");
					System.out.println("수정할 특별휴가 id");
					spVacationID = sc.nextInt();					
					getSpecialVacationList("where _id="+spVacationID);
					spvaca = specialVacationList.get(0);
					spvaca.showSpecialVacationInfo();
					
					System.out.println("휴가 길이");
					length = sc.nextInt();
					System.out.println("휴가 종류");
					vacationKind = sc.next();	
					System.out.println("휴가 이름");
					vacationName = sc.next();
					System.out.println("사용 여부");
					vacationID = sc.nextInt();
					
					updateSpecialVacation(spvaca.id,length,vacationKind,vacationName,vacationID);
					break;
					
				case 3:
					System.out.println("<특별휴가 삭제>");
					System.out.println("삭제할 특별휴가 id");
					spVacationID = sc.nextInt();					
					getSpecialVacationList("where _id="+spVacationID);
					spvaca = specialVacationList.get(0);
					spvaca.showSpecialVacationInfo();
					
					System.out.println("정말 삭제하시겠습니까 (Y/N)");
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
			System.out.println("존재하지 않는 이름입니다.");			
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
