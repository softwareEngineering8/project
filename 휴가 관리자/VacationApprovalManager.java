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
			System.out.println("���� �Ǵ� ������ ��ûID�Է�");
			int vacationApplyID = sc.nextInt();
			getVacationApplyList("where _ID = " + vacationApplyID);
			if (vacationApplyList.size()>0) {
				va = vacationApplyList.get(0);
				if(va.approvalCheck == 0)
				{
					showVacationApply(va);
					System.out.println("[0]����   [1]����   [ect]�ڷΰ���");
					int temp = sc.nextInt();
					if (temp == 0) {
						approveVacationApply(va);
					}
					else if (temp == 1) {
						approveVacationApply(va);
					}
				}
				else
					System.out.println("���� ��� ���� �ް��� �ƴմϴ�.");
				
			}
			else {
				System.out.println("�߸� �Է��ϼ̽��ϴ�.");
			}
		}
		
	}
	
	private void showVacationApply(VacationApply va) {
		System.out.println("��û id : " + va.id);
		if (va.kind == 1)
		{
			System.out.println("��û ���� : �ް� �߰� ��û");
			
			if (va.specialVacationID>0) {
				getSpecialVacationList("where _id="+va.specialVacationID);
				SpecialVacation spvaca = specialVacationList.get(0);
				System.out.println("�ް� ���� : Ư���ް� ["+spvaca.vacationName+"] "+ spvaca.length+"�� ���");
			}
			else {
				System.out.println("�ް� ���� : ���� " + va.usedGeneralVacation+"�� ���");
			}
			
			ZonedDateTime date1 = standardDate.plusDays(va.departDate);
			ZonedDateTime date2 = standardDate.plusDays(va.arriveDate);
			
			System.out.println("��� ��¥ : " + date1);
			System.out.println("���� ��¥ : " + date2);
		}				
		if (va.kind == 2)
		{
			System.out.println("��û ���� : �ް� ��� ��û");
		}
	}
	
	private void showVacationApplyList() {
		System.out.println("<�ް� ��û ��� ���>");
		
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
