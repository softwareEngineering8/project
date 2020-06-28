import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Scanner;
import java.time.*;
import java.time.temporal.ChronoUnit;

public class main_test {
	
	public static void main(String[] args) {		
		
		//SpecialVacationManager svm = new SpecialVacationManager();
		//svm.start();
		
		//SoldierManager sm = new SoldierManager();		
		//sm.start();
		
		VacationApplyManager app = new VacationApplyManager();
		app.start();
		
		//VacationApprovalManager app = new VacationApprovalManager();
		//app.start();
		
	}
}
