def is_wmi_class(user_wmi_class: str) -> bool:
    """
    The function return whether wmi_class is valid wmi_class
    """
    WMI_CLASS_LOCATION = 1
    with open("wmiclasses_formated.txt", "r") as wmi_class_file:
        for line in wmi_class_file:
            wmi_class = line.split(":")[WMI_CLASS_LOCATION]
            if user_wmi_class == wmi_class:
                return True
        return False


def is_wmi_scope(user_wmi_scope: str) -> bool:
    """
    The function return whether user wmi_scope is valid
    """
    WMI_SCOPE_LOCATION = 0
    with open("wmiclasses_formated.txt", "r") as wmi_scope_file:
        for line in wmi_scope_file:
            wmi_scope = line.split(":")[WMI_SCOPE_LOCATION]
            if user_wmi_scope == wmi_scope:
                return True
        return False
