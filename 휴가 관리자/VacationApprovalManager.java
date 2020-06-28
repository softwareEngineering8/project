import java.time.ZonedDateTime;
import java.util.*;

public class VacationApprovalManager extends Manager{
	public void start() {
		Scanner sc = new Scanner(System.in);
		boolean ch = true;
		VacationApply va;
		
		while(ch)
		{
			showVacationApplyList();
			System.out.println("승인 또는 거절할 신청ID입력");
			int vacationApplyID = sc.nextInt();
			getVacationApplyList("where _ID = " + vacationApplyID);
			if (vacationApplyList.size()>0) {
				va = vacationApplyList.get(0);
				if(va.approvalCheck == 0)
				{
					showVacationApply(va);
					System.out.println("[0]승인   [1]거절   [ect]뒤로가기");
					int temp = sc.nextInt();
					if (temp == 0) {
						approveVacationApply(va);
					}
					else if (temp == 1) {
						approveVacationApply(va);
					}
				}
				else
					System.out.println("승인 대기 중인 휴가가 아닙니다.");
				
			}
			else {
				System.out.println("잘못 입력하셨습니다.");
			}
		}
		
	}
	
	private void showVacationApply(VacationApply va) {
		System.out.println("신청 id : " + va.id);
		if (va.kind == 1)
		{
			System.out.println("신청 종류 : 휴가 추가 신청");
			
			if (va.specialVacationID>0) {
				getSpecialVacationList("where _id="+va.specialVacationID);
				SpecialVacation spvaca = specialVacationList.get(0);
				System.out.println("휴가 내역 : 특별휴가 ["+spvaca.vacationName+"] "+ spvaca.length+"일 사용");
			}
			else {
				System.out.println("휴가 내역 : 연가 " + va.usedGeneralVacation+"일 사용");
			}
			
			ZonedDateTime date1 = standardDate.plusDays(va.departDate);
			ZonedDateTime date2 = standardDate.plusDays(va.arriveDate);
			
			System.out.println("출발 날짜 : " + date1);
			System.out.println("도착 날짜 : " + date2);
		}				
		if (va.kind == 2)
		{
			System.out.println("신청 종류 : 휴가 취소 신청");
		}
	}
	
	private void showVacationApplyList() {
		System.out.println("<휴가 신청 대기 목록>");
		
		getVacationApplyList("where approvalCheck = 0");
		for(int i=0; i < vacationApplyList.size();i++) {
			VacationApply va = vacationApplyList.get(i);
			if(va.approvalCheck == 0)
			{
				System.out.println("------------------------");
				showVacationApply(va);
				System.out.println("------------------------");
			}
				
		}
	}	
	
	private void approveVacationApply(VacationApply va) {
		updateQuery("INSERT INTO vacation(specialVacationID, usedGeneralVacation, departDate, arriveDate, soldierID) "
				+ "VALUES("+va.specialVacationID+","+va.usedGeneralVacation+","+va.departDate+", "+va.arriveDate+", "+va.soldierID+")");
		
		updateQuery("UPDATE vacationApply SET approvalCheck=1 WHERE _id=" + va.id);
	}
	
	private void rejectVacationApply(VacationApply va) {
		updateQuery("UPDATE vacationApply SET approvalCheck=-1 WHERE _id=" + va.id);
	}
	
}
