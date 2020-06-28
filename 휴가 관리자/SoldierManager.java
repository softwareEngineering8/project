import java.util.*;

public class SoldierManager extends Manager {
	public void start() {
		System.out.println("<병사정보 관리자>입니다.");
		int id;
		String name;
		String soldierNumber;
		int generalVacation;
		String birth;
		
		boolean ch = true;
		
		Scanner sc = new Scanner(System.in);
		while(ch) {
			System.out.println("[0] 인원 리스트 출력");
			System.out.println("[1] 인원 추가");
			System.out.println("[2] 인원 정보 정정");
			System.out.println("[3] 인원 삭제");
			System.out.println("[4] 인원 상세 보기");
			System.out.println("[9] 취소");
			
			System.out.println("입력 : ");
			int button;
			button = sc.nextInt();
			
			Soldier s;
			switch(button) {
				case 0:
					System.out.println("<인원 리스트 출력>");
					showSoldierList();
				break;
				
				case 1:
					System.out.println("<인원 추가>");
					System.out.println("이름");
					name = sc.next();
					System.out.println("군번");
					soldierNumber = sc.next();	
					System.out.println("생일");
					birth = sc.next();
					addSoldier(name, soldierNumber, birth);
				break;
				
				case 2:
					System.out.println("<인원 정정>");
					System.out.println("정정할 인원의 이름");
					name = sc.next();					
					getSoldierList("where name='"+name+"'");
					s = soldierList.get(0);
					s.showSoldierInfo();
					
					System.out.println("수정할 이름");
					name = sc.next();
					System.out.println("수정할 군번");
					soldierNumber = sc.next();
					System.out.println("수정할 연가");
					generalVacation= sc.nextInt();
					System.out.println("수정할 생일");
					birth= sc.next();
					updateSoldier(s.id,name,soldierNumber, generalVacation, birth);
				break;
				
				case 3:
					System.out.println("<인원 삭제>");
					System.out.println("삭제할 인원의 이름");
					name = sc.next();					
					getSoldierList("where name='"+name+"'");
					s = soldierList.get(0);
					s.showSoldierInfo();
					
					System.out.println("정말 삭제하시겠습니까 (Y/N)");
					String temp = sc.next();
					if(temp.equals("Y")||temp.equals("y")) {
						deleteSoldier(s.id);
					}
					
				break;
				
				case 4:
					System.out.println("<인원 상세 보기>");
					System.out.println("자세히 볼 인원의 이름");
					name = sc.next();					
					getSoldierList("where name='"+name+"'");
					s = soldierList.get(0);
					s.showSoldierInfo();	
					
					System.out.println("<특별휴가 리스트>");
					getSpecialVacationList("where soldierID="+ s.id);
					
					for(int i=0;i<specialVacationList.size();i++) {
						SpecialVacation spvaca = specialVacationList.get(i);
						if (spvaca.vacationID == 0)
							temp = "X";	
						else if (spvaca.vacationID == -1)
							temp = "△";	
						else
							temp = "O";
						System.out.println("id:"+spvaca.id+" 휴가이름:"+spvaca.vacationName+" 길이:"+spvaca.length +" 사용여부:"+temp);
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
