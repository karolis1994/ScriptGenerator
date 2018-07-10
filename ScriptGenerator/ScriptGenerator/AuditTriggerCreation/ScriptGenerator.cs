using System;
using System.Text;

namespace ScriptGenerator
{
    public partial class ScriptGenerator
    {
        private void auditBtn_Click(Object sender, EventArgs e)
        {
            StringBuilder scriptBuilder = new StringBuilder();

            scriptBuilder.Append($"CREATE OR REPLACE TRIGGER {auditSchemaTextBox.Text}.{auditTableNameTextBox.Text}.{auditTriggerNameTextBox.Text}{Environment.NewLine}");
            scriptBuilder.Append($"  BEFORE INSERT OR UPDATE ON {auditSchemaTextBox.Text}.{auditTableNameTextBox.Text}{Environment.NewLine}");
            scriptBuilder.Append($"  FOR EACH ROW{Environment.NewLine}");
            scriptBuilder.Append($"DECLARE{Environment.NewLine}");
            scriptBuilder.Append($"  ls_user VARCHAR2(250);{Environment.NewLine}");
            scriptBuilder.Append($"BEGIN{Environment.NewLine}");
            scriptBuilder.Append($"  SELECT NVL(settings.glob.s_current_user_name, MIN(vs.osuser)){Environment.NewLine}");
            scriptBuilder.Append($"    INTO ls_user{Environment.NewLine}");
            scriptBuilder.Append($"    FROM v$session vs{Environment.NewLine}");
            scriptBuilder.Append($"   WHERE vs.audsid = userenv('sessionid');{Environment.NewLine}");
            scriptBuilder.Append($"  IF INSERTING THEN{Environment.NewLine}");
            scriptBuilder.Append($"    :NEW.record_date := sysdate;{Environment.NewLine}");
            scriptBuilder.Append($"    IF :NEW.record_user IS NULL THEN{Environment.NewLine}");
            scriptBuilder.Append($"      :NEW.record_user := s_user;{Environment.NewLine}");
            scriptBuilder.Append($"    END IF;{Environment.NewLine}");
            scriptBuilder.Append($"  ELSE{Environment.NewLine}");
            scriptBuilder.Append($"    :NEW.edit_date := sysdate;{Environment.NewLine}");
            scriptBuilder.Append($"    IF :NEW.edit_user IS NULL THEN{Environment.NewLine}");
            scriptBuilder.Append($"      :NEW.edit_user := s_user;{Environment.NewLine}");
            scriptBuilder.Append($"    END IF;{Environment.NewLine}");
            scriptBuilder.Append($"  END IF;{Environment.NewLine}");
            scriptBuilder.Append($"END;");

            scriptTextBox.Text = scriptBuilder.ToString();
        }
    }
}
