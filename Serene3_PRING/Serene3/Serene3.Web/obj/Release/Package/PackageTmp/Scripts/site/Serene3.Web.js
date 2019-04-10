var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var LanguageForm = /** @class */ (function (_super) {
            __extends(LanguageForm, _super);
            function LanguageForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!LanguageForm.init) {
                    LanguageForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    Q.initFormType(LanguageForm, [
                        'LanguageId', w0,
                        'LanguageName', w0
                    ]);
                }
                return _this;
            }
            LanguageForm.formKey = 'Administration.Language';
            return LanguageForm;
        }(Serenity.PrefixedContext));
        Administration.LanguageForm = LanguageForm;
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var LanguageRow;
        (function (LanguageRow) {
            LanguageRow.idProperty = 'Id';
            LanguageRow.nameProperty = 'LanguageName';
            LanguageRow.localTextPrefix = 'Administration.Language';
            LanguageRow.lookupKey = 'Administration.Language';
            function getLookup() {
                return Q.getLookup('Administration.Language');
            }
            LanguageRow.getLookup = getLookup;
        })(LanguageRow = Administration.LanguageRow || (Administration.LanguageRow = {}));
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var LanguageService;
        (function (LanguageService) {
            LanguageService.baseUrl = 'Administration/Language';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                LanguageService[x] = function (r, s, o) {
                    return Q.serviceRequest(LanguageService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(LanguageService = Administration.LanguageService || (Administration.LanguageService = {}));
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var RoleForm = /** @class */ (function (_super) {
            __extends(RoleForm, _super);
            function RoleForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!RoleForm.init) {
                    RoleForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    Q.initFormType(RoleForm, [
                        'RoleName', w0
                    ]);
                }
                return _this;
            }
            RoleForm.formKey = 'Administration.Role';
            return RoleForm;
        }(Serenity.PrefixedContext));
        Administration.RoleForm = RoleForm;
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var RolePermissionRow;
        (function (RolePermissionRow) {
            RolePermissionRow.idProperty = 'RolePermissionId';
            RolePermissionRow.nameProperty = 'PermissionKey';
            RolePermissionRow.localTextPrefix = 'Administration.RolePermission';
        })(RolePermissionRow = Administration.RolePermissionRow || (Administration.RolePermissionRow = {}));
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var RolePermissionService;
        (function (RolePermissionService) {
            RolePermissionService.baseUrl = 'Administration/RolePermission';
            [
                'Update',
                'List'
            ].forEach(function (x) {
                RolePermissionService[x] = function (r, s, o) {
                    return Q.serviceRequest(RolePermissionService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(RolePermissionService = Administration.RolePermissionService || (Administration.RolePermissionService = {}));
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var RoleRow;
        (function (RoleRow) {
            RoleRow.idProperty = 'RoleId';
            RoleRow.nameProperty = 'RoleName';
            RoleRow.localTextPrefix = 'Administration.Role';
            RoleRow.lookupKey = 'Administration.Role';
            function getLookup() {
                return Q.getLookup('Administration.Role');
            }
            RoleRow.getLookup = getLookup;
        })(RoleRow = Administration.RoleRow || (Administration.RoleRow = {}));
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var RoleService;
        (function (RoleService) {
            RoleService.baseUrl = 'Administration/Role';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                RoleService[x] = function (r, s, o) {
                    return Q.serviceRequest(RoleService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(RoleService = Administration.RoleService || (Administration.RoleService = {}));
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var TranslationService;
        (function (TranslationService) {
            TranslationService.baseUrl = 'Administration/Translation';
            [
                'List',
                'Update'
            ].forEach(function (x) {
                TranslationService[x] = function (r, s, o) {
                    return Q.serviceRequest(TranslationService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TranslationService = Administration.TranslationService || (Administration.TranslationService = {}));
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var UserForm = /** @class */ (function (_super) {
            __extends(UserForm, _super);
            function UserForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!UserForm.init) {
                    UserForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    var w1 = s.EmailEditor;
                    var w2 = s.ImageUploadEditor;
                    var w3 = s.PasswordEditor;
                    Q.initFormType(UserForm, [
                        'Username', w0,
                        'DisplayName', w0,
                        'Email', w1,
                        'UserImage', w2,
                        'Password', w3,
                        'PasswordConfirm', w3,
                        'Source', w0
                    ]);
                }
                return _this;
            }
            UserForm.formKey = 'Administration.User';
            return UserForm;
        }(Serenity.PrefixedContext));
        Administration.UserForm = UserForm;
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var UserPermissionRow;
        (function (UserPermissionRow) {
            UserPermissionRow.idProperty = 'UserPermissionId';
            UserPermissionRow.nameProperty = 'PermissionKey';
            UserPermissionRow.localTextPrefix = 'Administration.UserPermission';
        })(UserPermissionRow = Administration.UserPermissionRow || (Administration.UserPermissionRow = {}));
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var UserPermissionService;
        (function (UserPermissionService) {
            UserPermissionService.baseUrl = 'Administration/UserPermission';
            [
                'Update',
                'List',
                'ListRolePermissions',
                'ListPermissionKeys'
            ].forEach(function (x) {
                UserPermissionService[x] = function (r, s, o) {
                    return Q.serviceRequest(UserPermissionService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(UserPermissionService = Administration.UserPermissionService || (Administration.UserPermissionService = {}));
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var UserRoleRow;
        (function (UserRoleRow) {
            UserRoleRow.idProperty = 'UserRoleId';
            UserRoleRow.localTextPrefix = 'Administration.UserRole';
        })(UserRoleRow = Administration.UserRoleRow || (Administration.UserRoleRow = {}));
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var UserRoleService;
        (function (UserRoleService) {
            UserRoleService.baseUrl = 'Administration/UserRole';
            [
                'Update',
                'List'
            ].forEach(function (x) {
                UserRoleService[x] = function (r, s, o) {
                    return Q.serviceRequest(UserRoleService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(UserRoleService = Administration.UserRoleService || (Administration.UserRoleService = {}));
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var UserRow;
        (function (UserRow) {
            UserRow.idProperty = 'UserId';
            UserRow.isActiveProperty = 'IsActive';
            UserRow.nameProperty = 'Username';
            UserRow.localTextPrefix = 'Administration.User';
            UserRow.lookupKey = 'Administration.User';
            function getLookup() {
                return Q.getLookup('Administration.User');
            }
            UserRow.getLookup = getLookup;
        })(UserRow = Administration.UserRow || (Administration.UserRow = {}));
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var UserService;
        (function (UserService) {
            UserService.baseUrl = 'Administration/User';
            [
                'Create',
                'Update',
                'Delete',
                'Undelete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                UserService[x] = function (r, s, o) {
                    return Q.serviceRequest(UserService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(UserService = Administration.UserService || (Administration.UserService = {}));
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var BasicSamplesService;
        (function (BasicSamplesService) {
            BasicSamplesService.baseUrl = 'BasicSamples/BasicSamples';
            [
                'OrdersByShipper',
                'OrderBulkAction'
            ].forEach(function (x) {
                BasicSamplesService[x] = function (r, s, o) {
                    return Q.serviceRequest(BasicSamplesService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(BasicSamplesService = BasicSamples.BasicSamplesService || (BasicSamples.BasicSamplesService = {}));
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var ChangingLookupTextForm = /** @class */ (function (_super) {
            __extends(ChangingLookupTextForm, _super);
            function ChangingLookupTextForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!ChangingLookupTextForm.init) {
                    ChangingLookupTextForm.init = true;
                    var s = Serenity;
                    var w0 = BasicSamples.ChangingLookupTextEditor;
                    var w1 = s.DecimalEditor;
                    var w2 = s.IntegerEditor;
                    Q.initFormType(ChangingLookupTextForm, [
                        'ProductID', w0,
                        'UnitPrice', w1,
                        'Quantity', w2,
                        'Discount', w1
                    ]);
                }
                return _this;
            }
            ChangingLookupTextForm.formKey = 'BasicSamples.ChangingLookupText';
            return ChangingLookupTextForm;
        }(Serenity.PrefixedContext));
        BasicSamples.ChangingLookupTextForm = ChangingLookupTextForm;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var CustomerGrossSalesService;
        (function (CustomerGrossSalesService) {
            CustomerGrossSalesService.baseUrl = 'BasicSamples/CustomerGrossSales';
            [
                'List'
            ].forEach(function (x) {
                CustomerGrossSalesService[x] = function (r, s, o) {
                    return Q.serviceRequest(CustomerGrossSalesService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(CustomerGrossSalesService = BasicSamples.CustomerGrossSalesService || (BasicSamples.CustomerGrossSalesService = {}));
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var DragDropSampleForm = /** @class */ (function (_super) {
            __extends(DragDropSampleForm, _super);
            function DragDropSampleForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!DragDropSampleForm.init) {
                    DragDropSampleForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    Q.initFormType(DragDropSampleForm, [
                        'Title', w0
                    ]);
                }
                return _this;
            }
            DragDropSampleForm.formKey = 'BasicSamples.DragDropSample';
            return DragDropSampleForm;
        }(Serenity.PrefixedContext));
        BasicSamples.DragDropSampleForm = DragDropSampleForm;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var DragDropSampleRow;
        (function (DragDropSampleRow) {
            DragDropSampleRow.idProperty = 'Id';
            DragDropSampleRow.nameProperty = 'Title';
            DragDropSampleRow.localTextPrefix = 'Northwind.DragDropSample';
        })(DragDropSampleRow = BasicSamples.DragDropSampleRow || (BasicSamples.DragDropSampleRow = {}));
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var DragDropSampleService;
        (function (DragDropSampleService) {
            DragDropSampleService.baseUrl = 'BasicSamples/DragDropSample';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                DragDropSampleService[x] = function (r, s, o) {
                    return Q.serviceRequest(DragDropSampleService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(DragDropSampleService = BasicSamples.DragDropSampleService || (BasicSamples.DragDropSampleService = {}));
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var FilteredLookupInDetailForm = /** @class */ (function (_super) {
            __extends(FilteredLookupInDetailForm, _super);
            function FilteredLookupInDetailForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!FilteredLookupInDetailForm.init) {
                    FilteredLookupInDetailForm.init = true;
                    var s = Serenity;
                    var w0 = Serene3.Northwind.CustomerEditor;
                    var w1 = s.DateEditor;
                    var w2 = s.LookupEditor;
                    var w3 = BasicSamples.FilteredLookupDetailEditor;
                    Q.initFormType(FilteredLookupInDetailForm, [
                        'CustomerID', w0,
                        'OrderDate', w1,
                        'CategoryID', w2,
                        'DetailList', w3
                    ]);
                }
                return _this;
            }
            FilteredLookupInDetailForm.formKey = 'BasicSamples.FilteredLookupInDetail';
            return FilteredLookupInDetailForm;
        }(Serenity.PrefixedContext));
        BasicSamples.FilteredLookupInDetailForm = FilteredLookupInDetailForm;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var HardcodedValuesForm = /** @class */ (function (_super) {
            __extends(HardcodedValuesForm, _super);
            function HardcodedValuesForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!HardcodedValuesForm.init) {
                    HardcodedValuesForm.init = true;
                    var s = Serenity;
                    var w0 = BasicSamples.HardcodedValuesEditor;
                    Q.initFormType(HardcodedValuesForm, [
                        'SomeValue', w0
                    ]);
                }
                return _this;
            }
            HardcodedValuesForm.formKey = 'BasicSamples.HarcodedValues';
            return HardcodedValuesForm;
        }(Serenity.PrefixedContext));
        BasicSamples.HardcodedValuesForm = HardcodedValuesForm;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var LookupFilterByMultipleForm = /** @class */ (function (_super) {
            __extends(LookupFilterByMultipleForm, _super);
            function LookupFilterByMultipleForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!LookupFilterByMultipleForm.init) {
                    LookupFilterByMultipleForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    var w1 = s.ImageUploadEditor;
                    var w2 = s.BooleanEditor;
                    var w3 = s.LookupEditor;
                    var w4 = BasicSamples.ProduceSeafoodCategoryEditor;
                    var w5 = s.DecimalEditor;
                    var w6 = s.IntegerEditor;
                    Q.initFormType(LookupFilterByMultipleForm, [
                        'ProductName', w0,
                        'ProductImage', w1,
                        'Discontinued', w2,
                        'SupplierID', w3,
                        'CategoryID', w4,
                        'QuantityPerUnit', w0,
                        'UnitPrice', w5,
                        'UnitsInStock', w6,
                        'UnitsOnOrder', w6,
                        'ReorderLevel', w6
                    ]);
                }
                return _this;
            }
            LookupFilterByMultipleForm.formKey = 'BasicSamples.LookupFilterByMultiple';
            return LookupFilterByMultipleForm;
        }(Serenity.PrefixedContext));
        BasicSamples.LookupFilterByMultipleForm = LookupFilterByMultipleForm;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var PopulateLinkedDataForm = /** @class */ (function (_super) {
            __extends(PopulateLinkedDataForm, _super);
            function PopulateLinkedDataForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!PopulateLinkedDataForm.init) {
                    PopulateLinkedDataForm.init = true;
                    var s = Serenity;
                    var w0 = Serene3.Northwind.CustomerEditor;
                    var w1 = s.StringEditor;
                    var w2 = s.DateEditor;
                    var w3 = s.LookupEditor;
                    var w4 = Serene3.Northwind.OrderDetailsEditor;
                    Q.initFormType(PopulateLinkedDataForm, [
                        'CustomerID', w0,
                        'CustomerContactName', w1,
                        'CustomerContactTitle', w1,
                        'CustomerCity', w1,
                        'CustomerRegion', w1,
                        'CustomerCountry', w1,
                        'CustomerPhone', w1,
                        'CustomerFax', w1,
                        'OrderDate', w2,
                        'RequiredDate', w2,
                        'EmployeeID', w3,
                        'DetailList', w4
                    ]);
                }
                return _this;
            }
            PopulateLinkedDataForm.formKey = 'BasicSamples.PopulateLinkedData';
            return PopulateLinkedDataForm;
        }(Serenity.PrefixedContext));
        BasicSamples.PopulateLinkedDataForm = PopulateLinkedDataForm;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var ProductExcelImportForm = /** @class */ (function (_super) {
            __extends(ProductExcelImportForm, _super);
            function ProductExcelImportForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!ProductExcelImportForm.init) {
                    ProductExcelImportForm.init = true;
                    var s = Serenity;
                    var w0 = s.ImageUploadEditor;
                    Q.initFormType(ProductExcelImportForm, [
                        'FileName', w0
                    ]);
                }
                return _this;
            }
            ProductExcelImportForm.formKey = 'BasicSamples.ProductExcelImport';
            return ProductExcelImportForm;
        }(Serenity.PrefixedContext));
        BasicSamples.ProductExcelImportForm = ProductExcelImportForm;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var ProductExcelImportService;
        (function (ProductExcelImportService) {
            ProductExcelImportService.baseUrl = 'BasicSamples/ProductExcelImport';
            [
                'ExcelImport'
            ].forEach(function (x) {
                ProductExcelImportService[x] = function (r, s, o) {
                    return Q.serviceRequest(ProductExcelImportService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(ProductExcelImportService = BasicSamples.ProductExcelImportService || (BasicSamples.ProductExcelImportService = {}));
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var StaticTextBlockForm = /** @class */ (function (_super) {
            __extends(StaticTextBlockForm, _super);
            function StaticTextBlockForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!StaticTextBlockForm.init) {
                    StaticTextBlockForm.init = true;
                    var s = Serenity;
                    var w0 = Serene3.StaticTextBlock;
                    var w1 = s.StringEditor;
                    Q.initFormType(StaticTextBlockForm, [
                        'StaticText', w0,
                        'SomeInput', w1,
                        'HtmlList', w0,
                        'FromLocalText', w0,
                        'DisplayFieldValue', w0
                    ]);
                }
                return _this;
            }
            StaticTextBlockForm.formKey = 'BasicSamples.StaticTextBlock';
            return StaticTextBlockForm;
        }(Serenity.PrefixedContext));
        BasicSamples.StaticTextBlockForm = StaticTextBlockForm;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var VSGalleryQAService;
        (function (VSGalleryQAService) {
            VSGalleryQAService.baseUrl = 'BasicSamples/VSGalleryQA';
            [
                'List'
            ].forEach(function (x) {
                VSGalleryQAService[x] = function (r, s, o) {
                    return Q.serviceRequest(VSGalleryQAService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(VSGalleryQAService = BasicSamples.VSGalleryQAService || (BasicSamples.VSGalleryQAService = {}));
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Common;
    (function (Common) {
        var UserPreferenceRow;
        (function (UserPreferenceRow) {
            UserPreferenceRow.idProperty = 'UserPreferenceId';
            UserPreferenceRow.nameProperty = 'Name';
            UserPreferenceRow.localTextPrefix = 'Common.UserPreference';
        })(UserPreferenceRow = Common.UserPreferenceRow || (Common.UserPreferenceRow = {}));
    })(Common = Serene3.Common || (Serene3.Common = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Common;
    (function (Common) {
        var UserPreferenceService;
        (function (UserPreferenceService) {
            UserPreferenceService.baseUrl = 'Common/UserPreference';
            [
                'Update',
                'Retrieve'
            ].forEach(function (x) {
                UserPreferenceService[x] = function (r, s, o) {
                    return Q.serviceRequest(UserPreferenceService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(UserPreferenceService = Common.UserPreferenceService || (Common.UserPreferenceService = {}));
    })(Common = Serene3.Common || (Serene3.Common = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Membership;
    (function (Membership) {
        var ChangePasswordForm = /** @class */ (function (_super) {
            __extends(ChangePasswordForm, _super);
            function ChangePasswordForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!ChangePasswordForm.init) {
                    ChangePasswordForm.init = true;
                    var s = Serenity;
                    var w0 = s.PasswordEditor;
                    Q.initFormType(ChangePasswordForm, [
                        'OldPassword', w0,
                        'NewPassword', w0,
                        'ConfirmPassword', w0
                    ]);
                }
                return _this;
            }
            ChangePasswordForm.formKey = 'Membership.ChangePassword';
            return ChangePasswordForm;
        }(Serenity.PrefixedContext));
        Membership.ChangePasswordForm = ChangePasswordForm;
    })(Membership = Serene3.Membership || (Serene3.Membership = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Membership;
    (function (Membership) {
        var ForgotPasswordForm = /** @class */ (function (_super) {
            __extends(ForgotPasswordForm, _super);
            function ForgotPasswordForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!ForgotPasswordForm.init) {
                    ForgotPasswordForm.init = true;
                    var s = Serenity;
                    var w0 = s.EmailEditor;
                    Q.initFormType(ForgotPasswordForm, [
                        'Email', w0
                    ]);
                }
                return _this;
            }
            ForgotPasswordForm.formKey = 'Membership.ForgotPassword';
            return ForgotPasswordForm;
        }(Serenity.PrefixedContext));
        Membership.ForgotPasswordForm = ForgotPasswordForm;
    })(Membership = Serene3.Membership || (Serene3.Membership = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Membership;
    (function (Membership) {
        var LoginForm = /** @class */ (function (_super) {
            __extends(LoginForm, _super);
            function LoginForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!LoginForm.init) {
                    LoginForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    var w1 = s.PasswordEditor;
                    Q.initFormType(LoginForm, [
                        'Username', w0,
                        'Password', w1
                    ]);
                }
                return _this;
            }
            LoginForm.formKey = 'Membership.Login';
            return LoginForm;
        }(Serenity.PrefixedContext));
        Membership.LoginForm = LoginForm;
    })(Membership = Serene3.Membership || (Serene3.Membership = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Membership;
    (function (Membership) {
        var ResetPasswordForm = /** @class */ (function (_super) {
            __extends(ResetPasswordForm, _super);
            function ResetPasswordForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!ResetPasswordForm.init) {
                    ResetPasswordForm.init = true;
                    var s = Serenity;
                    var w0 = s.PasswordEditor;
                    Q.initFormType(ResetPasswordForm, [
                        'NewPassword', w0,
                        'ConfirmPassword', w0
                    ]);
                }
                return _this;
            }
            ResetPasswordForm.formKey = 'Membership.ResetPassword';
            return ResetPasswordForm;
        }(Serenity.PrefixedContext));
        Membership.ResetPasswordForm = ResetPasswordForm;
    })(Membership = Serene3.Membership || (Serene3.Membership = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Membership;
    (function (Membership) {
        var SignUpForm = /** @class */ (function (_super) {
            __extends(SignUpForm, _super);
            function SignUpForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!SignUpForm.init) {
                    SignUpForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    var w1 = s.EmailEditor;
                    var w2 = s.PasswordEditor;
                    Q.initFormType(SignUpForm, [
                        'DisplayName', w0,
                        'Email', w1,
                        'ConfirmEmail', w1,
                        'Password', w2,
                        'ConfirmPassword', w2
                    ]);
                }
                return _this;
            }
            SignUpForm.formKey = 'Membership.SignUp';
            return SignUpForm;
        }(Serenity.PrefixedContext));
        Membership.SignUpForm = SignUpForm;
    })(Membership = Serene3.Membership || (Serene3.Membership = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var CategoryForm = /** @class */ (function (_super) {
            __extends(CategoryForm, _super);
            function CategoryForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!CategoryForm.init) {
                    CategoryForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    Q.initFormType(CategoryForm, [
                        'CategoryName', w0,
                        'Description', w0
                    ]);
                }
                return _this;
            }
            CategoryForm.formKey = 'Northwind.Category';
            return CategoryForm;
        }(Serenity.PrefixedContext));
        Northwind.CategoryForm = CategoryForm;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var CategoryLangRow;
        (function (CategoryLangRow) {
            CategoryLangRow.idProperty = 'Id';
            CategoryLangRow.nameProperty = 'CategoryName';
            CategoryLangRow.localTextPrefix = 'Northwind.CategoryLang';
        })(CategoryLangRow = Northwind.CategoryLangRow || (Northwind.CategoryLangRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var CategoryLangService;
        (function (CategoryLangService) {
            CategoryLangService.baseUrl = 'Northwind/CategoryLang';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                CategoryLangService[x] = function (r, s, o) {
                    return Q.serviceRequest(CategoryLangService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(CategoryLangService = Northwind.CategoryLangService || (Northwind.CategoryLangService = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var CategoryRow;
        (function (CategoryRow) {
            CategoryRow.idProperty = 'CategoryID';
            CategoryRow.nameProperty = 'CategoryName';
            CategoryRow.localTextPrefix = 'Northwind.Category';
            CategoryRow.lookupKey = 'Northwind.Category';
            function getLookup() {
                return Q.getLookup('Northwind.Category');
            }
            CategoryRow.getLookup = getLookup;
        })(CategoryRow = Northwind.CategoryRow || (Northwind.CategoryRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var CategoryService;
        (function (CategoryService) {
            CategoryService.baseUrl = 'Northwind/Category';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                CategoryService[x] = function (r, s, o) {
                    return Q.serviceRequest(CategoryService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(CategoryService = Northwind.CategoryService || (Northwind.CategoryService = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var CustomerCustomerDemoRow;
        (function (CustomerCustomerDemoRow) {
            CustomerCustomerDemoRow.idProperty = 'ID';
            CustomerCustomerDemoRow.nameProperty = 'CustomerID';
            CustomerCustomerDemoRow.localTextPrefix = 'Northwind.CustomerCustomerDemo';
        })(CustomerCustomerDemoRow = Northwind.CustomerCustomerDemoRow || (Northwind.CustomerCustomerDemoRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var CustomerDemographicRow;
        (function (CustomerDemographicRow) {
            CustomerDemographicRow.idProperty = 'ID';
            CustomerDemographicRow.nameProperty = 'CustomerTypeID';
            CustomerDemographicRow.localTextPrefix = 'Northwind.CustomerDemographic';
        })(CustomerDemographicRow = Northwind.CustomerDemographicRow || (Northwind.CustomerDemographicRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var CustomerDetailsRow;
        (function (CustomerDetailsRow) {
            CustomerDetailsRow.idProperty = 'Id';
            CustomerDetailsRow.nameProperty = 'Email';
            CustomerDetailsRow.localTextPrefix = 'Northwind.CustomerDetails';
        })(CustomerDetailsRow = Northwind.CustomerDetailsRow || (Northwind.CustomerDetailsRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var CustomerForm = /** @class */ (function (_super) {
            __extends(CustomerForm, _super);
            function CustomerForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!CustomerForm.init) {
                    CustomerForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    var w1 = s.LookupEditor;
                    var w2 = Northwind.NotesEditor;
                    var w3 = s.DateEditor;
                    var w4 = s.EmailEditor;
                    var w5 = s.BooleanEditor;
                    Q.initFormType(CustomerForm, [
                        'CustomerID', w0,
                        'CompanyName', w0,
                        'ContactName', w0,
                        'ContactTitle', w0,
                        'Representatives', w1,
                        'Address', w0,
                        'Country', w1,
                        'City', w1,
                        'Region', w0,
                        'PostalCode', w0,
                        'Phone', w0,
                        'Fax', w0,
                        'NoteList', w2,
                        'LastContactDate', w3,
                        'LastContactedBy', w1,
                        'Email', w4,
                        'SendBulletin', w5
                    ]);
                }
                return _this;
            }
            CustomerForm.formKey = 'Northwind.Customer';
            return CustomerForm;
        }(Serenity.PrefixedContext));
        Northwind.CustomerForm = CustomerForm;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var CustomerGrossSalesRow;
        (function (CustomerGrossSalesRow) {
            CustomerGrossSalesRow.nameProperty = 'ContactName';
            CustomerGrossSalesRow.localTextPrefix = 'Northwind.CustomerGrossSales';
        })(CustomerGrossSalesRow = Northwind.CustomerGrossSalesRow || (Northwind.CustomerGrossSalesRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var CustomerRepresentativesRow;
        (function (CustomerRepresentativesRow) {
            CustomerRepresentativesRow.idProperty = 'RepresentativeId';
            CustomerRepresentativesRow.localTextPrefix = 'Northwind.CustomerRepresentatives';
        })(CustomerRepresentativesRow = Northwind.CustomerRepresentativesRow || (Northwind.CustomerRepresentativesRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var CustomerRow;
        (function (CustomerRow) {
            CustomerRow.idProperty = 'ID';
            CustomerRow.nameProperty = 'CompanyName';
            CustomerRow.localTextPrefix = 'Northwind.Customer';
            CustomerRow.lookupKey = 'Northwind.Customer';
            function getLookup() {
                return Q.getLookup('Northwind.Customer');
            }
            CustomerRow.getLookup = getLookup;
        })(CustomerRow = Northwind.CustomerRow || (Northwind.CustomerRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var CustomerService;
        (function (CustomerService) {
            CustomerService.baseUrl = 'Northwind/Customer';
            [
                'Create',
                'Update',
                'Delete',
                'GetNextNumber',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                CustomerService[x] = function (r, s, o) {
                    return Q.serviceRequest(CustomerService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(CustomerService = Northwind.CustomerService || (Northwind.CustomerService = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var EmployeeRow;
        (function (EmployeeRow) {
            EmployeeRow.idProperty = 'EmployeeID';
            EmployeeRow.nameProperty = 'FullName';
            EmployeeRow.localTextPrefix = 'Northwind.Employee';
            EmployeeRow.lookupKey = 'Northwind.Employee';
            function getLookup() {
                return Q.getLookup('Northwind.Employee');
            }
            EmployeeRow.getLookup = getLookup;
        })(EmployeeRow = Northwind.EmployeeRow || (Northwind.EmployeeRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var EmployeeTerritoryRow;
        (function (EmployeeTerritoryRow) {
            EmployeeTerritoryRow.idProperty = 'EmployeeID';
            EmployeeTerritoryRow.nameProperty = 'TerritoryID';
            EmployeeTerritoryRow.localTextPrefix = 'Northwind.EmployeeTerritory';
        })(EmployeeTerritoryRow = Northwind.EmployeeTerritoryRow || (Northwind.EmployeeTerritoryRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var Gender;
        (function (Gender) {
            Gender[Gender["Male"] = 1] = "Male";
            Gender[Gender["Female"] = 2] = "Female";
        })(Gender = Northwind.Gender || (Northwind.Gender = {}));
        Serenity.Decorators.registerEnumType(Gender, 'Serene3.Northwind.Gender', 'Serene3.Northwind.Entities.Gender');
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var NoteRow;
        (function (NoteRow) {
            NoteRow.idProperty = 'NoteId';
            NoteRow.nameProperty = 'EntityType';
            NoteRow.localTextPrefix = 'Northwind.Note';
        })(NoteRow = Northwind.NoteRow || (Northwind.NoteRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var OrderDetailForm = /** @class */ (function (_super) {
            __extends(OrderDetailForm, _super);
            function OrderDetailForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!OrderDetailForm.init) {
                    OrderDetailForm.init = true;
                    var s = Serenity;
                    var w0 = s.LookupEditor;
                    var w1 = s.DecimalEditor;
                    var w2 = s.IntegerEditor;
                    Q.initFormType(OrderDetailForm, [
                        'ProductID', w0,
                        'UnitPrice', w1,
                        'Quantity', w2,
                        'Discount', w1
                    ]);
                }
                return _this;
            }
            OrderDetailForm.formKey = 'Northwind.OrderDetail';
            return OrderDetailForm;
        }(Serenity.PrefixedContext));
        Northwind.OrderDetailForm = OrderDetailForm;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var OrderDetailRow;
        (function (OrderDetailRow) {
            OrderDetailRow.idProperty = 'DetailID';
            OrderDetailRow.localTextPrefix = 'Northwind.OrderDetail';
        })(OrderDetailRow = Northwind.OrderDetailRow || (Northwind.OrderDetailRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var OrderDetailService;
        (function (OrderDetailService) {
            OrderDetailService.baseUrl = 'Northwind/OrderDetail';
            [
                'Retrieve',
                'List'
            ].forEach(function (x) {
                OrderDetailService[x] = function (r, s, o) {
                    return Q.serviceRequest(OrderDetailService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(OrderDetailService = Northwind.OrderDetailService || (Northwind.OrderDetailService = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var OrderForm = /** @class */ (function (_super) {
            __extends(OrderForm, _super);
            function OrderForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!OrderForm.init) {
                    OrderForm.init = true;
                    var s = Serenity;
                    var w0 = Northwind.CustomerEditor;
                    var w1 = s.DateEditor;
                    var w2 = s.LookupEditor;
                    var w3 = Northwind.OrderDetailsEditor;
                    var w4 = s.DecimalEditor;
                    var w5 = s.StringEditor;
                    Q.initFormType(OrderForm, [
                        'CustomerID', w0,
                        'OrderDate', w1,
                        'RequiredDate', w1,
                        'EmployeeID', w2,
                        'DetailList', w3,
                        'ShippedDate', w1,
                        'ShipVia', w2,
                        'Freight', w4,
                        'ShipName', w5,
                        'ShipAddress', w5,
                        'ShipCity', w5,
                        'ShipRegion', w5,
                        'ShipPostalCode', w5,
                        'ShipCountry', w5
                    ]);
                }
                return _this;
            }
            OrderForm.formKey = 'Northwind.Order';
            return OrderForm;
        }(Serenity.PrefixedContext));
        Northwind.OrderForm = OrderForm;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var OrderRow;
        (function (OrderRow) {
            OrderRow.idProperty = 'OrderID';
            OrderRow.nameProperty = 'CustomerID';
            OrderRow.localTextPrefix = 'Northwind.Order';
        })(OrderRow = Northwind.OrderRow || (Northwind.OrderRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var OrderService;
        (function (OrderService) {
            OrderService.baseUrl = 'Northwind/Order';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                OrderService[x] = function (r, s, o) {
                    return Q.serviceRequest(OrderService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(OrderService = Northwind.OrderService || (Northwind.OrderService = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var OrderShippingState;
        (function (OrderShippingState) {
            OrderShippingState[OrderShippingState["NotShipped"] = 0] = "NotShipped";
            OrderShippingState[OrderShippingState["Shipped"] = 1] = "Shipped";
        })(OrderShippingState = Northwind.OrderShippingState || (Northwind.OrderShippingState = {}));
        Serenity.Decorators.registerEnumType(OrderShippingState, 'Serene3.Northwind.OrderShippingState', 'Northwind.OrderShippingState');
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var ProductForm = /** @class */ (function (_super) {
            __extends(ProductForm, _super);
            function ProductForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!ProductForm.init) {
                    ProductForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    var w1 = s.ImageUploadEditor;
                    var w2 = s.BooleanEditor;
                    var w3 = s.LookupEditor;
                    var w4 = s.DecimalEditor;
                    var w5 = s.IntegerEditor;
                    Q.initFormType(ProductForm, [
                        'ProductName', w0,
                        'ProductImage', w1,
                        'Discontinued', w2,
                        'SupplierID', w3,
                        'CategoryID', w3,
                        'QuantityPerUnit', w0,
                        'UnitPrice', w4,
                        'UnitsInStock', w5,
                        'UnitsOnOrder', w5,
                        'ReorderLevel', w5
                    ]);
                }
                return _this;
            }
            ProductForm.formKey = 'Northwind.Product';
            return ProductForm;
        }(Serenity.PrefixedContext));
        Northwind.ProductForm = ProductForm;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var ProductLangRow;
        (function (ProductLangRow) {
            ProductLangRow.idProperty = 'Id';
            ProductLangRow.nameProperty = 'ProductName';
            ProductLangRow.localTextPrefix = 'Northwind.ProductLang';
        })(ProductLangRow = Northwind.ProductLangRow || (Northwind.ProductLangRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var ProductLangService;
        (function (ProductLangService) {
            ProductLangService.baseUrl = 'Northwind/ProductLang';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                ProductLangService[x] = function (r, s, o) {
                    return Q.serviceRequest(ProductLangService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(ProductLangService = Northwind.ProductLangService || (Northwind.ProductLangService = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var ProductLogRow;
        (function (ProductLogRow) {
            ProductLogRow.idProperty = 'ProductLogID';
            ProductLogRow.localTextPrefix = 'Northwind.ProductLog';
        })(ProductLogRow = Northwind.ProductLogRow || (Northwind.ProductLogRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var ProductRow;
        (function (ProductRow) {
            ProductRow.idProperty = 'ProductID';
            ProductRow.nameProperty = 'ProductName';
            ProductRow.localTextPrefix = 'Northwind.Product';
            ProductRow.lookupKey = 'Northwind.Product';
            function getLookup() {
                return Q.getLookup('Northwind.Product');
            }
            ProductRow.getLookup = getLookup;
        })(ProductRow = Northwind.ProductRow || (Northwind.ProductRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var ProductService;
        (function (ProductService) {
            ProductService.baseUrl = 'Northwind/Product';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                ProductService[x] = function (r, s, o) {
                    return Q.serviceRequest(ProductService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(ProductService = Northwind.ProductService || (Northwind.ProductService = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var RegionForm = /** @class */ (function (_super) {
            __extends(RegionForm, _super);
            function RegionForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!RegionForm.init) {
                    RegionForm.init = true;
                    var s = Serenity;
                    var w0 = s.IntegerEditor;
                    var w1 = s.StringEditor;
                    Q.initFormType(RegionForm, [
                        'RegionID', w0,
                        'RegionDescription', w1
                    ]);
                }
                return _this;
            }
            RegionForm.formKey = 'Northwind.Region';
            return RegionForm;
        }(Serenity.PrefixedContext));
        Northwind.RegionForm = RegionForm;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var RegionRow;
        (function (RegionRow) {
            RegionRow.idProperty = 'RegionID';
            RegionRow.nameProperty = 'RegionDescription';
            RegionRow.localTextPrefix = 'Northwind.Region';
            RegionRow.lookupKey = 'Northwind.Region';
            function getLookup() {
                return Q.getLookup('Northwind.Region');
            }
            RegionRow.getLookup = getLookup;
        })(RegionRow = Northwind.RegionRow || (Northwind.RegionRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var RegionService;
        (function (RegionService) {
            RegionService.baseUrl = 'Northwind/Region';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                RegionService[x] = function (r, s, o) {
                    return Q.serviceRequest(RegionService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(RegionService = Northwind.RegionService || (Northwind.RegionService = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var SalesByCategoryRow;
        (function (SalesByCategoryRow) {
            SalesByCategoryRow.nameProperty = 'CategoryName';
            SalesByCategoryRow.localTextPrefix = 'Northwind.SalesByCategory';
        })(SalesByCategoryRow = Northwind.SalesByCategoryRow || (Northwind.SalesByCategoryRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var SalesByCategoryService;
        (function (SalesByCategoryService) {
            SalesByCategoryService.baseUrl = 'Northwind/SalesByCategory';
            [
                'List'
            ].forEach(function (x) {
                SalesByCategoryService[x] = function (r, s, o) {
                    return Q.serviceRequest(SalesByCategoryService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(SalesByCategoryService = Northwind.SalesByCategoryService || (Northwind.SalesByCategoryService = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var ShipperForm = /** @class */ (function (_super) {
            __extends(ShipperForm, _super);
            function ShipperForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!ShipperForm.init) {
                    ShipperForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    var w1 = Northwind.PhoneEditor;
                    Q.initFormType(ShipperForm, [
                        'CompanyName', w0,
                        'Phone', w1
                    ]);
                }
                return _this;
            }
            ShipperForm.formKey = 'Northwind.Shipper';
            return ShipperForm;
        }(Serenity.PrefixedContext));
        Northwind.ShipperForm = ShipperForm;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var ShipperRow;
        (function (ShipperRow) {
            ShipperRow.idProperty = 'ShipperID';
            ShipperRow.nameProperty = 'CompanyName';
            ShipperRow.localTextPrefix = 'Northwind.Shipper';
            ShipperRow.lookupKey = 'Northwind.Shipper';
            function getLookup() {
                return Q.getLookup('Northwind.Shipper');
            }
            ShipperRow.getLookup = getLookup;
        })(ShipperRow = Northwind.ShipperRow || (Northwind.ShipperRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var ShipperService;
        (function (ShipperService) {
            ShipperService.baseUrl = 'Northwind/Shipper';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                ShipperService[x] = function (r, s, o) {
                    return Q.serviceRequest(ShipperService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(ShipperService = Northwind.ShipperService || (Northwind.ShipperService = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var SupplierForm = /** @class */ (function (_super) {
            __extends(SupplierForm, _super);
            function SupplierForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!SupplierForm.init) {
                    SupplierForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    Q.initFormType(SupplierForm, [
                        'CompanyName', w0,
                        'ContactName', w0,
                        'ContactTitle', w0,
                        'Address', w0,
                        'Region', w0,
                        'PostalCode', w0,
                        'Country', w0,
                        'City', w0,
                        'Phone', w0,
                        'Fax', w0,
                        'HomePage', w0
                    ]);
                }
                return _this;
            }
            SupplierForm.formKey = 'Northwind.Supplier';
            return SupplierForm;
        }(Serenity.PrefixedContext));
        Northwind.SupplierForm = SupplierForm;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var SupplierRow;
        (function (SupplierRow) {
            SupplierRow.idProperty = 'SupplierID';
            SupplierRow.nameProperty = 'CompanyName';
            SupplierRow.localTextPrefix = 'Northwind.Supplier';
            SupplierRow.lookupKey = 'Northwind.Supplier';
            function getLookup() {
                return Q.getLookup('Northwind.Supplier');
            }
            SupplierRow.getLookup = getLookup;
        })(SupplierRow = Northwind.SupplierRow || (Northwind.SupplierRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var SupplierService;
        (function (SupplierService) {
            SupplierService.baseUrl = 'Northwind/Supplier';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                SupplierService[x] = function (r, s, o) {
                    return Q.serviceRequest(SupplierService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(SupplierService = Northwind.SupplierService || (Northwind.SupplierService = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var TerritoryForm = /** @class */ (function (_super) {
            __extends(TerritoryForm, _super);
            function TerritoryForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TerritoryForm.init) {
                    TerritoryForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    var w1 = s.LookupEditor;
                    Q.initFormType(TerritoryForm, [
                        'TerritoryID', w0,
                        'TerritoryDescription', w0,
                        'RegionID', w1
                    ]);
                }
                return _this;
            }
            TerritoryForm.formKey = 'Northwind.Territory';
            return TerritoryForm;
        }(Serenity.PrefixedContext));
        Northwind.TerritoryForm = TerritoryForm;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var TerritoryRow;
        (function (TerritoryRow) {
            TerritoryRow.idProperty = 'ID';
            TerritoryRow.nameProperty = 'TerritoryID';
            TerritoryRow.localTextPrefix = 'Northwind.Territory';
            TerritoryRow.lookupKey = 'Northwind.Territory';
            function getLookup() {
                return Q.getLookup('Northwind.Territory');
            }
            TerritoryRow.getLookup = getLookup;
        })(TerritoryRow = Northwind.TerritoryRow || (Northwind.TerritoryRow = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var TerritoryService;
        (function (TerritoryService) {
            TerritoryService.baseUrl = 'Northwind/Territory';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TerritoryService[x] = function (r, s, o) {
                    return Q.serviceRequest(TerritoryService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TerritoryService = Northwind.TerritoryService || (Northwind.TerritoryService = {}));
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblBanThanhPhamForm = /** @class */ (function (_super) {
            __extends(TblBanThanhPhamForm, _super);
            function TblBanThanhPhamForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblBanThanhPhamForm.init) {
                    TblBanThanhPhamForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    var w1 = s.DateEditor;
                    var w2 = s.BooleanEditor;
                    Q.initFormType(TblBanThanhPhamForm, [
                        'MotaBtp', w0,
                        'DonViTinh', w0,
                        'NgayTao', w1,
                        'Status', w2
                    ]);
                }
                return _this;
            }
            TblBanThanhPhamForm.formKey = 'SpringPrintingConnection.TblBanThanhPham';
            return TblBanThanhPhamForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblBanThanhPhamForm = TblBanThanhPhamForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblBanThanhPhamRow;
        (function (TblBanThanhPhamRow) {
            TblBanThanhPhamRow.idProperty = 'KeyId';
            TblBanThanhPhamRow.nameProperty = 'MotaBtp';
            TblBanThanhPhamRow.localTextPrefix = 'SpringPrintingConnection.TblBanThanhPham';
            TblBanThanhPhamRow.lookupKey = 'SpringPrintingConnection.TblBanThanhPham';
            function getLookup() {
                return Q.getLookup('SpringPrintingConnection.TblBanThanhPham');
            }
            TblBanThanhPhamRow.getLookup = getLookup;
        })(TblBanThanhPhamRow = SpringPrintingConnection.TblBanThanhPhamRow || (SpringPrintingConnection.TblBanThanhPhamRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblBanThanhPhamService;
        (function (TblBanThanhPhamService) {
            TblBanThanhPhamService.baseUrl = 'SpringPrintingConnection/TblBanThanhPham';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblBanThanhPhamService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblBanThanhPhamService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblBanThanhPhamService = SpringPrintingConnection.TblBanThanhPhamService || (SpringPrintingConnection.TblBanThanhPhamService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblBoBtpForm = /** @class */ (function (_super) {
            __extends(TblBoBtpForm, _super);
            function TblBoBtpForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblBoBtpForm.init) {
                    TblBoBtpForm.init = true;
                    var s = Serenity;
                    var w0 = s.IntegerEditor;
                    var w1 = s.LookupEditor;
                    Q.initFormType(TblBoBtpForm, [
                        'MaLo', w0,
                        'MaBtp', w1,
                        'SlThuc', w0,
                        'SlLoiKh', w0,
                        'SlLoiIn', w0,
                        'MaMau', w1,
                        'MaSize', w1,
                        'MaHd', w1,
                        'TypeID', w1
                    ]);
                }
                return _this;
            }
            TblBoBtpForm.formKey = 'SpringPrintingConnection.TblBoBtp';
            return TblBoBtpForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblBoBtpForm = TblBoBtpForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblBoBtpRow;
        (function (TblBoBtpRow) {
            TblBoBtpRow.idProperty = 'KeyId';
            TblBoBtpRow.nameProperty = 'Code';
            TblBoBtpRow.localTextPrefix = 'SpringPrintingConnection.TblBoBtp';
        })(TblBoBtpRow = SpringPrintingConnection.TblBoBtpRow || (SpringPrintingConnection.TblBoBtpRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblBoBtpService;
        (function (TblBoBtpService) {
            TblBoBtpService.baseUrl = 'SpringPrintingConnection/TblBoBtp';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List',
                'GetData'
            ].forEach(function (x) {
                TblBoBtpService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblBoBtpService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblBoBtpService = SpringPrintingConnection.TblBoBtpService || (SpringPrintingConnection.TblBoBtpService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblBo_BTPForm = /** @class */ (function (_super) {
            __extends(TblBo_BTPForm, _super);
            function TblBo_BTPForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblBo_BTPForm.init) {
                    TblBo_BTPForm.init = true;
                    var s = Serenity;
                    var w0 = s.IntegerEditor;
                    var w1 = s.LookupEditor;
                    Q.initFormType(TblBo_BTPForm, [
                        'MaLo', w0,
                        'MaBtp', w1,
                        'SlThuc', w0,
                        'SlLoiKh', w0,
                        'SlLoiIn', w0,
                        'MaMau', w1,
                        'MaSize', w1,
                        'MaStyle', w1,
                        'MaHd', w1,
                        'TypeID', w1
                    ]);
                }
                return _this;
            }
            TblBo_BTPForm.formKey = 'SpringPrintingConnection.TblBo_BTP';
            return TblBo_BTPForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblBo_BTPForm = TblBo_BTPForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblBo_BTPRow;
        (function (TblBo_BTPRow) {
            TblBo_BTPRow.idProperty = 'KeyId';
            TblBo_BTPRow.nameProperty = 'MaBtpMotaBtp';
            TblBo_BTPRow.localTextPrefix = 'SpringPrintingConnection.TblBo_BTP';
            TblBo_BTPRow.lookupKey = 'SpringPrintingConnection.TblBo_BTP';
            function getLookup() {
                return Q.getLookup('SpringPrintingConnection.TblBo_BTP');
            }
            TblBo_BTPRow.getLookup = getLookup;
        })(TblBo_BTPRow = SpringPrintingConnection.TblBo_BTPRow || (SpringPrintingConnection.TblBo_BTPRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblBo_BTPService;
        (function (TblBo_BTPService) {
            TblBo_BTPService.baseUrl = 'SpringPrintingConnection/TblBo_BTP';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblBo_BTPService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblBo_BTPService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblBo_BTPService = SpringPrintingConnection.TblBo_BTPService || (SpringPrintingConnection.TblBo_BTPService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblFeCardInfoForm = /** @class */ (function (_super) {
            __extends(TblFeCardInfoForm, _super);
            function TblFeCardInfoForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblFeCardInfoForm.init) {
                    TblFeCardInfoForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    var w1 = s.DateEditor;
                    Q.initFormType(TblFeCardInfoForm, [
                        'CardId', w0,
                        'RefBarCode', w0,
                        'CreateTime', w1,
                        'ImportTime', w1
                    ]);
                }
                return _this;
            }
            TblFeCardInfoForm.formKey = 'SpringPrintingConnection.TblFeCardInfo';
            return TblFeCardInfoForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblFeCardInfoForm = TblFeCardInfoForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblFeCardInfoRow;
        (function (TblFeCardInfoRow) {
            TblFeCardInfoRow.idProperty = 'RecId';
            TblFeCardInfoRow.nameProperty = 'RefBarCode';
            TblFeCardInfoRow.localTextPrefix = 'SpringPrintingConnection.TblFeCardInfo';
        })(TblFeCardInfoRow = SpringPrintingConnection.TblFeCardInfoRow || (SpringPrintingConnection.TblFeCardInfoRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblFeCardInfoService;
        (function (TblFeCardInfoService) {
            TblFeCardInfoService.baseUrl = 'SpringPrintingConnection/TblFeCardInfo';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblFeCardInfoService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblFeCardInfoService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblFeCardInfoService = SpringPrintingConnection.TblFeCardInfoService || (SpringPrintingConnection.TblFeCardInfoService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblFeStockOutInfoForm = /** @class */ (function (_super) {
            __extends(TblFeStockOutInfoForm, _super);
            function TblFeStockOutInfoForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblFeStockOutInfoForm.init) {
                    TblFeStockOutInfoForm.init = true;
                    var s = Serenity;
                    var w0 = s.IntegerEditor;
                    var w1 = s.DateEditor;
                    var w2 = s.StringEditor;
                    Q.initFormType(TblFeStockOutInfoForm, [
                        'RfidOutputId', w0,
                        'DDate', w1,
                        'Fty', w2,
                        'Po', w2,
                        'Fepo', w2,
                        'CardId', w2,
                        'Code', w2,
                        'BulNo', w0,
                        'TableNum', w2,
                        'Buy', w2,
                        'Style04', w2,
                        'Col', w2,
                        'Size', w2,
                        'Part', w2,
                        'OpNo', w2,
                        'OpName', w2,
                        'Quantity', w0,
                        'ImportTime', w1
                    ]);
                }
                return _this;
            }
            TblFeStockOutInfoForm.formKey = 'SpringPrintingConnection.TblFeStockOutInfo';
            return TblFeStockOutInfoForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblFeStockOutInfoForm = TblFeStockOutInfoForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblFeStockOutInfoRow;
        (function (TblFeStockOutInfoRow) {
            TblFeStockOutInfoRow.idProperty = 'RecId';
            TblFeStockOutInfoRow.nameProperty = 'Fty';
            TblFeStockOutInfoRow.localTextPrefix = 'SpringPrintingConnection.TblFeStockOutInfo';
        })(TblFeStockOutInfoRow = SpringPrintingConnection.TblFeStockOutInfoRow || (SpringPrintingConnection.TblFeStockOutInfoRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblFeStockOutInfoService;
        (function (TblFeStockOutInfoService) {
            TblFeStockOutInfoService.baseUrl = 'SpringPrintingConnection/TblFeStockOutInfo';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblFeStockOutInfoService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblFeStockOutInfoService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblFeStockOutInfoService = SpringPrintingConnection.TblFeStockOutInfoService || (SpringPrintingConnection.TblFeStockOutInfoService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDongChiTietForm = /** @class */ (function (_super) {
            __extends(TblHopDongChiTietForm, _super);
            function TblHopDongChiTietForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblHopDongChiTietForm.init) {
                    TblHopDongChiTietForm.init = true;
                    var s = Serenity;
                    var w0 = s.IntegerEditor;
                    var w1 = s.LookupEditor;
                    var w2 = s.DecimalEditor;
                    Q.initFormType(TblHopDongChiTietForm, [
                        'KeyId', w0,
                        'MaBtp', w1,
                        'MaMau', w1,
                        'MaSize', w1,
                        'MaStyle', w1,
                        'SoLuong', w0,
                        'DonGia', w2,
                        'ThanhTien', w2
                    ]);
                }
                return _this;
            }
            TblHopDongChiTietForm.formKey = 'SpringPrintingConnection.TblHopDongChiTiet';
            return TblHopDongChiTietForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblHopDongChiTietForm = TblHopDongChiTietForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDongChiTietRow;
        (function (TblHopDongChiTietRow) {
            TblHopDongChiTietRow.idProperty = 'KeyId';
            TblHopDongChiTietRow.localTextPrefix = 'SpringPrintingConnection.TblHopDongChiTiet';
            TblHopDongChiTietRow.lookupKey = 'SpringPrintingConnection.TblHopDongChiTiet';
            function getLookup() {
                return Q.getLookup('SpringPrintingConnection.TblHopDongChiTiet');
            }
            TblHopDongChiTietRow.getLookup = getLookup;
        })(TblHopDongChiTietRow = SpringPrintingConnection.TblHopDongChiTietRow || (SpringPrintingConnection.TblHopDongChiTietRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDongChiTietService;
        (function (TblHopDongChiTietService) {
            TblHopDongChiTietService.baseUrl = 'SpringPrintingConnection/TblHopDongChiTiet';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblHopDongChiTietService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblHopDongChiTietService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblHopDongChiTietService = SpringPrintingConnection.TblHopDongChiTietService || (SpringPrintingConnection.TblHopDongChiTietService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDongDieuChinhForm = /** @class */ (function (_super) {
            __extends(TblHopDongDieuChinhForm, _super);
            function TblHopDongDieuChinhForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblHopDongDieuChinhForm.init) {
                    TblHopDongDieuChinhForm.init = true;
                    var s = Serenity;
                    var w0 = s.LookupEditor;
                    var w1 = s.IntegerEditor;
                    var w2 = s.DateEditor;
                    Q.initFormType(TblHopDongDieuChinhForm, [
                        'MaChiTietHd', w0,
                        'SlNhan', w1,
                        'SlNhanHu', w1,
                        'SlInHu', w1,
                        'SlXuat', w1,
                        'MaNv', w0,
                        'NgayDc', w2
                    ]);
                }
                return _this;
            }
            TblHopDongDieuChinhForm.formKey = 'SpringPrintingConnection.TblHopDongDieuChinh';
            return TblHopDongDieuChinhForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblHopDongDieuChinhForm = TblHopDongDieuChinhForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDongDieuChinhRow;
        (function (TblHopDongDieuChinhRow) {
            TblHopDongDieuChinhRow.idProperty = 'KeyId';
            TblHopDongDieuChinhRow.localTextPrefix = 'SpringPrintingConnection.TblHopDongDieuChinh';
        })(TblHopDongDieuChinhRow = SpringPrintingConnection.TblHopDongDieuChinhRow || (SpringPrintingConnection.TblHopDongDieuChinhRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDongDieuChinhService;
        (function (TblHopDongDieuChinhService) {
            TblHopDongDieuChinhService.baseUrl = 'SpringPrintingConnection/TblHopDongDieuChinh';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblHopDongDieuChinhService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblHopDongDieuChinhService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblHopDongDieuChinhService = SpringPrintingConnection.TblHopDongDieuChinhService || (SpringPrintingConnection.TblHopDongDieuChinhService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDongForm = /** @class */ (function (_super) {
            __extends(TblHopDongForm, _super);
            function TblHopDongForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblHopDongForm.init) {
                    TblHopDongForm.init = true;
                    var s = Serenity;
                    var w0 = s.LookupEditor;
                    var w1 = s.DateEditor;
                    var w2 = s.StringEditor;
                    var w3 = s.DecimalEditor;
                    var w4 = SpringPrintingConnection.TblHopDongChiTiet_Editor;
                    Q.initFormType(TblHopDongForm, [
                        'MaKh', w0,
                        'NgayHd', w1,
                        'NoiDung', w2,
                        'GiaTri', w3,
                        'SoHd', w2,
                        'NvTao', w0,
                        'DetailList', w4
                    ]);
                }
                return _this;
            }
            TblHopDongForm.formKey = 'SpringPrintingConnection.TblHopDong';
            return TblHopDongForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblHopDongForm = TblHopDongForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDongRow;
        (function (TblHopDongRow) {
            TblHopDongRow.idProperty = 'KeyId';
            TblHopDongRow.nameProperty = 'SoHd';
            TblHopDongRow.localTextPrefix = 'SpringPrintingConnection.TblHopDong';
            TblHopDongRow.lookupKey = 'SpringPrintingConnection.TblHopDong';
            function getLookup() {
                return Q.getLookup('SpringPrintingConnection.TblHopDong');
            }
            TblHopDongRow.getLookup = getLookup;
        })(TblHopDongRow = SpringPrintingConnection.TblHopDongRow || (SpringPrintingConnection.TblHopDongRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDongService;
        (function (TblHopDongService) {
            TblHopDongService.baseUrl = 'SpringPrintingConnection/TblHopDong';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblHopDongService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblHopDongService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblHopDongService = SpringPrintingConnection.TblHopDongService || (SpringPrintingConnection.TblHopDongService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDong_ChiTietForm = /** @class */ (function (_super) {
            __extends(TblHopDong_ChiTietForm, _super);
            function TblHopDong_ChiTietForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblHopDong_ChiTietForm.init) {
                    TblHopDong_ChiTietForm.init = true;
                    var s = Serenity;
                    var w0 = s.IntegerEditor;
                    var w1 = s.LookupEditor;
                    var w2 = s.DecimalEditor;
                    var w3 = SpringPrintingConnection.TblHopDong_DieuChinhEditor;
                    Q.initFormType(TblHopDong_ChiTietForm, [
                        'KeyId', w0,
                        'MaBtp', w1,
                        'MaMau', w1,
                        'MaSize', w1,
                        'MaStyle', w1,
                        'SoLuong', w0,
                        'DonGia', w2,
                        'ThanhTien', w2,
                        'AdjDetailList', w3
                    ]);
                }
                return _this;
            }
            TblHopDong_ChiTietForm.formKey = 'SpringPrintingConnection.TblHopDong_ChiTiet';
            return TblHopDong_ChiTietForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblHopDong_ChiTietForm = TblHopDong_ChiTietForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDong_ChiTietRow;
        (function (TblHopDong_ChiTietRow) {
            TblHopDong_ChiTietRow.idProperty = 'KeyId';
            TblHopDong_ChiTietRow.localTextPrefix = 'SpringPrintingConnection.TblHopDong_ChiTiet';
        })(TblHopDong_ChiTietRow = SpringPrintingConnection.TblHopDong_ChiTietRow || (SpringPrintingConnection.TblHopDong_ChiTietRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDong_ChiTietService;
        (function (TblHopDong_ChiTietService) {
            TblHopDong_ChiTietService.baseUrl = 'SpringPrintingConnection/TblHopDong_ChiTiet';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblHopDong_ChiTietService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblHopDong_ChiTietService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblHopDong_ChiTietService = SpringPrintingConnection.TblHopDong_ChiTietService || (SpringPrintingConnection.TblHopDong_ChiTietService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDong_DieuChinhForm = /** @class */ (function (_super) {
            __extends(TblHopDong_DieuChinhForm, _super);
            function TblHopDong_DieuChinhForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblHopDong_DieuChinhForm.init) {
                    TblHopDong_DieuChinhForm.init = true;
                    var s = Serenity;
                    var w0 = s.LookupEditor;
                    var w1 = s.IntegerEditor;
                    var w2 = s.DateEditor;
                    Q.initFormType(TblHopDong_DieuChinhForm, [
                        'MaNv', w0,
                        'SlNhan', w1,
                        'SlNhanHu', w1,
                        'SlInHu', w1,
                        'SlXuat', w1,
                        'NgayDc', w2
                    ]);
                }
                return _this;
            }
            TblHopDong_DieuChinhForm.formKey = 'SpringPrintingConnection.TblHopDong_DieuChinh';
            return TblHopDong_DieuChinhForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblHopDong_DieuChinhForm = TblHopDong_DieuChinhForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDong_DieuChinhRow;
        (function (TblHopDong_DieuChinhRow) {
            TblHopDong_DieuChinhRow.idProperty = 'KeyId';
            TblHopDong_DieuChinhRow.localTextPrefix = 'SpringPrintingConnection.TblHopDong_DieuChinh';
        })(TblHopDong_DieuChinhRow = SpringPrintingConnection.TblHopDong_DieuChinhRow || (SpringPrintingConnection.TblHopDong_DieuChinhRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDong_DieuChinhService;
        (function (TblHopDong_DieuChinhService) {
            TblHopDong_DieuChinhService.baseUrl = 'SpringPrintingConnection/TblHopDong_DieuChinh';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblHopDong_DieuChinhService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblHopDong_DieuChinhService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblHopDong_DieuChinhService = SpringPrintingConnection.TblHopDong_DieuChinhService || (SpringPrintingConnection.TblHopDong_DieuChinhService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblKhachHangForm = /** @class */ (function (_super) {
            __extends(TblKhachHangForm, _super);
            function TblKhachHangForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblKhachHangForm.init) {
                    TblKhachHangForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    var w1 = s.IntegerEditor;
                    Q.initFormType(TblKhachHangForm, [
                        'MaKh', w0,
                        'TenKh', w0,
                        'DiaChi', w0,
                        'NguoiDaiDien', w1,
                        'Phone', w0,
                        'Mst', w0
                    ]);
                }
                return _this;
            }
            TblKhachHangForm.formKey = 'SpringPrintingConnection.TblKhachHang';
            return TblKhachHangForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblKhachHangForm = TblKhachHangForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblKhachHangRow;
        (function (TblKhachHangRow) {
            TblKhachHangRow.idProperty = 'KeyId';
            TblKhachHangRow.nameProperty = 'TenKh';
            TblKhachHangRow.localTextPrefix = 'SpringPrintingConnection.TblKhachHang';
            TblKhachHangRow.lookupKey = 'SpringPrintingConnection.TblKhachHang';
            function getLookup() {
                return Q.getLookup('SpringPrintingConnection.TblKhachHang');
            }
            TblKhachHangRow.getLookup = getLookup;
        })(TblKhachHangRow = SpringPrintingConnection.TblKhachHangRow || (SpringPrintingConnection.TblKhachHangRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblKhachHangService;
        (function (TblKhachHangService) {
            TblKhachHangService.baseUrl = 'SpringPrintingConnection/TblKhachHang';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblKhachHangService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblKhachHangService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblKhachHangService = SpringPrintingConnection.TblKhachHangService || (SpringPrintingConnection.TblKhachHangService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLenChuyenForm = /** @class */ (function (_super) {
            __extends(TblLenChuyenForm, _super);
            function TblLenChuyenForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblLenChuyenForm.init) {
                    TblLenChuyenForm.init = true;
                    var s = Serenity;
                    var w0 = s.LookupEditor;
                    var w1 = s.DateEditor;
                    var w2 = SpringPrintingConnection.TblLenChuyenIn_ChiTietEditor;
                    Q.initFormType(TblLenChuyenForm, [
                        'MaNvQuet', w0,
                        'Ngay', w1,
                        'DetailList', w2
                    ]);
                }
                return _this;
            }
            TblLenChuyenForm.formKey = 'SpringPrintingConnection.TblLenChuyen';
            return TblLenChuyenForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblLenChuyenForm = TblLenChuyenForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLenChuyenInChiTietForm = /** @class */ (function (_super) {
            __extends(TblLenChuyenInChiTietForm, _super);
            function TblLenChuyenInChiTietForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblLenChuyenInChiTietForm.init) {
                    TblLenChuyenInChiTietForm.init = true;
                    var s = Serenity;
                    var w0 = s.IntegerEditor;
                    var w1 = s.DateEditor;
                    Q.initFormType(TblLenChuyenInChiTietForm, [
                        'MaBo', w0,
                        'Ngay', w1,
                        'MaLenChuyen', w0,
                        'CT_SL_Thuc', w0,
                        'CT_SL_Loi_KH', w0
                    ]);
                }
                return _this;
            }
            TblLenChuyenInChiTietForm.formKey = 'SpringPrintingConnection.TblLenChuyenInChiTiet';
            return TblLenChuyenInChiTietForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblLenChuyenInChiTietForm = TblLenChuyenInChiTietForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLenChuyenInChiTietRow;
        (function (TblLenChuyenInChiTietRow) {
            TblLenChuyenInChiTietRow.idProperty = 'KeyId';
            TblLenChuyenInChiTietRow.localTextPrefix = 'SpringPrintingConnection.TblLenChuyenInChiTiet';
        })(TblLenChuyenInChiTietRow = SpringPrintingConnection.TblLenChuyenInChiTietRow || (SpringPrintingConnection.TblLenChuyenInChiTietRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLenChuyenInChiTietService;
        (function (TblLenChuyenInChiTietService) {
            TblLenChuyenInChiTietService.baseUrl = 'SpringPrintingConnection/TblLenChuyenInChiTiet';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List',
                'GetData'
            ].forEach(function (x) {
                TblLenChuyenInChiTietService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblLenChuyenInChiTietService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblLenChuyenInChiTietService = SpringPrintingConnection.TblLenChuyenInChiTietService || (SpringPrintingConnection.TblLenChuyenInChiTietService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLenChuyenIn_ChiTietForm = /** @class */ (function (_super) {
            __extends(TblLenChuyenIn_ChiTietForm, _super);
            function TblLenChuyenIn_ChiTietForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblLenChuyenIn_ChiTietForm.init) {
                    TblLenChuyenIn_ChiTietForm.init = true;
                    var s = Serenity;
                    var w0 = s.LookupEditor;
                    var w1 = s.DateEditor;
                    var w2 = s.BooleanEditor;
                    var w3 = s.IntegerEditor;
                    Q.initFormType(TblLenChuyenIn_ChiTietForm, [
                        'MaBo', w0,
                        'Ngay', w1,
                        'Status', w2,
                        'MaLenChuyen', w3
                    ]);
                }
                return _this;
            }
            TblLenChuyenIn_ChiTietForm.formKey = 'SpringPrintingConnection.TblLenChuyenIn_ChiTiet';
            return TblLenChuyenIn_ChiTietForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblLenChuyenIn_ChiTietForm = TblLenChuyenIn_ChiTietForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLenChuyenIn_ChiTietRow;
        (function (TblLenChuyenIn_ChiTietRow) {
            TblLenChuyenIn_ChiTietRow.idProperty = 'KeyId';
            TblLenChuyenIn_ChiTietRow.localTextPrefix = 'SpringPrintingConnection.TblLenChuyenIn_ChiTiet';
        })(TblLenChuyenIn_ChiTietRow = SpringPrintingConnection.TblLenChuyenIn_ChiTietRow || (SpringPrintingConnection.TblLenChuyenIn_ChiTietRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLenChuyenIn_ChiTietService;
        (function (TblLenChuyenIn_ChiTietService) {
            TblLenChuyenIn_ChiTietService.baseUrl = 'SpringPrintingConnection/TblLenChuyenIn_ChiTiet';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblLenChuyenIn_ChiTietService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblLenChuyenIn_ChiTietService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblLenChuyenIn_ChiTietService = SpringPrintingConnection.TblLenChuyenIn_ChiTietService || (SpringPrintingConnection.TblLenChuyenIn_ChiTietService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLenChuyenRow;
        (function (TblLenChuyenRow) {
            TblLenChuyenRow.idProperty = 'KeyId';
            TblLenChuyenRow.localTextPrefix = 'SpringPrintingConnection.TblLenChuyen';
        })(TblLenChuyenRow = SpringPrintingConnection.TblLenChuyenRow || (SpringPrintingConnection.TblLenChuyenRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLenChuyenService;
        (function (TblLenChuyenService) {
            TblLenChuyenService.baseUrl = 'SpringPrintingConnection/TblLenChuyen';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblLenChuyenService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblLenChuyenService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblLenChuyenService = SpringPrintingConnection.TblLenChuyenService || (SpringPrintingConnection.TblLenChuyenService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLoSpForm = /** @class */ (function (_super) {
            __extends(TblLoSpForm, _super);
            function TblLoSpForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblLoSpForm.init) {
                    TblLoSpForm.init = true;
                    var s = Serenity;
                    var w0 = s.IntegerEditor;
                    var w1 = s.LookupEditor;
                    var w2 = s.DateEditor;
                    var w3 = s.StringEditor;
                    var w4 = SpringPrintingConnection.TblBo_BTPEditor;
                    Q.initFormType(TblLoSpForm, [
                        'KeyId', w0,
                        'MaKh', w1,
                        'NgayNhap', w2,
                        'NguoiNhap', w1,
                        'SoLuong', w0,
                        'GhiChu', w3,
                        'DetailList', w4
                    ]);
                }
                return _this;
            }
            TblLoSpForm.formKey = 'SpringPrintingConnection.TblLoSp';
            return TblLoSpForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblLoSpForm = TblLoSpForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLoSpRow;
        (function (TblLoSpRow) {
            TblLoSpRow.idProperty = 'KeyId';
            TblLoSpRow.nameProperty = 'TenKH';
            TblLoSpRow.localTextPrefix = 'SpringPrintingConnection.TblLoSp';
            TblLoSpRow.lookupKey = 'SpringPrintingConnection.TblLoSp';
            function getLookup() {
                return Q.getLookup('SpringPrintingConnection.TblLoSp');
            }
            TblLoSpRow.getLookup = getLookup;
        })(TblLoSpRow = SpringPrintingConnection.TblLoSpRow || (SpringPrintingConnection.TblLoSpRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLoSpService;
        (function (TblLoSpService) {
            TblLoSpService.baseUrl = 'SpringPrintingConnection/TblLoSp';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List',
                'GetData'
            ].forEach(function (x) {
                TblLoSpService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblLoSpService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblLoSpService = SpringPrintingConnection.TblLoSpService || (SpringPrintingConnection.TblLoSpService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblNguoiDungForm = /** @class */ (function (_super) {
            __extends(TblNguoiDungForm, _super);
            function TblNguoiDungForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblNguoiDungForm.init) {
                    TblNguoiDungForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    var w1 = s.LookupEditor;
                    var w2 = s.EmailEditor;
                    var w3 = s.BooleanEditor;
                    Q.initFormType(TblNguoiDungForm, [
                        'HoTen', w0,
                        'GioiTinh', w1,
                        'Phone', w0,
                        'Mobile', w0,
                        'Email', w2,
                        'ChucVu', w0,
                        'Status', w3
                    ]);
                }
                return _this;
            }
            TblNguoiDungForm.formKey = 'SpringPrintingConnection.TblNguoiDung';
            return TblNguoiDungForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblNguoiDungForm = TblNguoiDungForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblNguoiDungRow;
        (function (TblNguoiDungRow) {
            TblNguoiDungRow.idProperty = 'KeyId';
            TblNguoiDungRow.nameProperty = 'HoTen';
            TblNguoiDungRow.localTextPrefix = 'SpringPrintingConnection.TblNguoiDung';
            TblNguoiDungRow.lookupKey = 'SpringPrintingConnection.TblNguoiDung';
            function getLookup() {
                return Q.getLookup('SpringPrintingConnection.TblNguoiDung');
            }
            TblNguoiDungRow.getLookup = getLookup;
        })(TblNguoiDungRow = SpringPrintingConnection.TblNguoiDungRow || (SpringPrintingConnection.TblNguoiDungRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblNguoiDungService;
        (function (TblNguoiDungService) {
            TblNguoiDungService.baseUrl = 'SpringPrintingConnection/TblNguoiDung';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblNguoiDungService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblNguoiDungService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblNguoiDungService = SpringPrintingConnection.TblNguoiDungService || (SpringPrintingConnection.TblNguoiDungService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefMauForm = /** @class */ (function (_super) {
            __extends(TblRefMauForm, _super);
            function TblRefMauForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblRefMauForm.init) {
                    TblRefMauForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    Q.initFormType(TblRefMauForm, [
                        'MaMau', w0,
                        'TenMau', w0
                    ]);
                }
                return _this;
            }
            TblRefMauForm.formKey = 'SpringPrintingConnection.TblRefMau';
            return TblRefMauForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblRefMauForm = TblRefMauForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefMauRow;
        (function (TblRefMauRow) {
            TblRefMauRow.idProperty = 'KeyId';
            TblRefMauRow.nameProperty = 'TenMau';
            TblRefMauRow.localTextPrefix = 'SpringPrintingConnection.TblRefMau';
            TblRefMauRow.lookupKey = 'SpringPrintingConnection.TblRefMau';
            function getLookup() {
                return Q.getLookup('SpringPrintingConnection.TblRefMau');
            }
            TblRefMauRow.getLookup = getLookup;
        })(TblRefMauRow = SpringPrintingConnection.TblRefMauRow || (SpringPrintingConnection.TblRefMauRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefMauService;
        (function (TblRefMauService) {
            TblRefMauService.baseUrl = 'SpringPrintingConnection/TblRefMau';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblRefMauService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblRefMauService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblRefMauService = SpringPrintingConnection.TblRefMauService || (SpringPrintingConnection.TblRefMauService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefNguoiDaiDienForm = /** @class */ (function (_super) {
            __extends(TblRefNguoiDaiDienForm, _super);
            function TblRefNguoiDaiDienForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblRefNguoiDaiDienForm.init) {
                    TblRefNguoiDaiDienForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    var w1 = s.LookupEditor;
                    var w2 = s.EmailEditor;
                    var w3 = s.BooleanEditor;
                    Q.initFormType(TblRefNguoiDaiDienForm, [
                        'HoTen', w0,
                        'GioiTinh', w1,
                        'Phone', w0,
                        'Mobile', w0,
                        'Email', w2,
                        'ChucVu', w0,
                        'MaKh', w1,
                        'Status', w3
                    ]);
                }
                return _this;
            }
            TblRefNguoiDaiDienForm.formKey = 'SpringPrintingConnection.TblRefNguoiDaiDien';
            return TblRefNguoiDaiDienForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblRefNguoiDaiDienForm = TblRefNguoiDaiDienForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefNguoiDaiDienRow;
        (function (TblRefNguoiDaiDienRow) {
            TblRefNguoiDaiDienRow.idProperty = 'KeyId';
            TblRefNguoiDaiDienRow.nameProperty = 'HoTen';
            TblRefNguoiDaiDienRow.localTextPrefix = 'SpringPrintingConnection.TblRefNguoiDaiDien';
            TblRefNguoiDaiDienRow.lookupKey = 'SpringPrintingConnection.TblRefNguoiDaiDien';
            function getLookup() {
                return Q.getLookup('SpringPrintingConnection.TblRefNguoiDaiDien');
            }
            TblRefNguoiDaiDienRow.getLookup = getLookup;
        })(TblRefNguoiDaiDienRow = SpringPrintingConnection.TblRefNguoiDaiDienRow || (SpringPrintingConnection.TblRefNguoiDaiDienRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefNguoiDaiDienService;
        (function (TblRefNguoiDaiDienService) {
            TblRefNguoiDaiDienService.baseUrl = 'SpringPrintingConnection/TblRefNguoiDaiDien';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblRefNguoiDaiDienService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblRefNguoiDaiDienService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblRefNguoiDaiDienService = SpringPrintingConnection.TblRefNguoiDaiDienService || (SpringPrintingConnection.TblRefNguoiDaiDienService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefSexForm = /** @class */ (function (_super) {
            __extends(TblRefSexForm, _super);
            function TblRefSexForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblRefSexForm.init) {
                    TblRefSexForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    Q.initFormType(TblRefSexForm, [
                        'SexName', w0
                    ]);
                }
                return _this;
            }
            TblRefSexForm.formKey = 'SpringPrintingConnection.TblRefSex';
            return TblRefSexForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblRefSexForm = TblRefSexForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefSexRow;
        (function (TblRefSexRow) {
            TblRefSexRow.idProperty = 'SexId';
            TblRefSexRow.nameProperty = 'SexId';
            TblRefSexRow.localTextPrefix = 'SpringPrintingConnection.TblRefSex';
            TblRefSexRow.lookupKey = 'SpringPrintingConnection.TblRefSex';
            function getLookup() {
                return Q.getLookup('SpringPrintingConnection.TblRefSex');
            }
            TblRefSexRow.getLookup = getLookup;
        })(TblRefSexRow = SpringPrintingConnection.TblRefSexRow || (SpringPrintingConnection.TblRefSexRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefSexService;
        (function (TblRefSexService) {
            TblRefSexService.baseUrl = 'SpringPrintingConnection/TblRefSex';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblRefSexService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblRefSexService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblRefSexService = SpringPrintingConnection.TblRefSexService || (SpringPrintingConnection.TblRefSexService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefSizeForm = /** @class */ (function (_super) {
            __extends(TblRefSizeForm, _super);
            function TblRefSizeForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblRefSizeForm.init) {
                    TblRefSizeForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    Q.initFormType(TblRefSizeForm, [
                        'MaSize', w0,
                        'TenSize', w0
                    ]);
                }
                return _this;
            }
            TblRefSizeForm.formKey = 'SpringPrintingConnection.TblRefSize';
            return TblRefSizeForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblRefSizeForm = TblRefSizeForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefSizeRow;
        (function (TblRefSizeRow) {
            TblRefSizeRow.idProperty = 'KeyId';
            TblRefSizeRow.nameProperty = 'TenSize';
            TblRefSizeRow.localTextPrefix = 'SpringPrintingConnection.TblRefSize';
            TblRefSizeRow.lookupKey = 'SpringPrintingConnection.TblRefSize';
            function getLookup() {
                return Q.getLookup('SpringPrintingConnection.TblRefSize');
            }
            TblRefSizeRow.getLookup = getLookup;
        })(TblRefSizeRow = SpringPrintingConnection.TblRefSizeRow || (SpringPrintingConnection.TblRefSizeRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefSizeService;
        (function (TblRefSizeService) {
            TblRefSizeService.baseUrl = 'SpringPrintingConnection/TblRefSize';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblRefSizeService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblRefSizeService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblRefSizeService = SpringPrintingConnection.TblRefSizeService || (SpringPrintingConnection.TblRefSizeService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefStyleForm = /** @class */ (function (_super) {
            __extends(TblRefStyleForm, _super);
            function TblRefStyleForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblRefStyleForm.init) {
                    TblRefStyleForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    Q.initFormType(TblRefStyleForm, [
                        'MaStyle', w0,
                        'TenStyle', w0
                    ]);
                }
                return _this;
            }
            TblRefStyleForm.formKey = 'SpringPrintingConnection.TblRefStyle';
            return TblRefStyleForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblRefStyleForm = TblRefStyleForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefStyleRow;
        (function (TblRefStyleRow) {
            TblRefStyleRow.idProperty = 'KeyId';
            TblRefStyleRow.nameProperty = 'TenStyle';
            TblRefStyleRow.localTextPrefix = 'SpringPrintingConnection.TblRefStyle';
            TblRefStyleRow.lookupKey = 'SpringPrintingConnection.TblRefStyle';
            function getLookup() {
                return Q.getLookup('SpringPrintingConnection.TblRefStyle');
            }
            TblRefStyleRow.getLookup = getLookup;
        })(TblRefStyleRow = SpringPrintingConnection.TblRefStyleRow || (SpringPrintingConnection.TblRefStyleRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefStyleService;
        (function (TblRefStyleService) {
            TblRefStyleService.baseUrl = 'SpringPrintingConnection/TblRefStyle';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblRefStyleService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblRefStyleService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblRefStyleService = SpringPrintingConnection.TblRefStyleService || (SpringPrintingConnection.TblRefStyleService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefTypeForm = /** @class */ (function (_super) {
            __extends(TblRefTypeForm, _super);
            function TblRefTypeForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblRefTypeForm.init) {
                    TblRefTypeForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    Q.initFormType(TblRefTypeForm, [
                        'TypeName', w0
                    ]);
                }
                return _this;
            }
            TblRefTypeForm.formKey = 'SpringPrintingConnection.TblRefType';
            return TblRefTypeForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblRefTypeForm = TblRefTypeForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefTypeRow;
        (function (TblRefTypeRow) {
            TblRefTypeRow.idProperty = 'TypeId';
            TblRefTypeRow.nameProperty = 'TypeName';
            TblRefTypeRow.localTextPrefix = 'SpringPrintingConnection.TblRefType';
            TblRefTypeRow.lookupKey = 'SpringPrintingConnection.TblRefType';
            function getLookup() {
                return Q.getLookup('SpringPrintingConnection.TblRefType');
            }
            TblRefTypeRow.getLookup = getLookup;
        })(TblRefTypeRow = SpringPrintingConnection.TblRefTypeRow || (SpringPrintingConnection.TblRefTypeRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefTypeService;
        (function (TblRefTypeService) {
            TblRefTypeService.baseUrl = 'SpringPrintingConnection/TblRefType';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblRefTypeService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblRefTypeService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblRefTypeService = SpringPrintingConnection.TblRefTypeService || (SpringPrintingConnection.TblRefTypeService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuatKhoChiTietForm = /** @class */ (function (_super) {
            __extends(TblXuatKhoChiTietForm, _super);
            function TblXuatKhoChiTietForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblXuatKhoChiTietForm.init) {
                    TblXuatKhoChiTietForm.init = true;
                    var s = Serenity;
                    var w0 = s.IntegerEditor;
                    var w1 = s.DateEditor;
                    var w2 = s.BooleanEditor;
                    Q.initFormType(TblXuatKhoChiTietForm, [
                        'MaBo', w0,
                        'Ngay', w1,
                        'Status', w2,
                        'MaPhieuXuat', w0
                    ]);
                }
                return _this;
            }
            TblXuatKhoChiTietForm.formKey = 'SpringPrintingConnection.TblXuatKhoChiTiet';
            return TblXuatKhoChiTietForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblXuatKhoChiTietForm = TblXuatKhoChiTietForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuatKhoChiTietRow;
        (function (TblXuatKhoChiTietRow) {
            TblXuatKhoChiTietRow.idProperty = 'KeyId';
            TblXuatKhoChiTietRow.localTextPrefix = 'SpringPrintingConnection.TblXuatKhoChiTiet';
        })(TblXuatKhoChiTietRow = SpringPrintingConnection.TblXuatKhoChiTietRow || (SpringPrintingConnection.TblXuatKhoChiTietRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuatKhoChiTietService;
        (function (TblXuatKhoChiTietService) {
            TblXuatKhoChiTietService.baseUrl = 'SpringPrintingConnection/TblXuatKhoChiTiet';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List',
                'GetData'
            ].forEach(function (x) {
                TblXuatKhoChiTietService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblXuatKhoChiTietService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblXuatKhoChiTietService = SpringPrintingConnection.TblXuatKhoChiTietService || (SpringPrintingConnection.TblXuatKhoChiTietService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuatKhoKhForm = /** @class */ (function (_super) {
            __extends(TblXuatKhoKhForm, _super);
            function TblXuatKhoKhForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblXuatKhoKhForm.init) {
                    TblXuatKhoKhForm.init = true;
                    var s = Serenity;
                    var w0 = s.LookupEditor;
                    var w1 = s.DateEditor;
                    var w2 = s.StringEditor;
                    var w3 = SpringPrintingConnection.TblXuatKho_ChiTietEditor;
                    Q.initFormType(TblXuatKhoKhForm, [
                        'MaKh', w0,
                        'NgayXuat', w1,
                        'MaNvXuat', w0,
                        'SoPhieu', w2,
                        'Ghichu', w2,
                        'DetailList', w3
                    ]);
                }
                return _this;
            }
            TblXuatKhoKhForm.formKey = 'SpringPrintingConnection.TblXuatKhoKh';
            return TblXuatKhoKhForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblXuatKhoKhForm = TblXuatKhoKhForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuatKhoKhRow;
        (function (TblXuatKhoKhRow) {
            TblXuatKhoKhRow.idProperty = 'KeyId';
            TblXuatKhoKhRow.nameProperty = 'SoPhieu';
            TblXuatKhoKhRow.localTextPrefix = 'SpringPrintingConnection.TblXuatKhoKh';
        })(TblXuatKhoKhRow = SpringPrintingConnection.TblXuatKhoKhRow || (SpringPrintingConnection.TblXuatKhoKhRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuatKhoKhService;
        (function (TblXuatKhoKhService) {
            TblXuatKhoKhService.baseUrl = 'SpringPrintingConnection/TblXuatKhoKh';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblXuatKhoKhService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblXuatKhoKhService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblXuatKhoKhService = SpringPrintingConnection.TblXuatKhoKhService || (SpringPrintingConnection.TblXuatKhoKhService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuatKho_ChiTietForm = /** @class */ (function (_super) {
            __extends(TblXuatKho_ChiTietForm, _super);
            function TblXuatKho_ChiTietForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblXuatKho_ChiTietForm.init) {
                    TblXuatKho_ChiTietForm.init = true;
                    var s = Serenity;
                    var w0 = s.LookupEditor;
                    var w1 = s.DateEditor;
                    var w2 = s.BooleanEditor;
                    var w3 = s.IntegerEditor;
                    Q.initFormType(TblXuatKho_ChiTietForm, [
                        'MaBo', w0,
                        'Ngay', w1,
                        'Status', w2,
                        'MaPhieuXuat', w3
                    ]);
                }
                return _this;
            }
            TblXuatKho_ChiTietForm.formKey = 'SpringPrintingConnection.TblXuatKho_ChiTiet';
            return TblXuatKho_ChiTietForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblXuatKho_ChiTietForm = TblXuatKho_ChiTietForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuatKho_ChiTietRow;
        (function (TblXuatKho_ChiTietRow) {
            TblXuatKho_ChiTietRow.idProperty = 'KeyId';
            TblXuatKho_ChiTietRow.localTextPrefix = 'SpringPrintingConnection.TblXuatKho_ChiTiet';
        })(TblXuatKho_ChiTietRow = SpringPrintingConnection.TblXuatKho_ChiTietRow || (SpringPrintingConnection.TblXuatKho_ChiTietRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuatKho_ChiTietService;
        (function (TblXuatKho_ChiTietService) {
            TblXuatKho_ChiTietService.baseUrl = 'SpringPrintingConnection/TblXuatKho_ChiTiet';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblXuatKho_ChiTietService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblXuatKho_ChiTietService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblXuatKho_ChiTietService = SpringPrintingConnection.TblXuatKho_ChiTietService || (SpringPrintingConnection.TblXuatKho_ChiTietService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuongChuyenForm = /** @class */ (function (_super) {
            __extends(TblXuongChuyenForm, _super);
            function TblXuongChuyenForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblXuongChuyenForm.init) {
                    TblXuongChuyenForm.init = true;
                    var s = Serenity;
                    var w0 = s.LookupEditor;
                    var w1 = s.DateEditor;
                    var w2 = SpringPrintingConnection.TblXuongChuyenIn_ChiTietEditor;
                    Q.initFormType(TblXuongChuyenForm, [
                        'MaNvQuet', w0,
                        'Ngay', w1,
                        'DetailList', w2
                    ]);
                }
                return _this;
            }
            TblXuongChuyenForm.formKey = 'SpringPrintingConnection.TblXuongChuyen';
            return TblXuongChuyenForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblXuongChuyenForm = TblXuongChuyenForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuongChuyenInChiTietForm = /** @class */ (function (_super) {
            __extends(TblXuongChuyenInChiTietForm, _super);
            function TblXuongChuyenInChiTietForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblXuongChuyenInChiTietForm.init) {
                    TblXuongChuyenInChiTietForm.init = true;
                    var s = Serenity;
                    var w0 = s.IntegerEditor;
                    var w1 = s.DateEditor;
                    var w2 = s.BooleanEditor;
                    Q.initFormType(TblXuongChuyenInChiTietForm, [
                        'MaBo', w0,
                        'Ngay', w1,
                        'MaXuongChuyen', w0,
                        'Status', w2,
                        'CT_SL_Thuc', w0,
                        'CT_SL_Loi_KH', w0,
                        'LoiIn', w0
                    ]);
                }
                return _this;
            }
            TblXuongChuyenInChiTietForm.formKey = 'SpringPrintingConnection.TblXuongChuyenInChiTiet';
            return TblXuongChuyenInChiTietForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblXuongChuyenInChiTietForm = TblXuongChuyenInChiTietForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuongChuyenInChiTietRow;
        (function (TblXuongChuyenInChiTietRow) {
            TblXuongChuyenInChiTietRow.idProperty = 'KeyId';
            TblXuongChuyenInChiTietRow.localTextPrefix = 'SpringPrintingConnection.TblXuongChuyenInChiTiet';
        })(TblXuongChuyenInChiTietRow = SpringPrintingConnection.TblXuongChuyenInChiTietRow || (SpringPrintingConnection.TblXuongChuyenInChiTietRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuongChuyenInChiTietService;
        (function (TblXuongChuyenInChiTietService) {
            TblXuongChuyenInChiTietService.baseUrl = 'SpringPrintingConnection/TblXuongChuyenInChiTiet';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List',
                'GetData'
            ].forEach(function (x) {
                TblXuongChuyenInChiTietService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblXuongChuyenInChiTietService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblXuongChuyenInChiTietService = SpringPrintingConnection.TblXuongChuyenInChiTietService || (SpringPrintingConnection.TblXuongChuyenInChiTietService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuongChuyenIn_ChiTietForm = /** @class */ (function (_super) {
            __extends(TblXuongChuyenIn_ChiTietForm, _super);
            function TblXuongChuyenIn_ChiTietForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!TblXuongChuyenIn_ChiTietForm.init) {
                    TblXuongChuyenIn_ChiTietForm.init = true;
                    var s = Serenity;
                    var w0 = s.LookupEditor;
                    var w1 = s.DateEditor;
                    var w2 = s.IntegerEditor;
                    var w3 = s.BooleanEditor;
                    Q.initFormType(TblXuongChuyenIn_ChiTietForm, [
                        'MaBo', w0,
                        'Ngay', w1,
                        'MaXuongChuyen', w2,
                        'Status', w3
                    ]);
                }
                return _this;
            }
            TblXuongChuyenIn_ChiTietForm.formKey = 'SpringPrintingConnection.TblXuongChuyenIn_ChiTiet';
            return TblXuongChuyenIn_ChiTietForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.TblXuongChuyenIn_ChiTietForm = TblXuongChuyenIn_ChiTietForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuongChuyenIn_ChiTietRow;
        (function (TblXuongChuyenIn_ChiTietRow) {
            TblXuongChuyenIn_ChiTietRow.idProperty = 'KeyId';
            TblXuongChuyenIn_ChiTietRow.localTextPrefix = 'SpringPrintingConnection.TblXuongChuyenIn_ChiTiet';
        })(TblXuongChuyenIn_ChiTietRow = SpringPrintingConnection.TblXuongChuyenIn_ChiTietRow || (SpringPrintingConnection.TblXuongChuyenIn_ChiTietRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuongChuyenIn_ChiTietService;
        (function (TblXuongChuyenIn_ChiTietService) {
            TblXuongChuyenIn_ChiTietService.baseUrl = 'SpringPrintingConnection/TblXuongChuyenIn_ChiTiet';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblXuongChuyenIn_ChiTietService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblXuongChuyenIn_ChiTietService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblXuongChuyenIn_ChiTietService = SpringPrintingConnection.TblXuongChuyenIn_ChiTietService || (SpringPrintingConnection.TblXuongChuyenIn_ChiTietService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuongChuyenRow;
        (function (TblXuongChuyenRow) {
            TblXuongChuyenRow.idProperty = 'KeyId';
            TblXuongChuyenRow.localTextPrefix = 'SpringPrintingConnection.TblXuongChuyen';
        })(TblXuongChuyenRow = SpringPrintingConnection.TblXuongChuyenRow || (SpringPrintingConnection.TblXuongChuyenRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuongChuyenService;
        (function (TblXuongChuyenService) {
            TblXuongChuyenService.baseUrl = 'SpringPrintingConnection/TblXuongChuyen';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                TblXuongChuyenService[x] = function (r, s, o) {
                    return Q.serviceRequest(TblXuongChuyenService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(TblXuongChuyenService = SpringPrintingConnection.TblXuongChuyenService || (SpringPrintingConnection.TblXuongChuyenService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VChiTietBtpForm = /** @class */ (function (_super) {
            __extends(VChiTietBtpForm, _super);
            function VChiTietBtpForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!VChiTietBtpForm.init) {
                    VChiTietBtpForm.init = true;
                    var s = Serenity;
                    var w0 = s.IntegerEditor;
                    var w1 = s.StringEditor;
                    Q.initFormType(VChiTietBtpForm, [
                        'SlLoiKh', w0,
                        'SlLoiIn', w0,
                        'CardId', w1,
                        'Code', w1,
                        'MaBtp', w1,
                        'SlThuc', w0,
                        'MaMau', w1,
                        'MaSize', w1,
                        'MaStyle', w1
                    ]);
                }
                return _this;
            }
            VChiTietBtpForm.formKey = 'SpringPrintingConnection.VChiTietBtp';
            return VChiTietBtpForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.VChiTietBtpForm = VChiTietBtpForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VChiTietBtpRow;
        (function (VChiTietBtpRow) {
            VChiTietBtpRow.idProperty = 'KeyId1';
            VChiTietBtpRow.nameProperty = 'MaBtp';
            VChiTietBtpRow.localTextPrefix = 'SpringPrintingConnection.VChiTietBtp';
            VChiTietBtpRow.lookupKey = 'SpringPrintingConnection.VChiTietBtp';
            function getLookup() {
                return Q.getLookup('SpringPrintingConnection.VChiTietBtp');
            }
            VChiTietBtpRow.getLookup = getLookup;
        })(VChiTietBtpRow = SpringPrintingConnection.VChiTietBtpRow || (SpringPrintingConnection.VChiTietBtpRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VChiTietBtpService;
        (function (VChiTietBtpService) {
            VChiTietBtpService.baseUrl = 'SpringPrintingConnection/VChiTietBtp';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                VChiTietBtpService[x] = function (r, s, o) {
                    return Q.serviceRequest(VChiTietBtpService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(VChiTietBtpService = SpringPrintingConnection.VChiTietBtpService || (SpringPrintingConnection.VChiTietBtpService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VChiTietBtp_SizeForm = /** @class */ (function (_super) {
            __extends(VChiTietBtp_SizeForm, _super);
            function VChiTietBtp_SizeForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!VChiTietBtp_SizeForm.init) {
                    VChiTietBtp_SizeForm.init = true;
                    var s = Serenity;
                    var w0 = s.IntegerEditor;
                    var w1 = s.StringEditor;
                    Q.initFormType(VChiTietBtp_SizeForm, [
                        'SlLoiKh', w0,
                        'SlLoiIn', w0,
                        'CardId', w1,
                        'Code', w1,
                        'MaBtp', w1,
                        'SlThuc', w0,
                        'MaMau', w1,
                        'MaSize', w1,
                        'MaStyle', w1
                    ]);
                }
                return _this;
            }
            VChiTietBtp_SizeForm.formKey = 'SpringPrintingConnection.VChiTietBtp_Size';
            return VChiTietBtp_SizeForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.VChiTietBtp_SizeForm = VChiTietBtp_SizeForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VChiTietBtp_SizeRow;
        (function (VChiTietBtp_SizeRow) {
            VChiTietBtp_SizeRow.idProperty = 'KeyId1';
            VChiTietBtp_SizeRow.nameProperty = 'MaSize';
            VChiTietBtp_SizeRow.localTextPrefix = 'SpringPrintingConnection.VChiTietBtp_Size';
            VChiTietBtp_SizeRow.lookupKey = 'SpringPrintingConnection.VChiTietBtp_Size';
            function getLookup() {
                return Q.getLookup('SpringPrintingConnection.VChiTietBtp_Size');
            }
            VChiTietBtp_SizeRow.getLookup = getLookup;
        })(VChiTietBtp_SizeRow = SpringPrintingConnection.VChiTietBtp_SizeRow || (SpringPrintingConnection.VChiTietBtp_SizeRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VChiTietBtp_SizeService;
        (function (VChiTietBtp_SizeService) {
            VChiTietBtp_SizeService.baseUrl = 'SpringPrintingConnection/VChiTietBtp_Size';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                VChiTietBtp_SizeService[x] = function (r, s, o) {
                    return Q.serviceRequest(VChiTietBtp_SizeService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(VChiTietBtp_SizeService = SpringPrintingConnection.VChiTietBtp_SizeService || (SpringPrintingConnection.VChiTietBtp_SizeService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VChiTietBtp_StyleForm = /** @class */ (function (_super) {
            __extends(VChiTietBtp_StyleForm, _super);
            function VChiTietBtp_StyleForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!VChiTietBtp_StyleForm.init) {
                    VChiTietBtp_StyleForm.init = true;
                    var s = Serenity;
                    var w0 = s.IntegerEditor;
                    var w1 = s.StringEditor;
                    Q.initFormType(VChiTietBtp_StyleForm, [
                        'SlLoiKh', w0,
                        'SlLoiIn', w0,
                        'CardId', w1,
                        'Code', w1,
                        'MaBtp', w1,
                        'SlThuc', w0,
                        'MaMau', w1,
                        'MaSize', w1,
                        'MaStyle', w1
                    ]);
                }
                return _this;
            }
            VChiTietBtp_StyleForm.formKey = 'SpringPrintingConnection.VChiTietBtp_Style';
            return VChiTietBtp_StyleForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.VChiTietBtp_StyleForm = VChiTietBtp_StyleForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VChiTietBtp_StyleRow;
        (function (VChiTietBtp_StyleRow) {
            VChiTietBtp_StyleRow.idProperty = 'KeyId1';
            VChiTietBtp_StyleRow.nameProperty = 'MaStyle';
            VChiTietBtp_StyleRow.localTextPrefix = 'SpringPrintingConnection.VChiTietBtp_Style';
            VChiTietBtp_StyleRow.lookupKey = 'SpringPrintingConnection.VChiTietBtp_Style';
            function getLookup() {
                return Q.getLookup('SpringPrintingConnection.VChiTietBtp_Style');
            }
            VChiTietBtp_StyleRow.getLookup = getLookup;
        })(VChiTietBtp_StyleRow = SpringPrintingConnection.VChiTietBtp_StyleRow || (SpringPrintingConnection.VChiTietBtp_StyleRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VChiTietBtp_StyleService;
        (function (VChiTietBtp_StyleService) {
            VChiTietBtp_StyleService.baseUrl = 'SpringPrintingConnection/VChiTietBtp_Style';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                VChiTietBtp_StyleService[x] = function (r, s, o) {
                    return Q.serviceRequest(VChiTietBtp_StyleService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(VChiTietBtp_StyleService = SpringPrintingConnection.VChiTietBtp_StyleService || (SpringPrintingConnection.VChiTietBtp_StyleService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VChiTietBtp_Style_ColorForm = /** @class */ (function (_super) {
            __extends(VChiTietBtp_Style_ColorForm, _super);
            function VChiTietBtp_Style_ColorForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!VChiTietBtp_Style_ColorForm.init) {
                    VChiTietBtp_Style_ColorForm.init = true;
                    var s = Serenity;
                    var w0 = s.IntegerEditor;
                    var w1 = s.StringEditor;
                    Q.initFormType(VChiTietBtp_Style_ColorForm, [
                        'SlLoiKh', w0,
                        'SlLoiIn', w0,
                        'CardId', w1,
                        'Code', w1,
                        'MaBtp', w1,
                        'SlThuc', w0,
                        'MaMau', w1,
                        'MaSize', w1,
                        'MaStyle', w1
                    ]);
                }
                return _this;
            }
            VChiTietBtp_Style_ColorForm.formKey = 'SpringPrintingConnection.VChiTietBtp_Style_Color';
            return VChiTietBtp_Style_ColorForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.VChiTietBtp_Style_ColorForm = VChiTietBtp_Style_ColorForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VChiTietBtp_Style_ColorRow;
        (function (VChiTietBtp_Style_ColorRow) {
            VChiTietBtp_Style_ColorRow.idProperty = 'KeyId1';
            VChiTietBtp_Style_ColorRow.nameProperty = 'MaMau';
            VChiTietBtp_Style_ColorRow.localTextPrefix = 'SpringPrintingConnection.VChiTietBtp_Style_Color';
            VChiTietBtp_Style_ColorRow.lookupKey = 'SpringPrintingConnection.VChiTietBtp_Style_Color';
            function getLookup() {
                return Q.getLookup('SpringPrintingConnection.VChiTietBtp_Style_Color');
            }
            VChiTietBtp_Style_ColorRow.getLookup = getLookup;
        })(VChiTietBtp_Style_ColorRow = SpringPrintingConnection.VChiTietBtp_Style_ColorRow || (SpringPrintingConnection.VChiTietBtp_Style_ColorRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VChiTietBtp_Style_ColorService;
        (function (VChiTietBtp_Style_ColorService) {
            VChiTietBtp_Style_ColorService.baseUrl = 'SpringPrintingConnection/VChiTietBtp_Style_Color';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                VChiTietBtp_Style_ColorService[x] = function (r, s, o) {
                    return Q.serviceRequest(VChiTietBtp_Style_ColorService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(VChiTietBtp_Style_ColorService = SpringPrintingConnection.VChiTietBtp_Style_ColorService || (SpringPrintingConnection.VChiTietBtp_Style_ColorService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VHopDongChiTietForm = /** @class */ (function (_super) {
            __extends(VHopDongChiTietForm, _super);
            function VHopDongChiTietForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!VHopDongChiTietForm.init) {
                    VHopDongChiTietForm.init = true;
                    var s = Serenity;
                    var w0 = s.DateEditor;
                    var w1 = s.StringEditor;
                    var w2 = s.DecimalEditor;
                    var w3 = s.IntegerEditor;
                    Q.initFormType(VHopDongChiTietForm, [
                        'NgayHd', w0,
                        'NoiDung', w1,
                        'GiaTri', w2,
                        'SoHd', w1,
                        'TenKh', w1,
                        'MaKh', w1,
                        'MaBtp', w3,
                        'MotaBtp', w1,
                        'DonViTinh', w1,
                        'MaMau', w1,
                        'TenMau', w1,
                        'MaSize', w1,
                        'TenSize', w1,
                        'MaStyle', w1,
                        'TenStyle', w1,
                        'SoLuong', w3,
                        'DonGia', w2,
                        'ThanhTien', w2
                    ]);
                }
                return _this;
            }
            VHopDongChiTietForm.formKey = 'SpringPrintingConnection.VHopDongChiTiet';
            return VHopDongChiTietForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.VHopDongChiTietForm = VHopDongChiTietForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VHopDongChiTietRow;
        (function (VHopDongChiTietRow) {
            VHopDongChiTietRow.idProperty = 'MaHd';
            VHopDongChiTietRow.nameProperty = 'NoiDung';
            VHopDongChiTietRow.localTextPrefix = 'SpringPrintingConnection.VHopDongChiTiet';
        })(VHopDongChiTietRow = SpringPrintingConnection.VHopDongChiTietRow || (SpringPrintingConnection.VHopDongChiTietRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VHopDongChiTietService;
        (function (VHopDongChiTietService) {
            VHopDongChiTietService.baseUrl = 'SpringPrintingConnection/VHopDongChiTiet';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                VHopDongChiTietService[x] = function (r, s, o) {
                    return Q.serviceRequest(VHopDongChiTietService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(VHopDongChiTietService = SpringPrintingConnection.VHopDongChiTietService || (SpringPrintingConnection.VHopDongChiTietService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VHopDongTrangThaiForm = /** @class */ (function (_super) {
            __extends(VHopDongTrangThaiForm, _super);
            function VHopDongTrangThaiForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!VHopDongTrangThaiForm.init) {
                    VHopDongTrangThaiForm.init = true;
                    var s = Serenity;
                    var w0 = s.DateEditor;
                    var w1 = s.StringEditor;
                    var w2 = s.DecimalEditor;
                    var w3 = s.IntegerEditor;
                    Q.initFormType(VHopDongTrangThaiForm, [
                        'NgayHd', w0,
                        'NoiDung', w1,
                        'GiaTri', w2,
                        'SoHd', w1,
                        'TenKh', w1,
                        'MaKh', w1,
                        'MotaBtp', w1,
                        'DonViTinh', w1,
                        'MaMau', w3,
                        'TenMau', w1,
                        'MaSize', w3,
                        'TenSize', w1,
                        'MaStyle', w3,
                        'TenStyle', w1,
                        'SoLuong', w3,
                        'DonGia', w2,
                        'ThanhTien', w2,
                        'SlNhap', w3,
                        'SlLoiKh', w3,
                        'SlLoiIn', w3,
                        'SlThucXuat', w3,
                        'SlThieu', w3
                    ]);
                }
                return _this;
            }
            VHopDongTrangThaiForm.formKey = 'SpringPrintingConnection.VHopDongTrangThai';
            return VHopDongTrangThaiForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.VHopDongTrangThaiForm = VHopDongTrangThaiForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VHopDongTrangThaiRow;
        (function (VHopDongTrangThaiRow) {
            VHopDongTrangThaiRow.idProperty = 'MaCT';
            VHopDongTrangThaiRow.nameProperty = 'NoiDung';
            VHopDongTrangThaiRow.localTextPrefix = 'SpringPrintingConnection.VHopDongTrangThai';
        })(VHopDongTrangThaiRow = SpringPrintingConnection.VHopDongTrangThaiRow || (SpringPrintingConnection.VHopDongTrangThaiRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VHopDongTrangThaiService;
        (function (VHopDongTrangThaiService) {
            VHopDongTrangThaiService.baseUrl = 'SpringPrintingConnection/VHopDongTrangThai';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                VHopDongTrangThaiService[x] = function (r, s, o) {
                    return Q.serviceRequest(VHopDongTrangThaiService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(VHopDongTrangThaiService = SpringPrintingConnection.VHopDongTrangThaiService || (SpringPrintingConnection.VHopDongTrangThaiService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VLenChuyenChiTietForm = /** @class */ (function (_super) {
            __extends(VLenChuyenChiTietForm, _super);
            function VLenChuyenChiTietForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!VLenChuyenChiTietForm.init) {
                    VLenChuyenChiTietForm.init = true;
                    var s = Serenity;
                    var w0 = s.DateEditor;
                    var w1 = s.IntegerEditor;
                    var w2 = s.StringEditor;
                    Q.initFormType(VLenChuyenChiTietForm, [
                        'Ngay', w0,
                        'SlLoiKh', w1,
                        'SlLoiIn', w1,
                        'CardId', w2,
                        'Code', w2,
                        'MaBtp', w2,
                        'SlThuc', w1,
                        'MaMau', w2,
                        'MaSize', w2,
                        'MaStyle', w2
                    ]);
                }
                return _this;
            }
            VLenChuyenChiTietForm.formKey = 'SpringPrintingConnection.VLenChuyenChiTiet';
            return VLenChuyenChiTietForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.VLenChuyenChiTietForm = VLenChuyenChiTietForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VLenChuyenChiTietRow;
        (function (VLenChuyenChiTietRow) {
            VLenChuyenChiTietRow.idProperty = 'KeyId1';
            VLenChuyenChiTietRow.nameProperty = 'Code';
            VLenChuyenChiTietRow.localTextPrefix = 'SpringPrintingConnection.VLenChuyenChiTiet';
        })(VLenChuyenChiTietRow = SpringPrintingConnection.VLenChuyenChiTietRow || (SpringPrintingConnection.VLenChuyenChiTietRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VLenChuyenChiTietService;
        (function (VLenChuyenChiTietService) {
            VLenChuyenChiTietService.baseUrl = 'SpringPrintingConnection/VLenChuyenChiTiet';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                VLenChuyenChiTietService[x] = function (r, s, o) {
                    return Q.serviceRequest(VLenChuyenChiTietService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(VLenChuyenChiTietService = SpringPrintingConnection.VLenChuyenChiTietService || (SpringPrintingConnection.VLenChuyenChiTietService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VLoSpKhForm = /** @class */ (function (_super) {
            __extends(VLoSpKhForm, _super);
            function VLoSpKhForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!VLoSpKhForm.init) {
                    VLoSpKhForm.init = true;
                    var s = Serenity;
                    var w0 = s.IntegerEditor;
                    var w1 = s.StringEditor;
                    Q.initFormType(VLoSpKhForm, [
                        'MaKh', w0,
                        'TenKh', w1
                    ]);
                }
                return _this;
            }
            VLoSpKhForm.formKey = 'SpringPrintingConnection.VLoSpKh';
            return VLoSpKhForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.VLoSpKhForm = VLoSpKhForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VLoSpKhRow;
        (function (VLoSpKhRow) {
            VLoSpKhRow.idProperty = 'KeyId1';
            VLoSpKhRow.nameProperty = 'TenKh';
            VLoSpKhRow.localTextPrefix = 'SpringPrintingConnection.VLoSpKh';
        })(VLoSpKhRow = SpringPrintingConnection.VLoSpKhRow || (SpringPrintingConnection.VLoSpKhRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VLoSpKhService;
        (function (VLoSpKhService) {
            VLoSpKhService.baseUrl = 'SpringPrintingConnection/VLoSpKh';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                VLoSpKhService[x] = function (r, s, o) {
                    return Q.serviceRequest(VLoSpKhService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(VLoSpKhService = SpringPrintingConnection.VLoSpKhService || (SpringPrintingConnection.VLoSpKhService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VNhapKhoSpForm = /** @class */ (function (_super) {
            __extends(VNhapKhoSpForm, _super);
            function VNhapKhoSpForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!VNhapKhoSpForm.init) {
                    VNhapKhoSpForm.init = true;
                    var s = Serenity;
                    var w0 = s.IntegerEditor;
                    var w1 = s.StringEditor;
                    var w2 = s.DateEditor;
                    var w3 = s.BooleanEditor;
                    Q.initFormType(VNhapKhoSpForm, [
                        'KeyId', w0,
                        'MaKh', w0,
                        'TenKh', w1,
                        'NgayNhap', w2,
                        'NguoiNhap', w0,
                        'GhiChu', w1,
                        'MaBtp', w1,
                        'SlThuc', w0,
                        'SlLoiKh', w0,
                        'SlLoiIn', w0,
                        'MaMau', w1,
                        'MaSize', w1,
                        'MaStyle', w1,
                        'HangMau', w3,
                        'HangBu', w3,
                        'CardId', w1,
                        'Code', w1,
                        'Po', w1,
                        'Fepo', w1,
                        'BulNo', w0,
                        'TableNum', w1,
                        'Buy', w1,
                        'Style04', w1,
                        'Col', w1,
                        'Size', w1,
                        'Part', w1,
                        'Quantity', w0
                    ]);
                }
                return _this;
            }
            VNhapKhoSpForm.formKey = 'SpringPrintingConnection.VNhapKhoSp';
            return VNhapKhoSpForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.VNhapKhoSpForm = VNhapKhoSpForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VNhapKhoSpRow;
        (function (VNhapKhoSpRow) {
            VNhapKhoSpRow.idProperty = 'Expr1';
            VNhapKhoSpRow.nameProperty = 'TenKh';
            VNhapKhoSpRow.localTextPrefix = 'SpringPrintingConnection.VNhapKhoSp';
        })(VNhapKhoSpRow = SpringPrintingConnection.VNhapKhoSpRow || (SpringPrintingConnection.VNhapKhoSpRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VNhapKhoSpService;
        (function (VNhapKhoSpService) {
            VNhapKhoSpService.baseUrl = 'SpringPrintingConnection/VNhapKhoSp';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                VNhapKhoSpService[x] = function (r, s, o) {
                    return Q.serviceRequest(VNhapKhoSpService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(VNhapKhoSpService = SpringPrintingConnection.VNhapKhoSpService || (SpringPrintingConnection.VNhapKhoSpService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VTrangThaiBoBtpForm = /** @class */ (function (_super) {
            __extends(VTrangThaiBoBtpForm, _super);
            function VTrangThaiBoBtpForm(prefix) {
                var _this = _super.call(this, prefix) || this;
                if (!VTrangThaiBoBtpForm.init) {
                    VTrangThaiBoBtpForm.init = true;
                    var s = Serenity;
                    var w0 = s.StringEditor;
                    var w1 = s.IntegerEditor;
                    var w2 = s.DateEditor;
                    var w3 = s.BooleanEditor;
                    Q.initFormType(VTrangThaiBoBtpForm, [
                        'CardId', w0,
                        'Code', w0,
                        'MaBtp', w1,
                        'TenBtp', w0,
                        'SlThuc', w1,
                        'SlLoiKh', w1,
                        'SlLoiIn', w1,
                        'MaMau', w0,
                        'MaSize', w0,
                        'MaStyle', w0,
                        'Ngay1', w2,
                        'NhanVien1', w1,
                        'Ngay2', w2,
                        'NhanVien2', w1,
                        'Ngay3', w2,
                        'NhanVien3', w1,
                        'Ngay4', w2,
                        'NhanVien4', w1,
                        'HangMau', w3,
                        'HangBu', w3,
                        'MaHd', w1
                    ]);
                }
                return _this;
            }
            VTrangThaiBoBtpForm.formKey = 'SpringPrintingConnection.VTrangThaiBoBtp';
            return VTrangThaiBoBtpForm;
        }(Serenity.PrefixedContext));
        SpringPrintingConnection.VTrangThaiBoBtpForm = VTrangThaiBoBtpForm;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VTrangThaiBoBtpRow;
        (function (VTrangThaiBoBtpRow) {
            VTrangThaiBoBtpRow.idProperty = 'KeyId1';
            VTrangThaiBoBtpRow.nameProperty = 'Code';
            VTrangThaiBoBtpRow.localTextPrefix = 'SpringPrintingConnection.VTrangThaiBoBtp';
        })(VTrangThaiBoBtpRow = SpringPrintingConnection.VTrangThaiBoBtpRow || (SpringPrintingConnection.VTrangThaiBoBtpRow = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VTrangThaiBoBtpService;
        (function (VTrangThaiBoBtpService) {
            VTrangThaiBoBtpService.baseUrl = 'SpringPrintingConnection/VTrangThaiBoBtp';
            [
                'Create',
                'Update',
                'Delete',
                'Retrieve',
                'List'
            ].forEach(function (x) {
                VTrangThaiBoBtpService[x] = function (r, s, o) {
                    return Q.serviceRequest(VTrangThaiBoBtpService.baseUrl + '/' + x, r, s, o);
                };
            });
        })(VTrangThaiBoBtpService = SpringPrintingConnection.VTrangThaiBoBtpService || (SpringPrintingConnection.VTrangThaiBoBtpService = {}));
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var LanguageList;
    (function (LanguageList) {
        function getValue() {
            var result = [];
            for (var _i = 0, _a = Serene3.Administration.LanguageRow.getLookup().items; _i < _a.length; _i++) {
                var k = _a[_i];
                if (k.LanguageId !== 'en') {
                    result.push([k.Id.toString(), k.LanguageName]);
                }
            }
            return result;
        }
        LanguageList.getValue = getValue;
    })(LanguageList = Serene3.LanguageList || (Serene3.LanguageList = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../Common/Helpers/LanguageList.ts" />
var Serene3;
(function (Serene3) {
    var ScriptInitialization;
    (function (ScriptInitialization) {
        Q.Config.responsiveDialogs = true;
        Q.Config.rootNamespaces.push('Serene3');
        Serenity.EntityDialog.defaultLanguageList = Serene3.LanguageList.getValue;
        if ($.fn['colorbox']) {
            $.fn['colorbox'].settings.maxWidth = "95%";
            $.fn['colorbox'].settings.maxHeight = "95%";
        }
        window.onerror = Q.ErrorHandling.runtimeErrorHandler;
    })(ScriptInitialization = Serene3.ScriptInitialization || (Serene3.ScriptInitialization = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var LanguageDialog = /** @class */ (function (_super) {
            __extends(LanguageDialog, _super);
            function LanguageDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new Administration.LanguageForm(_this.idPrefix);
                return _this;
            }
            LanguageDialog.prototype.getFormKey = function () { return Administration.LanguageForm.formKey; };
            LanguageDialog.prototype.getIdProperty = function () { return Administration.LanguageRow.idProperty; };
            LanguageDialog.prototype.getLocalTextPrefix = function () { return Administration.LanguageRow.localTextPrefix; };
            LanguageDialog.prototype.getNameProperty = function () { return Administration.LanguageRow.nameProperty; };
            LanguageDialog.prototype.getService = function () { return Administration.LanguageService.baseUrl; };
            LanguageDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], LanguageDialog);
            return LanguageDialog;
        }(Serenity.EntityDialog));
        Administration.LanguageDialog = LanguageDialog;
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var LanguageGrid = /** @class */ (function (_super) {
            __extends(LanguageGrid, _super);
            function LanguageGrid(container) {
                return _super.call(this, container) || this;
            }
            LanguageGrid.prototype.getColumnsKey = function () { return "Administration.Language"; };
            LanguageGrid.prototype.getDialogType = function () { return Administration.LanguageDialog; };
            LanguageGrid.prototype.getIdProperty = function () { return Administration.LanguageRow.idProperty; };
            LanguageGrid.prototype.getLocalTextPrefix = function () { return Administration.LanguageRow.localTextPrefix; };
            LanguageGrid.prototype.getService = function () { return Administration.LanguageService.baseUrl; };
            LanguageGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], LanguageGrid);
            return LanguageGrid;
        }(Serenity.EntityGrid));
        Administration.LanguageGrid = LanguageGrid;
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var RoleDialog = /** @class */ (function (_super) {
            __extends(RoleDialog, _super);
            function RoleDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new Administration.RoleForm(_this.idPrefix);
                return _this;
            }
            RoleDialog.prototype.getFormKey = function () { return Administration.RoleForm.formKey; };
            RoleDialog.prototype.getIdProperty = function () { return Administration.RoleRow.idProperty; };
            RoleDialog.prototype.getLocalTextPrefix = function () { return Administration.RoleRow.localTextPrefix; };
            RoleDialog.prototype.getNameProperty = function () { return Administration.RoleRow.nameProperty; };
            RoleDialog.prototype.getService = function () { return Administration.RoleService.baseUrl; };
            RoleDialog.prototype.getToolbarButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getToolbarButtons.call(this);
                buttons.push({
                    title: Q.text('Site.RolePermissionDialog.EditButton'),
                    cssClass: 'edit-permissions-button',
                    icon: 'fa-lock text-green',
                    onClick: function () {
                        new Administration.RolePermissionDialog({
                            roleID: _this.entity.RoleId,
                            title: _this.entity.RoleName
                        }).dialogOpen();
                    }
                });
                return buttons;
            };
            RoleDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                this.toolbar.findButton("edit-permissions-button").toggleClass("disabled", this.isNewOrDeleted());
            };
            RoleDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], RoleDialog);
            return RoleDialog;
        }(Serenity.EntityDialog));
        Administration.RoleDialog = RoleDialog;
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var RoleGrid = /** @class */ (function (_super) {
            __extends(RoleGrid, _super);
            function RoleGrid(container) {
                return _super.call(this, container) || this;
            }
            RoleGrid.prototype.getColumnsKey = function () { return "Administration.Role"; };
            RoleGrid.prototype.getDialogType = function () { return Administration.RoleDialog; };
            RoleGrid.prototype.getIdProperty = function () { return Administration.RoleRow.idProperty; };
            RoleGrid.prototype.getLocalTextPrefix = function () { return Administration.RoleRow.localTextPrefix; };
            RoleGrid.prototype.getService = function () { return Administration.RoleService.baseUrl; };
            RoleGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], RoleGrid);
            return RoleGrid;
        }(Serenity.EntityGrid));
        Administration.RoleGrid = RoleGrid;
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var RolePermissionDialog = /** @class */ (function (_super) {
            __extends(RolePermissionDialog, _super);
            function RolePermissionDialog(opt) {
                var _this = _super.call(this, opt) || this;
                _this.permissions = new Administration.PermissionCheckEditor(_this.byId('Permissions'), {
                    showRevoke: false
                });
                Administration.RolePermissionService.List({
                    RoleID: _this.options.roleID,
                    Module: null,
                    Submodule: null
                }, function (response) {
                    _this.permissions.value = response.Entities.map(function (x) { return ({ PermissionKey: x }); });
                });
                _this.permissions.implicitPermissions = Q.getRemoteData('Administration.ImplicitPermissions');
                return _this;
            }
            RolePermissionDialog.prototype.getDialogOptions = function () {
                var _this = this;
                var opt = _super.prototype.getDialogOptions.call(this);
                opt.buttons = [
                    {
                        text: Q.text('Dialogs.OkButton'),
                        click: function (e) {
                            Administration.RolePermissionService.Update({
                                RoleID: _this.options.roleID,
                                Permissions: _this.permissions.value.map(function (x) { return x.PermissionKey; }),
                                Module: null,
                                Submodule: null
                            }, function (response) {
                                _this.dialogClose();
                                window.setTimeout(function () { return Q.notifySuccess(Q.text('Site.RolePermissionDialog.SaveSuccess')); }, 0);
                            });
                        }
                    }, {
                        text: Q.text('Dialogs.CancelButton'),
                        click: function () { return _this.dialogClose(); }
                    }
                ];
                opt.title = Q.format(Q.text('Site.RolePermissionDialog.DialogTitle'), this.options.title);
                return opt;
            };
            RolePermissionDialog.prototype.getTemplate = function () {
                return '<div id="~_Permissions"></div>';
            };
            RolePermissionDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], RolePermissionDialog);
            return RolePermissionDialog;
        }(Serenity.TemplatedDialog));
        Administration.RolePermissionDialog = RolePermissionDialog;
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var TranslationGrid = /** @class */ (function (_super) {
            __extends(TranslationGrid, _super);
            function TranslationGrid(container) {
                var _this = _super.call(this, container) || this;
                _this.element.on('keyup.' + _this.uniqueName + ' change.' + _this.uniqueName, 'input.custom-text', function (e) {
                    var value = Q.trimToNull($(e.target).val());
                    if (value === '') {
                        value = null;
                    }
                    _this.view.getItemById($(e.target).data('key')).CustomText = value;
                    _this.hasChanges = true;
                });
                return _this;
            }
            TranslationGrid.prototype.getIdProperty = function () { return "Key"; };
            TranslationGrid.prototype.getLocalTextPrefix = function () { return "Administration.Translation"; };
            TranslationGrid.prototype.getService = function () { return Administration.TranslationService.baseUrl; };
            TranslationGrid.prototype.onClick = function (e, row, cell) {
                var _this = this;
                _super.prototype.onClick.call(this, e, row, cell);
                if (e.isDefaultPrevented()) {
                    return;
                }
                var item = this.itemAt(row);
                var done;
                if ($(e.target).hasClass('source-text')) {
                    e.preventDefault();
                    done = function () {
                        item.CustomText = item.SourceText;
                        _this.view.updateItem(item.Key, item);
                        _this.hasChanges = true;
                    };
                    if (Q.isTrimmedEmpty(item.CustomText) ||
                        (Q.trimToEmpty(item.CustomText) === Q.trimToEmpty(item.SourceText))) {
                        done();
                        return;
                    }
                    Q.confirm(Q.text('Db.Administration.Translation.OverrideConfirmation'), done);
                    return;
                }
                if ($(e.target).hasClass('target-text')) {
                    e.preventDefault();
                    done = function () {
                        item.CustomText = item.TargetText;
                        _this.view.updateItem(item.Key, item);
                        _this.hasChanges = true;
                    };
                    if (Q.isTrimmedEmpty(item.CustomText) ||
                        (Q.trimToEmpty(item.CustomText) === Q.trimToEmpty(item.TargetText))) {
                        done();
                        return;
                    }
                    Q.confirm(Q.text('Db.Administration.Translation.OverrideConfirmation'), done);
                    return;
                }
            };
            TranslationGrid.prototype.getColumns = function () {
                var columns = [];
                columns.push({ field: 'Key', width: 300, sortable: false });
                columns.push({
                    field: 'SourceText',
                    width: 300,
                    sortable: false,
                    format: function (ctx) {
                        return Q.outerHtml($('<a/>')
                            .addClass('source-text')
                            .text(ctx.value || ''));
                    }
                });
                columns.push({
                    field: 'CustomText',
                    width: 300,
                    sortable: false,
                    format: function (ctx) { return Q.outerHtml($('<input/>')
                        .addClass('custom-text')
                        .attr('value', ctx.value)
                        .attr('type', 'text')
                        .attr('data-key', ctx.item.Key)); }
                });
                columns.push({
                    field: 'TargetText',
                    width: 300,
                    sortable: false,
                    format: function (ctx) { return Q.outerHtml($('<a/>')
                        .addClass('target-text')
                        .text(ctx.value || '')); }
                });
                return columns;
            };
            TranslationGrid.prototype.createToolbarExtensions = function () {
                var _this = this;
                _super.prototype.createToolbarExtensions.call(this);
                var opt = {
                    lookupKey: 'Administration.Language'
                };
                this.sourceLanguage = Serenity.Widget.create({
                    type: Serenity.LookupEditor,
                    element: function (el) { return el.appendTo(_this.toolbar.element).attr('placeholder', '--- ' +
                        Q.text('Db.Administration.Translation.SourceLanguage') + ' ---'); },
                    options: opt
                });
                this.sourceLanguage.changeSelect2(function (e) {
                    if (_this.hasChanges) {
                        _this.saveChanges(_this.targetLanguageKey).then(function () { return _this.refresh(); });
                    }
                    else {
                        _this.refresh();
                    }
                });
                this.targetLanguage = Serenity.Widget.create({
                    type: Serenity.LookupEditor,
                    element: function (el) { return el.appendTo(_this.toolbar.element).attr('placeholder', '--- ' +
                        Q.text('Db.Administration.Translation.TargetLanguage') + ' ---'); },
                    options: opt
                });
                this.targetLanguage.changeSelect2(function (e) {
                    if (_this.hasChanges) {
                        _this.saveChanges(_this.targetLanguageKey).then(function () { return _this.refresh(); });
                    }
                    else {
                        _this.refresh();
                    }
                });
            };
            TranslationGrid.prototype.saveChanges = function (language) {
                var _this = this;
                var translations = {};
                for (var _i = 0, _a = this.getItems(); _i < _a.length; _i++) {
                    var item = _a[_i];
                    translations[item.Key] = item.CustomText;
                }
                return Promise.resolve(Administration.TranslationService.Update({
                    TargetLanguageID: language,
                    Translations: translations
                })).then(function () {
                    _this.hasChanges = false;
                    language = Q.trimToNull(language) || 'invariant';
                    Q.notifySuccess('User translations in "' + language +
                        '" language are saved to "user.texts.' +
                        language + '.json" ' + 'file under "~/App_Data/texts/"', '');
                });
            };
            TranslationGrid.prototype.onViewSubmit = function () {
                var request = this.view.params;
                request.SourceLanguageID = this.sourceLanguage.value;
                this.targetLanguageKey = this.targetLanguage.value || '';
                request.TargetLanguageID = this.targetLanguageKey;
                this.hasChanges = false;
                return _super.prototype.onViewSubmit.call(this);
            };
            TranslationGrid.prototype.getButtons = function () {
                var _this = this;
                return [{
                        title: Q.text('Db.Administration.Translation.SaveChangesButton'),
                        onClick: function (e) { return _this.saveChanges(_this.targetLanguageKey).then(function () { return _this.refresh(); }); },
                        cssClass: 'apply-changes-button'
                    }];
            };
            TranslationGrid.prototype.createQuickSearchInput = function () {
                var _this = this;
                Serenity.GridUtils.addQuickSearchInputCustom(this.toolbar.element, function (field, searchText) {
                    _this.searchText = searchText;
                    _this.view.setItems(_this.view.getItems(), true);
                });
            };
            TranslationGrid.prototype.onViewFilter = function (item) {
                if (!_super.prototype.onViewFilter.call(this, item)) {
                    return false;
                }
                if (!this.searchText) {
                    return true;
                }
                var sd = Select2.util.stripDiacritics;
                var searching = sd(this.searchText).toLowerCase();
                function match(str) {
                    if (!str)
                        return false;
                    return str.toLowerCase().indexOf(searching) >= 0;
                }
                return Q.isEmptyOrNull(searching) || match(item.Key) || match(item.SourceText) ||
                    match(item.TargetText) || match(item.CustomText);
            };
            TranslationGrid.prototype.usePager = function () {
                return false;
            };
            TranslationGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], TranslationGrid);
            return TranslationGrid;
        }(Serenity.EntityGrid));
        Administration.TranslationGrid = TranslationGrid;
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var UserDialog = /** @class */ (function (_super) {
            __extends(UserDialog, _super);
            function UserDialog() {
                var _this = _super.call(this) || this;
                _this.form = new Administration.UserForm(_this.idPrefix);
                _this.form.Password.addValidationRule(_this.uniqueName, function (e) {
                    if (_this.form.Password.value.length < 7)
                        return "Password must be at least 7 characters!";
                });
                _this.form.PasswordConfirm.addValidationRule(_this.uniqueName, function (e) {
                    if (_this.form.Password.value != _this.form.PasswordConfirm.value)
                        return "The passwords entered doesn't match!";
                });
                return _this;
            }
            UserDialog.prototype.getFormKey = function () { return Administration.UserForm.formKey; };
            UserDialog.prototype.getIdProperty = function () { return Administration.UserRow.idProperty; };
            UserDialog.prototype.getIsActiveProperty = function () { return Administration.UserRow.isActiveProperty; };
            UserDialog.prototype.getLocalTextPrefix = function () { return Administration.UserRow.localTextPrefix; };
            UserDialog.prototype.getNameProperty = function () { return Administration.UserRow.nameProperty; };
            UserDialog.prototype.getService = function () { return Administration.UserService.baseUrl; };
            UserDialog.prototype.getToolbarButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getToolbarButtons.call(this);
                buttons.push({
                    title: Q.text('Site.UserDialog.EditRolesButton'),
                    cssClass: 'edit-roles-button',
                    icon: 'fa-users text-blue',
                    onClick: function () {
                        new Administration.UserRoleDialog({
                            userID: _this.entity.UserId,
                            username: _this.entity.Username
                        }).dialogOpen();
                    }
                });
                buttons.push({
                    title: Q.text('Site.UserDialog.EditPermissionsButton'),
                    cssClass: 'edit-permissions-button',
                    icon: 'fa-lock text-green',
                    onClick: function () {
                        new Administration.UserPermissionDialog({
                            userID: _this.entity.UserId,
                            username: _this.entity.Username
                        }).dialogOpen();
                    }
                });
                return buttons;
            };
            UserDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                this.toolbar.findButton('edit-roles-button').toggleClass('disabled', this.isNewOrDeleted());
                this.toolbar.findButton("edit-permissions-button").toggleClass("disabled", this.isNewOrDeleted());
            };
            UserDialog.prototype.afterLoadEntity = function () {
                _super.prototype.afterLoadEntity.call(this);
                // these fields are only required in new record mode
                this.form.Password.element.toggleClass('required', this.isNew())
                    .closest('.field').find('sup').toggle(this.isNew());
                this.form.PasswordConfirm.element.toggleClass('required', this.isNew())
                    .closest('.field').find('sup').toggle(this.isNew());
            };
            UserDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], UserDialog);
            return UserDialog;
        }(Serenity.EntityDialog));
        Administration.UserDialog = UserDialog;
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var UserGrid = /** @class */ (function (_super) {
            __extends(UserGrid, _super);
            function UserGrid(container) {
                return _super.call(this, container) || this;
            }
            UserGrid.prototype.getColumnsKey = function () { return "Administration.User"; };
            UserGrid.prototype.getDialogType = function () { return Administration.UserDialog; };
            UserGrid.prototype.getIdProperty = function () { return Administration.UserRow.idProperty; };
            UserGrid.prototype.getIsActiveProperty = function () { return Administration.UserRow.isActiveProperty; };
            UserGrid.prototype.getLocalTextPrefix = function () { return Administration.UserRow.localTextPrefix; };
            UserGrid.prototype.getService = function () { return Administration.UserService.baseUrl; };
            UserGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], UserGrid);
            return UserGrid;
        }(Serenity.EntityGrid));
        Administration.UserGrid = UserGrid;
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var PermissionCheckEditor = /** @class */ (function (_super) {
            __extends(PermissionCheckEditor, _super);
            function PermissionCheckEditor(container, opt) {
                var _this = _super.call(this, container, opt) || this;
                _this._rolePermissions = {};
                _this._implicitPermissions = {};
                var titleByKey = {};
                var permissionKeys = _this.getSortedGroupAndPermissionKeys(titleByKey);
                var items = permissionKeys.map(function (key) { return ({
                    Key: key,
                    ParentKey: _this.getParentKey(key),
                    Title: titleByKey[key],
                    GrantRevoke: null,
                    IsGroup: key.charAt(key.length - 1) === ':'
                }); });
                _this.byParentKey = Q.toGrouping(items, function (x) { return x.ParentKey; });
                _this.setItems(items);
                return _this;
            }
            PermissionCheckEditor.prototype.getIdProperty = function () { return "Key"; };
            PermissionCheckEditor.prototype.getItemGrantRevokeClass = function (item, grant) {
                if (!item.IsGroup) {
                    return ((item.GrantRevoke === grant) ? ' checked' : '');
                }
                var desc = this.getDescendants(item, true);
                var granted = desc.filter(function (x) { return x.GrantRevoke === grant; });
                if (!granted.length) {
                    return '';
                }
                if (desc.length === granted.length) {
                    return 'checked';
                }
                return 'checked partial';
            };
            PermissionCheckEditor.prototype.roleOrImplicit = function (key) {
                if (this._rolePermissions[key])
                    return true;
                for (var _i = 0, _a = Object.keys(this._rolePermissions); _i < _a.length; _i++) {
                    var k = _a[_i];
                    var d = this._implicitPermissions[k];
                    if (d && d[key])
                        return true;
                }
                for (var _b = 0, _c = Object.keys(this._implicitPermissions); _b < _c.length; _b++) {
                    var i = _c[_b];
                    var item = this.view.getItemById(i);
                    if (item && item.GrantRevoke == true) {
                        var d = this._implicitPermissions[i];
                        if (d && d[key])
                            return true;
                    }
                }
            };
            PermissionCheckEditor.prototype.getItemEffectiveClass = function (item) {
                var _this = this;
                if (item.IsGroup) {
                    var desc = this.getDescendants(item, true);
                    var grantCount = Q.count(desc, function (x) { return x.GrantRevoke === true ||
                        (x.GrantRevoke == null && _this.roleOrImplicit(x.Key)); });
                    if (grantCount === desc.length || desc.length === 0) {
                        return 'allow';
                    }
                    if (grantCount === 0) {
                        return 'deny';
                    }
                    return 'partial';
                }
                var granted = item.GrantRevoke === true ||
                    (item.GrantRevoke == null && this.roleOrImplicit(item.Key));
                return (granted ? ' allow' : ' deny');
            };
            PermissionCheckEditor.prototype.getColumns = function () {
                var _this = this;
                var columns = [{
                        name: Q.text('Site.UserPermissionDialog.Permission'),
                        field: 'Title',
                        format: Serenity.SlickFormatting.treeToggle(function () { return _this.view; }, function (x) { return x.Key; }, function (ctx) {
                            var item = ctx.item;
                            var klass = _this.getItemEffectiveClass(item);
                            return '<span class="effective-permission ' + klass + '">' + Q.htmlEncode(ctx.value) + '</span>';
                        }),
                        width: 495,
                        sortable: false
                    }, {
                        name: Q.text('Site.UserPermissionDialog.Grant'), field: 'Grant',
                        format: function (ctx) {
                            var item1 = ctx.item;
                            var klass1 = _this.getItemGrantRevokeClass(item1, true);
                            return "<span class='check-box grant no-float " + klass1 + "'></span>";
                        },
                        width: 65,
                        sortable: false,
                        headerCssClass: 'align-center',
                        cssClass: 'align-center'
                    }];
                if (this.options.showRevoke) {
                    columns.push({
                        name: Q.text('Site.UserPermissionDialog.Revoke'), field: 'Revoke',
                        format: function (ctx) {
                            var item2 = ctx.item;
                            var klass2 = _this.getItemGrantRevokeClass(item2, false);
                            return '<span class="check-box revoke no-float ' + klass2 + '"></span>';
                        },
                        width: 65,
                        sortable: false,
                        headerCssClass: 'align-center',
                        cssClass: 'align-center'
                    });
                }
                return columns;
            };
            PermissionCheckEditor.prototype.setItems = function (items) {
                Serenity.SlickTreeHelper.setIndents(items, function (x) { return x.Key; }, function (x) { return x.ParentKey; }, false);
                this.view.setItems(items, true);
            };
            PermissionCheckEditor.prototype.onViewSubmit = function () {
                return false;
            };
            PermissionCheckEditor.prototype.onViewFilter = function (item) {
                var _this = this;
                if (!_super.prototype.onViewFilter.call(this, item)) {
                    return false;
                }
                if (!Serenity.SlickTreeHelper.filterById(item, this.view, function (x) { return x.ParentKey; }))
                    return false;
                if (this.searchText) {
                    return this.matchContains(item) || item.IsGroup && Q.any(this.getDescendants(item, false), function (x) { return _this.matchContains(x); });
                }
                return true;
            };
            PermissionCheckEditor.prototype.matchContains = function (item) {
                return Select2.util.stripDiacritics(item.Title || '').toLowerCase().indexOf(this.searchText) >= 0;
            };
            PermissionCheckEditor.prototype.getDescendants = function (item, excludeGroups) {
                var result = [];
                var stack = [item];
                while (stack.length > 0) {
                    var i = stack.pop();
                    var children = this.byParentKey[i.Key];
                    if (!children)
                        continue;
                    for (var _i = 0, children_1 = children; _i < children_1.length; _i++) {
                        var child = children_1[_i];
                        if (!excludeGroups || !child.IsGroup) {
                            result.push(child);
                        }
                        stack.push(child);
                    }
                }
                return result;
            };
            PermissionCheckEditor.prototype.onClick = function (e, row, cell) {
                _super.prototype.onClick.call(this, e, row, cell);
                if (!e.isDefaultPrevented()) {
                    Serenity.SlickTreeHelper.toggleClick(e, row, cell, this.view, function (x) { return x.Key; });
                }
                if (e.isDefaultPrevented()) {
                    return;
                }
                var target = $(e.target);
                var grant = target.hasClass('grant');
                if (grant || target.hasClass('revoke')) {
                    e.preventDefault();
                    var item = this.itemAt(row);
                    var checkedOrPartial = target.hasClass('checked') || target.hasClass('partial');
                    if (checkedOrPartial) {
                        grant = null;
                    }
                    else {
                        grant = grant !== checkedOrPartial;
                    }
                    if (item.IsGroup) {
                        for (var _i = 0, _a = this.getDescendants(item, true); _i < _a.length; _i++) {
                            var d = _a[_i];
                            d.GrantRevoke = grant;
                        }
                    }
                    else
                        item.GrantRevoke = grant;
                    this.slickGrid.invalidate();
                }
            };
            PermissionCheckEditor.prototype.getParentKey = function (key) {
                if (key.charAt(key.length - 1) === ':') {
                    key = key.substr(0, key.length - 1);
                }
                var idx = key.lastIndexOf(':');
                if (idx >= 0) {
                    return key.substr(0, idx + 1);
                }
                return null;
            };
            PermissionCheckEditor.prototype.getButtons = function () {
                return [];
            };
            PermissionCheckEditor.prototype.createToolbarExtensions = function () {
                var _this = this;
                _super.prototype.createToolbarExtensions.call(this);
                Serenity.GridUtils.addQuickSearchInputCustom(this.toolbar.element, function (field, text) {
                    _this.searchText = Select2.util.stripDiacritics(Q.trimToNull(text) || '').toLowerCase();
                    _this.view.setItems(_this.view.getItems(), true);
                });
            };
            PermissionCheckEditor.prototype.getSortedGroupAndPermissionKeys = function (titleByKey) {
                var keys = Q.getRemoteData('Administration.PermissionKeys').Entities;
                var titleWithGroup = {};
                for (var _i = 0, keys_1 = keys; _i < keys_1.length; _i++) {
                    var k = keys_1[_i];
                    var s = k;
                    if (!s) {
                        continue;
                    }
                    if (s.charAt(s.length - 1) == ':') {
                        s = s.substr(0, s.length - 1);
                        if (s.length === 0) {
                            continue;
                        }
                    }
                    if (titleByKey[s]) {
                        continue;
                    }
                    titleByKey[s] = Q.coalesce(Q.tryGetText('Permission.' + s), s);
                    var parts = s.split(':');
                    var group = '';
                    var groupTitle = '';
                    for (var i = 0; i < parts.length - 1; i++) {
                        group = group + parts[i] + ':';
                        var txt = Q.tryGetText('Permission.' + group);
                        if (txt == null) {
                            txt = parts[i];
                        }
                        titleByKey[group] = txt;
                        groupTitle = groupTitle + titleByKey[group] + ':';
                        titleWithGroup[group] = groupTitle;
                    }
                    titleWithGroup[s] = groupTitle + titleByKey[s];
                }
                keys = Object.keys(titleByKey);
                keys = keys.sort(function (x, y) { return Q.turkishLocaleCompare(titleWithGroup[x], titleWithGroup[y]); });
                return keys;
            };
            Object.defineProperty(PermissionCheckEditor.prototype, "value", {
                get: function () {
                    var result = [];
                    for (var _i = 0, _a = this.view.getItems(); _i < _a.length; _i++) {
                        var item = _a[_i];
                        if (item.GrantRevoke != null && item.Key.charAt(item.Key.length - 1) != ':') {
                            result.push({ PermissionKey: item.Key, Granted: item.GrantRevoke });
                        }
                    }
                    return result;
                },
                set: function (value) {
                    for (var _i = 0, _a = this.view.getItems(); _i < _a.length; _i++) {
                        var item = _a[_i];
                        item.GrantRevoke = null;
                    }
                    if (value != null) {
                        for (var _b = 0, value_1 = value; _b < value_1.length; _b++) {
                            var row = value_1[_b];
                            var r = this.view.getItemById(row.PermissionKey);
                            if (r) {
                                r.GrantRevoke = Q.coalesce(row.Granted, true);
                            }
                        }
                    }
                    this.setItems(this.getItems());
                },
                enumerable: true,
                configurable: true
            });
            Object.defineProperty(PermissionCheckEditor.prototype, "rolePermissions", {
                get: function () {
                    return Object.keys(this._rolePermissions);
                },
                set: function (value) {
                    this._rolePermissions = {};
                    if (value) {
                        for (var _i = 0, value_2 = value; _i < value_2.length; _i++) {
                            var k = value_2[_i];
                            this._rolePermissions[k] = true;
                        }
                    }
                    this.setItems(this.getItems());
                },
                enumerable: true,
                configurable: true
            });
            Object.defineProperty(PermissionCheckEditor.prototype, "implicitPermissions", {
                set: function (value) {
                    this._implicitPermissions = {};
                    if (value) {
                        for (var _i = 0, _a = Object.keys(value); _i < _a.length; _i++) {
                            var k = _a[_i];
                            this._implicitPermissions[k] = this._implicitPermissions[k] || {};
                            var l = value[k];
                            if (l) {
                                for (var _b = 0, l_1 = l; _b < l_1.length; _b++) {
                                    var s = l_1[_b];
                                    this._implicitPermissions[k][s] = true;
                                }
                            }
                        }
                    }
                },
                enumerable: true,
                configurable: true
            });
            PermissionCheckEditor = __decorate([
                Serenity.Decorators.registerEditor([Serenity.IGetEditValue, Serenity.ISetEditValue])
            ], PermissionCheckEditor);
            return PermissionCheckEditor;
        }(Serenity.DataGrid));
        Administration.PermissionCheckEditor = PermissionCheckEditor;
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var UserPermissionDialog = /** @class */ (function (_super) {
            __extends(UserPermissionDialog, _super);
            function UserPermissionDialog(opt) {
                var _this = _super.call(this, opt) || this;
                _this.permissions = new Administration.PermissionCheckEditor(_this.byId('Permissions'), {
                    showRevoke: true
                });
                Administration.UserPermissionService.List({
                    UserID: _this.options.userID,
                    Module: null,
                    Submodule: null
                }, function (response) {
                    _this.permissions.value = response.Entities;
                });
                Administration.UserPermissionService.ListRolePermissions({
                    UserID: _this.options.userID,
                    Module: null,
                    Submodule: null,
                }, function (response) {
                    _this.permissions.rolePermissions = response.Entities;
                });
                _this.permissions.implicitPermissions = Q.getRemoteData('Administration.ImplicitPermissions');
                return _this;
            }
            UserPermissionDialog.prototype.getDialogOptions = function () {
                var _this = this;
                var opt = _super.prototype.getDialogOptions.call(this);
                opt.buttons = [
                    {
                        text: Q.text('Dialogs.OkButton'),
                        click: function (e) {
                            Administration.UserPermissionService.Update({
                                UserID: _this.options.userID,
                                Permissions: _this.permissions.value,
                                Module: null,
                                Submodule: null
                            }, function (response) {
                                _this.dialogClose();
                                window.setTimeout(function () { return Q.notifySuccess(Q.text('Site.UserPermissionDialog.SaveSuccess')); }, 0);
                            });
                        }
                    }, {
                        text: Q.text('Dialogs.CancelButton'),
                        click: function () { return _this.dialogClose(); }
                    }
                ];
                opt.title = Q.format(Q.text('Site.UserPermissionDialog.DialogTitle'), this.options.username);
                return opt;
            };
            UserPermissionDialog.prototype.getTemplate = function () {
                return '<div id="~_Permissions"></div>';
            };
            UserPermissionDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], UserPermissionDialog);
            return UserPermissionDialog;
        }(Serenity.TemplatedDialog));
        Administration.UserPermissionDialog = UserPermissionDialog;
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var RoleCheckEditor = /** @class */ (function (_super) {
            __extends(RoleCheckEditor, _super);
            function RoleCheckEditor(div) {
                return _super.call(this, div) || this;
            }
            RoleCheckEditor.prototype.createToolbarExtensions = function () {
                var _this = this;
                _super.prototype.createToolbarExtensions.call(this);
                Serenity.GridUtils.addQuickSearchInputCustom(this.toolbar.element, function (field, text) {
                    _this.searchText = Select2.util.stripDiacritics(text || '').toUpperCase();
                    _this.view.setItems(_this.view.getItems(), true);
                });
            };
            RoleCheckEditor.prototype.getButtons = function () {
                return [];
            };
            RoleCheckEditor.prototype.getTreeItems = function () {
                return Administration.RoleRow.getLookup().items.map(function (role) { return ({
                    id: role.RoleId.toString(),
                    text: role.RoleName
                }); });
            };
            RoleCheckEditor.prototype.onViewFilter = function (item) {
                return _super.prototype.onViewFilter.call(this, item) &&
                    (Q.isEmptyOrNull(this.searchText) ||
                        Select2.util.stripDiacritics(item.text || '')
                            .toUpperCase().indexOf(this.searchText) >= 0);
            };
            RoleCheckEditor = __decorate([
                Serenity.Decorators.registerEditor()
            ], RoleCheckEditor);
            return RoleCheckEditor;
        }(Serenity.CheckTreeEditor));
        Administration.RoleCheckEditor = RoleCheckEditor;
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Administration;
    (function (Administration) {
        var UserRoleDialog = /** @class */ (function (_super) {
            __extends(UserRoleDialog, _super);
            function UserRoleDialog(opt) {
                var _this = _super.call(this, opt) || this;
                _this.permissions = new Administration.RoleCheckEditor(_this.byId('Roles'));
                Administration.UserRoleService.List({
                    UserID: _this.options.userID
                }, function (response) {
                    _this.permissions.value = response.Entities.map(function (x) { return x.toString(); });
                });
                return _this;
            }
            UserRoleDialog.prototype.getDialogOptions = function () {
                var _this = this;
                var opt = _super.prototype.getDialogOptions.call(this);
                opt.buttons = [{
                        text: Q.text('Dialogs.OkButton'),
                        click: function () {
                            Q.serviceRequest('Administration/UserRole/Update', {
                                UserID: _this.options.userID,
                                Roles: _this.permissions.value.map(function (x) { return parseInt(x, 10); })
                            }, function (response) {
                                _this.dialogClose();
                                Q.notifySuccess(Q.text('Site.UserRoleDialog.SaveSuccess'));
                            });
                        }
                    }, {
                        text: Q.text('Dialogs.CancelButton'),
                        click: function () { return _this.dialogClose(); }
                    }];
                opt.title = Q.format(Q.text('Site.UserRoleDialog.DialogTitle'), this.options.username);
                return opt;
            };
            UserRoleDialog.prototype.getTemplate = function () {
                return "<div id='~_Roles'></div>";
            };
            UserRoleDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], UserRoleDialog);
            return UserRoleDialog;
        }(Serenity.TemplatedDialog));
        Administration.UserRoleDialog = UserRoleDialog;
    })(Administration = Serene3.Administration || (Serene3.Administration = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicProgressDialog = /** @class */ (function (_super) {
        __extends(BasicProgressDialog, _super);
        function BasicProgressDialog() {
            var _this = _super.call(this) || this;
            _this.byId('ProgressBar').progressbar({
                max: 100,
                value: 0,
                change: function (e, v) {
                    _this.byId('ProgressLabel').text(_this.value + ' / ' + _this.max);
                }
            });
            return _this;
        }
        Object.defineProperty(BasicProgressDialog.prototype, "max", {
            get: function () {
                return this.byId('ProgressBar').progressbar().progressbar('option', 'max');
            },
            set: function (value) {
                this.byId('ProgressBar').progressbar().progressbar('option', 'max', value);
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(BasicProgressDialog.prototype, "value", {
            get: function () {
                return this.byId('ProgressBar').progressbar('value');
            },
            set: function (value) {
                this.byId('ProgressBar').progressbar().progressbar('value', value);
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(BasicProgressDialog.prototype, "title", {
            get: function () {
                return this.element.dialog().dialog('option', 'title');
            },
            set: function (value) {
                this.element.dialog().dialog('option', 'title', value);
            },
            enumerable: true,
            configurable: true
        });
        BasicProgressDialog.prototype.getDialogOptions = function () {
            var _this = this;
            var opt = _super.prototype.getDialogOptions.call(this);
            opt.title = Q.text('Site.BasicProgressDialog.PleaseWait');
            opt.width = 600;
            opt.buttons = [{
                    text: Q.text('Dialogs.CancelButton'),
                    click: function () {
                        _this.cancelled = true;
                        _this.element.closest('.ui-dialog')
                            .find('.ui-dialog-buttonpane .ui-button')
                            .attr('disabled', 'disabled')
                            .css('opacity', '0.5');
                        _this.element.dialog('option', 'title', Q.trimToNull(_this.cancelTitle) ||
                            Q.text('Site.BasicProgressDialog.CancelTitle'));
                    }
                }];
            return opt;
        };
        BasicProgressDialog.prototype.initDialog = function () {
            _super.prototype.initDialog.call(this);
            this.element.closest('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
        };
        BasicProgressDialog.prototype.getTemplate = function () {
            return ("<div class='s-DialogContent s-BasicProgressDialogContent'>" +
                "<div id='~_StatusText' class='status-text' ></div>" +
                "<div id='~_ProgressBar' class='progress-bar'>" +
                "<div id='~_ProgressLabel' class='progress-label' ></div>" +
                "</div>" +
                "</div>");
        };
        return BasicProgressDialog;
    }(Serenity.TemplatedDialog));
    Serene3.BasicProgressDialog = BasicProgressDialog;
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Common;
    (function (Common) {
        var BulkServiceAction = /** @class */ (function () {
            function BulkServiceAction() {
            }
            BulkServiceAction.prototype.createProgressDialog = function () {
                this.progressDialog = new Serene3.BasicProgressDialog();
                this.progressDialog.dialogOpen();
                this.progressDialog.max = this.keys.length;
                this.progressDialog.value = 0;
            };
            BulkServiceAction.prototype.getConfirmationFormat = function () {
                return Q.text('Site.BulkServiceAction.ConfirmationFormat');
            };
            BulkServiceAction.prototype.getConfirmationMessage = function (targetCount) {
                return Q.format(this.getConfirmationFormat(), targetCount);
            };
            BulkServiceAction.prototype.confirm = function (targetCount, action) {
                Q.confirm(this.getConfirmationMessage(targetCount), action);
            };
            BulkServiceAction.prototype.getNothingToProcessMessage = function () {
                return Q.text('Site.BulkServiceAction.NothingToProcess');
            };
            BulkServiceAction.prototype.nothingToProcess = function () {
                Q.notifyError(this.getNothingToProcessMessage());
            };
            BulkServiceAction.prototype.getParallelRequests = function () {
                return 1;
            };
            BulkServiceAction.prototype.getBatchSize = function () {
                return 1;
            };
            BulkServiceAction.prototype.startParallelExecution = function () {
                this.createProgressDialog();
                this.successCount = 0;
                this.errorCount = 0;
                this.pendingRequests = 0;
                this.completedRequests = 0;
                this.errorCount = 0;
                this.errorByKey = {};
                this.queue = this.keys.slice();
                this.queueIndex = 0;
                var parallelRequests = this.getParallelRequests();
                while (parallelRequests-- > 0) {
                    this.executeNextBatch();
                }
            };
            BulkServiceAction.prototype.serviceCallCleanup = function () {
                this.pendingRequests--;
                this.completedRequests++;
                var title = Q.text((this.progressDialog.cancelled ?
                    'Site.BasicProgressDialog.CancelTitle' : 'Site.BasicProgressDialog.PleaseWait'));
                title += ' (';
                if (this.successCount > 0) {
                    title += Q.format(Q.text('Site.BulkServiceAction.SuccessCount'), this.successCount);
                }
                if (this.errorCount > 0) {
                    if (this.successCount > 0) {
                        title += ', ';
                    }
                    title += Q.format(Q.text('Site.BulkServiceAction.ErrorCount'), this.errorCount);
                }
                this.progressDialog.title = title + ')';
                this.progressDialog.value = this.successCount + this.errorCount;
                if (!this.progressDialog.cancelled && this.progressDialog.value < this.keys.length) {
                    this.executeNextBatch();
                }
                else if (this.pendingRequests === 0) {
                    this.progressDialog.dialogClose();
                    this.showResults();
                    if (this.done) {
                        this.done();
                        this.done = null;
                    }
                }
            };
            BulkServiceAction.prototype.executeForBatch = function (batch) {
            };
            BulkServiceAction.prototype.executeNextBatch = function () {
                var batchSize = this.getBatchSize();
                var batch = [];
                while (true) {
                    if (batch.length >= batchSize) {
                        break;
                    }
                    if (this.queueIndex >= this.queue.length) {
                        break;
                    }
                    batch.push(this.queue[this.queueIndex++]);
                }
                if (batch.length > 0) {
                    this.pendingRequests++;
                    this.executeForBatch(batch);
                }
            };
            BulkServiceAction.prototype.getAllHadErrorsFormat = function () {
                return Q.text('Site.BulkServiceAction.AllHadErrorsFormat');
            };
            BulkServiceAction.prototype.showAllHadErrors = function () {
                Q.notifyError(Q.format(this.getAllHadErrorsFormat(), this.errorCount));
            };
            BulkServiceAction.prototype.getSomeHadErrorsFormat = function () {
                return Q.text('Site.BulkServiceAction.SomeHadErrorsFormat');
            };
            BulkServiceAction.prototype.showSomeHadErrors = function () {
                Q.notifyWarning(Q.format(this.getSomeHadErrorsFormat(), this.successCount, this.errorCount));
            };
            BulkServiceAction.prototype.getAllSuccessFormat = function () {
                return Q.text('Site.BulkServiceAction.AllSuccessFormat');
            };
            BulkServiceAction.prototype.showAllSuccess = function () {
                Q.notifySuccess(Q.format(this.getAllSuccessFormat(), this.successCount));
            };
            BulkServiceAction.prototype.showResults = function () {
                if (this.errorCount === 0 && this.successCount === 0) {
                    this.nothingToProcess();
                    return;
                }
                if (this.errorCount > 0 && this.successCount === 0) {
                    this.showAllHadErrors();
                    return;
                }
                if (this.errorCount > 0) {
                    this.showSomeHadErrors();
                    return;
                }
                this.showAllSuccess();
            };
            BulkServiceAction.prototype.execute = function (keys) {
                var _this = this;
                this.keys = keys;
                if (this.keys.length === 0) {
                    this.nothingToProcess();
                    return;
                }
                this.confirm(this.keys.length, function () { return _this.startParallelExecution(); });
            };
            BulkServiceAction.prototype.get_successCount = function () {
                return this.successCount;
            };
            BulkServiceAction.prototype.set_successCount = function (value) {
                this.successCount = value;
            };
            BulkServiceAction.prototype.get_errorCount = function () {
                return this.errorCount;
            };
            BulkServiceAction.prototype.set_errorCount = function (value) {
                this.errorCount = value;
            };
            return BulkServiceAction;
        }());
        Common.BulkServiceAction = BulkServiceAction;
    })(Common = Serene3.Common || (Serene3.Common = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var DialogUtils;
    (function (DialogUtils) {
        function pendingChangesConfirmation(element, hasPendingChanges) {
            element.on('dialogbeforeclose panelbeforeclose', function (e) {
                if (!Serenity.WX.hasOriginalEvent(e) || !hasPendingChanges()) {
                    return;
                }
                e.preventDefault();
                Q.confirm('You have pending changes. Save them?', function () { return element.find('div.save-and-close-button').click(); }, {
                    onNo: function () {
                        if (element.hasClass('ui-dialog-content'))
                            element.dialog('close');
                        else if (element.hasClass('s-Panel'))
                            Serenity.TemplatedDialog.closePanel(element);
                    }
                });
            });
        }
        DialogUtils.pendingChangesConfirmation = pendingChangesConfirmation;
    })(DialogUtils = Serene3.DialogUtils || (Serene3.DialogUtils = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Common;
    (function (Common) {
        var EnumSelectFormatter = /** @class */ (function () {
            function EnumSelectFormatter() {
                this.allowClear = true;
            }
            EnumSelectFormatter.prototype.format = function (ctx) {
                var enumType = Serenity.EnumTypeRegistry.get(this.enumKey);
                var sb = "<select>";
                if (this.allowClear) {
                    sb += '<option value="">';
                    sb += Q.htmlEncode(this.emptyItemText || Q.text("Controls.SelectEditor.EmptyItemText"));
                    sb += '</option>';
                }
                for (var _i = 0, _a = Object.keys(enumType).filter(function (v) { return !isNaN(parseInt(v, 10)); }); _i < _a.length; _i++) {
                    var x = _a[_i];
                    sb += '<option value="' + Q.attrEncode(x) + '"';
                    if (x == ctx.value)
                        sb += " selected";
                    var name = enumType[x];
                    sb += ">";
                    sb += Q.htmlEncode(Q.tryGetText("Enums." + this.enumKey + "." + name) || name);
                    sb += "</option>";
                }
                sb += "</select>";
                return sb;
            };
            __decorate([
                Serenity.Decorators.option()
            ], EnumSelectFormatter.prototype, "enumKey", void 0);
            __decorate([
                Serenity.Decorators.option()
            ], EnumSelectFormatter.prototype, "allowClear", void 0);
            __decorate([
                Serenity.Decorators.option()
            ], EnumSelectFormatter.prototype, "emptyItemText", void 0);
            EnumSelectFormatter = __decorate([
                Serenity.Decorators.registerFormatter()
            ], EnumSelectFormatter);
            return EnumSelectFormatter;
        }());
        Common.EnumSelectFormatter = EnumSelectFormatter;
    })(Common = Serene3.Common || (Serene3.Common = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Common;
    (function (Common) {
        var ExcelExportHelper;
        (function (ExcelExportHelper) {
            function createToolButton(options) {
                return {
                    hint: Q.coalesce(options.hint, 'Excel'),
                    title: Q.coalesce(options.title, ''),
                    cssClass: 'export-xlsx-button',
                    onClick: function () {
                        if (!options.onViewSubmit()) {
                            return;
                        }
                        var grid = options.grid;
                        var request = Q.deepClone(grid.getView().params);
                        request.Take = 0;
                        request.Skip = 0;
                        var sortBy = grid.getView().sortBy;
                        if (sortBy) {
                            request.Sort = sortBy;
                        }
                        request.IncludeColumns = [];
                        var columns = grid.getGrid().getColumns();
                        for (var _i = 0, columns_1 = columns; _i < columns_1.length; _i++) {
                            var column = columns_1[_i];
                            request.IncludeColumns.push(column.id || column.field);
                        }
                        Q.postToService({ service: options.service, request: request, target: '_blank' });
                    },
                    separator: options.separator
                };
            }
            ExcelExportHelper.createToolButton = createToolButton;
        })(ExcelExportHelper = Common.ExcelExportHelper || (Common.ExcelExportHelper = {}));
    })(Common = Serene3.Common || (Serene3.Common = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Common;
    (function (Common) {
        var GridEditorBase = /** @class */ (function (_super) {
            __extends(GridEditorBase, _super);
            function GridEditorBase(container) {
                var _this = _super.call(this, container) || this;
                _this.nextId = 1;
                return _this;
            }
            GridEditorBase.prototype.getIdProperty = function () { return "__id"; };
            GridEditorBase.prototype.id = function (entity) {
                return entity[this.getIdProperty()];
            };
            GridEditorBase.prototype.getNextId = function () {
                return "`" + this.nextId++;
            };
            GridEditorBase.prototype.setNewId = function (entity) {
                entity[this.getIdProperty()] = this.getNextId();
            };
            GridEditorBase.prototype.save = function (opt, callback) {
                var _this = this;
                var request = opt.request;
                var row = Q.deepClone(request.Entity);
                var id = this.id(row);
                if (id == null) {
                    row[this.getIdProperty()] = this.getNextId();
                }
                if (!this.validateEntity(row, id)) {
                    return;
                }
                var items = this.view.getItems().slice();
                if (id == null) {
                    items.push(row);
                }
                else {
                    var index = Q.indexOf(items, function (x) { return _this.id(x) === id; });
                    items[index] = Q.deepClone({}, items[index], row);
                }
                this.setEntities(items);
                callback({});
            };
            GridEditorBase.prototype.deleteEntity = function (id) {
                this.view.deleteItem(id);
                return true;
            };
            GridEditorBase.prototype.validateEntity = function (row, id) {
                return true;
            };
            GridEditorBase.prototype.setEntities = function (items) {
                this.view.setItems(items, true);
            };
            GridEditorBase.prototype.getNewEntity = function () {
                return {};
            };
            GridEditorBase.prototype.getButtons = function () {
                var _this = this;
                return [{
                        title: this.getAddButtonCaption(),
                        cssClass: 'add-button',
                        onClick: function () {
                            _this.createEntityDialog(_this.getItemType(), function (dlg) {
                                var dialog = dlg;
                                dialog.onSave = function (opt, callback) { return _this.save(opt, callback); };
                                dialog.loadEntityAndOpenDialog(_this.getNewEntity());
                            });
                        }
                    }];
            };
            GridEditorBase.prototype.editItem = function (entityOrId) {
                var _this = this;
                var id = entityOrId;
                var item = this.view.getItemById(id);
                this.createEntityDialog(this.getItemType(), function (dlg) {
                    var dialog = dlg;
                    dialog.onDelete = function (opt, callback) {
                        if (!_this.deleteEntity(id)) {
                            return;
                        }
                        callback({});
                    };
                    dialog.onSave = function (opt, callback) { return _this.save(opt, callback); };
                    dialog.loadEntityAndOpenDialog(item);
                });
                ;
            };
            GridEditorBase.prototype.getEditValue = function (property, target) {
                target[property.name] = this.value;
            };
            GridEditorBase.prototype.setEditValue = function (source, property) {
                this.value = source[property.name];
            };
            Object.defineProperty(GridEditorBase.prototype, "value", {
                get: function () {
                    var p = this.getIdProperty();
                    return this.view.getItems().map(function (x) {
                        var y = Q.deepClone(x);
                        var id = y[p];
                        if (id && id.toString().charAt(0) == '`')
                            delete y[p];
                        return y;
                    });
                },
                set: function (value) {
                    var _this = this;
                    var p = this.getIdProperty();
                    this.view.setItems((value || []).map(function (x) {
                        var y = Q.deepClone(x);
                        if (y[p] == null)
                            y[p] = "`" + _this.getNextId();
                        return y;
                    }), true);
                },
                enumerable: true,
                configurable: true
            });
            GridEditorBase.prototype.getGridCanLoad = function () {
                return false;
            };
            GridEditorBase.prototype.usePager = function () {
                return false;
            };
            GridEditorBase.prototype.getInitialTitle = function () {
                return null;
            };
            GridEditorBase.prototype.createQuickSearchInput = function () {
            };
            GridEditorBase = __decorate([
                Serenity.Decorators.registerClass([Serenity.IGetEditValue, Serenity.ISetEditValue]),
                Serenity.Decorators.editor(),
                Serenity.Decorators.element("<div/>")
            ], GridEditorBase);
            return GridEditorBase;
        }(Serenity.EntityGrid));
        Common.GridEditorBase = GridEditorBase;
    })(Common = Serene3.Common || (Serene3.Common = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Common;
    (function (Common) {
        var GridEditorDialog = /** @class */ (function (_super) {
            __extends(GridEditorDialog, _super);
            function GridEditorDialog() {
                return _super !== null && _super.apply(this, arguments) || this;
            }
            GridEditorDialog.prototype.getIdProperty = function () { return "__id"; };
            GridEditorDialog.prototype.destroy = function () {
                this.onSave = null;
                this.onDelete = null;
                _super.prototype.destroy.call(this);
            };
            GridEditorDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                // apply changes button doesn't work properly with in-memory grids yet
                if (this.applyChangesButton) {
                    this.applyChangesButton.hide();
                }
            };
            GridEditorDialog.prototype.saveHandler = function (options, callback) {
                this.onSave && this.onSave(options, callback);
            };
            GridEditorDialog.prototype.deleteHandler = function (options, callback) {
                this.onDelete && this.onDelete(options, callback);
            };
            GridEditorDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], GridEditorDialog);
            return GridEditorDialog;
        }(Serenity.EntityDialog));
        Common.GridEditorDialog = GridEditorDialog;
    })(Common = Serene3.Common || (Serene3.Common = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    /**
     * This is an editor widget but it only displays a text, not edits it.
     *
     */
    var StaticTextBlock = /** @class */ (function (_super) {
        __extends(StaticTextBlock, _super);
        function StaticTextBlock(container, options) {
            var _this = _super.call(this, container, options) || this;
            // hide the caption label for this editor if in a form. ugly hack
            if (_this.options.hideLabel)
                _this.element.closest('.field').find('.caption').hide();
            _this.updateElementContent();
            return _this;
        }
        StaticTextBlock.prototype.updateElementContent = function () {
            var text = Q.coalesce(this.options.text, this.value);
            // if isLocalText is set, text is actually a local text key
            if (this.options.isLocalText)
                text = Q.text(text);
            // don't html encode if isHtml option is true
            if (this.options.isHtml)
                this.element.html(text);
            else
                this.element.text(text);
        };
        /**
         * By implementing ISetEditValue interface, we allow this editor to display its field value.
         * But only do this when our text content is not explicitly set in options
         */
        StaticTextBlock.prototype.setEditValue = function (source, property) {
            if (this.options.text == null) {
                this.value = Q.coalesce(this.options.text, source[property.name]);
                this.updateElementContent();
            }
        };
        StaticTextBlock = __decorate([
            Serenity.Decorators.element("<div/>"),
            Serenity.Decorators.registerEditor([Serenity.ISetEditValue])
        ], StaticTextBlock);
        return StaticTextBlock;
    }(Serenity.Widget));
    Serene3.StaticTextBlock = StaticTextBlock;
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Common;
    (function (Common) {
        var LanguageSelection = /** @class */ (function (_super) {
            __extends(LanguageSelection, _super);
            function LanguageSelection(select, currentLanguage) {
                var _this = _super.call(this, select) || this;
                currentLanguage = Q.coalesce(currentLanguage, 'en');
                _this.change(function (e) {
                    $.cookie('LanguagePreference', select.val(), {
                        path: Q.Config.applicationPath,
                        expires: 365
                    });
                    window.location.reload(true);
                });
                Q.getLookupAsync('Administration.Language').then(function (x) {
                    if (!Q.any(x.items, function (z) { return z.LanguageId === currentLanguage; })) {
                        var idx = currentLanguage.lastIndexOf('-');
                        if (idx >= 0) {
                            currentLanguage = currentLanguage.substr(0, idx);
                            if (!Q.any(x.items, function (y) { return y.LanguageId === currentLanguage; })) {
                                currentLanguage = 'en';
                            }
                        }
                        else {
                            currentLanguage = 'en';
                        }
                    }
                    for (var _i = 0, _a = x.items; _i < _a.length; _i++) {
                        var l = _a[_i];
                        Q.addOption(select, l.LanguageId, l.LanguageName);
                    }
                    select.val(currentLanguage);
                });
                return _this;
            }
            return LanguageSelection;
        }(Serenity.Widget));
        Common.LanguageSelection = LanguageSelection;
    })(Common = Serene3.Common || (Serene3.Common = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Common;
    (function (Common) {
        var SidebarSearch = /** @class */ (function (_super) {
            __extends(SidebarSearch, _super);
            function SidebarSearch(input, menuUL) {
                var _this = _super.call(this, input) || this;
                new Serenity.QuickSearchInput(input, {
                    onSearch: function (field, text, success) {
                        _this.updateMatchFlags(text);
                        success(true);
                    }
                });
                _this.menuUL = menuUL;
                return _this;
            }
            SidebarSearch.prototype.updateMatchFlags = function (text) {
                var liList = this.menuUL.find('li').removeClass('non-match');
                text = Q.trimToNull(text);
                if (text == null) {
                    liList.show();
                    liList.removeClass('expanded');
                    return;
                }
                var parts = text.replace(',', ' ').split(' ').filter(function (x) { return !Q.isTrimmedEmpty(x); });
                for (var i = 0; i < parts.length; i++) {
                    parts[i] = Q.trimToNull(Select2.util.stripDiacritics(parts[i]).toUpperCase());
                }
                var items = liList;
                items.each(function (idx, e) {
                    var x = $(e);
                    var title = Select2.util.stripDiacritics(Q.coalesce(x.text(), '').toUpperCase());
                    for (var _i = 0, parts_1 = parts; _i < parts_1.length; _i++) {
                        var p = parts_1[_i];
                        if (p != null && !(title.indexOf(p) !== -1)) {
                            x.addClass('non-match');
                            break;
                        }
                    }
                });
                var matchingItems = items.not('.non-match');
                var visibles = matchingItems.parents('li').add(matchingItems);
                var nonVisibles = liList.not(visibles);
                nonVisibles.hide().addClass('non-match');
                visibles.show();
                liList.addClass('expanded');
            };
            return SidebarSearch;
        }(Serenity.Widget));
        Common.SidebarSearch = SidebarSearch;
    })(Common = Serene3.Common || (Serene3.Common = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Common;
    (function (Common) {
        var ThemeSelection = /** @class */ (function (_super) {
            __extends(ThemeSelection, _super);
            function ThemeSelection(select) {
                var _this = _super.call(this, select) || this;
                _this.change(function (e) {
                    var path = Q.Config.applicationPath;
                    if (path && path != '/' && Q.endsWith(path, '/'))
                        path = path.substr(0, path.length - 1);
                    $.cookie('ProfisTeoTheme', select.val(), {
                        path: path,
                        expires: 365
                    });
                    var theme = select.val() || '';
                    var darkSidebar = theme.indexOf('light') < 0;
                    $('body').removeClass('skin-' + _this.getCurrentTheme());
                    $('body').addClass('skin-' + theme)
                        .toggleClass('dark-sidebar', darkSidebar)
                        .toggleClass('light-sidebar', !darkSidebar);
                });
                Q.addOption(select, 'azure', Q.text('Site.Layout.ThemeAzure'));
                Q.addOption(select, 'azure-light', Q.text('Site.Layout.ThemeAzureLight'));
                Q.addOption(select, 'cosmos', Q.text('Site.Layout.ThemeCosmos'));
                Q.addOption(select, 'cosmos-light', Q.text('Site.Layout.ThemeCosmosLight'));
                Q.addOption(select, 'glassy', Q.text('Site.Layout.ThemeGlassy'));
                Q.addOption(select, 'glassy-light', Q.text('Site.Layout.ThemeGlassyLight'));
                Q.addOption(select, 'blue', Q.text('Site.Layout.ThemeBlue'));
                Q.addOption(select, 'blue-light', Q.text('Site.Layout.ThemeBlueLight'));
                Q.addOption(select, 'purple', Q.text('Site.Layout.ThemePurple'));
                Q.addOption(select, 'purple-light', Q.text('Site.Layout.ThemePurpleLight'));
                Q.addOption(select, 'red', Q.text('Site.Layout.ThemeRed'));
                Q.addOption(select, 'red-light', Q.text('Site.Layout.ThemeRedLight'));
                Q.addOption(select, 'green', Q.text('Site.Layout.ThemeGreen'));
                Q.addOption(select, 'green-light', Q.text('Site.Layout.ThemeGreenLight'));
                Q.addOption(select, 'yellow', Q.text('Site.Layout.ThemeYellow'));
                Q.addOption(select, 'yellow-light', Q.text('Site.Layout.ThemeYellowLight'));
                Q.addOption(select, 'black', Q.text('Site.Layout.ThemeBlack'));
                Q.addOption(select, 'black-light', Q.text('Site.Layout.ThemeBlackLight'));
                select.val(_this.getCurrentTheme());
                return _this;
            }
            ThemeSelection.prototype.getCurrentTheme = function () {
                var skinClass = Q.first(($('body').attr('class') || '').split(' '), function (x) { return Q.startsWith(x, 'skin-'); });
                if (skinClass) {
                    return skinClass.substr(5);
                }
                return 'blue';
            };
            return ThemeSelection;
        }(Serenity.Widget));
        Common.ThemeSelection = ThemeSelection;
    })(Common = Serene3.Common || (Serene3.Common = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Common;
    (function (Common) {
        var PdfExportHelper;
        (function (PdfExportHelper) {
            function toAutoTableColumns(srcColumns, columnStyles, columnTitles) {
                return srcColumns.map(function (src) {
                    var col = {
                        dataKey: src.id || src.field,
                        title: src.name || ''
                    };
                    if (columnTitles && columnTitles[col.dataKey] != null)
                        col.title = columnTitles[col.dataKey];
                    var style = {};
                    if ((src.cssClass || '').indexOf("align-right") >= 0)
                        style.halign = 'right';
                    else if ((src.cssClass || '').indexOf("align-center") >= 0)
                        style.halign = 'center';
                    columnStyles[col.dataKey] = style;
                    return col;
                });
            }
            function toAutoTableData(entities, keys, srcColumns) {
                var el = document.createElement('span');
                var row = 0;
                return entities.map(function (item) {
                    var dst = {};
                    for (var cell = 0; cell < srcColumns.length; cell++) {
                        var src = srcColumns[cell];
                        var fld = src.field || '';
                        var key = keys[cell];
                        var txt = void 0;
                        var html = void 0;
                        if (src.formatter) {
                            html = src.formatter(row, cell, item[fld], src, item);
                        }
                        else if (src.format) {
                            html = src.format({ row: row, cell: cell, item: item, value: item[fld] });
                        }
                        else {
                            dst[key] = item[fld];
                            continue;
                        }
                        if (!html || (html.indexOf('<') < 0 && html.indexOf('&') < 0))
                            dst[key] = html;
                        else {
                            el.innerHTML = html;
                            if (el.children.length == 1 &&
                                $(el.children[0]).is(":input")) {
                                dst[key] = $(el.children[0]).val();
                            }
                            else if (el.children.length == 1 &&
                                $(el.children).is('.check-box')) {
                                dst[key] = $(el.children).hasClass("checked") ? "X" : "";
                            }
                            else
                                dst[key] = el.textContent || '';
                        }
                    }
                    row++;
                    return dst;
                });
            }
            function exportToPdf(options) {
                var g = options.grid;
                if (!options.onViewSubmit())
                    return;
                includeAutoTable();
                var request = Q.deepClone(g.view.params);
                request.Take = 0;
                request.Skip = 0;
                var sortBy = g.view.sortBy;
                if (sortBy != null)
                    request.Sort = sortBy;
                var gridColumns = g.slickGrid.getColumns();
                gridColumns = gridColumns.filter(function (x) { return x.id !== "__select__"; });
                request.IncludeColumns = [];
                for (var _i = 0, gridColumns_1 = gridColumns; _i < gridColumns_1.length; _i++) {
                    var column = gridColumns_1[_i];
                    request.IncludeColumns.push(column.id || column.field);
                }
                Q.serviceCall({
                    url: g.view.url,
                    request: request,
                    onSuccess: function (response) {
                        var doc = new jsPDF('l', 'pt');
                        var srcColumns = gridColumns;
                        var columnStyles = {};
                        var columns = toAutoTableColumns(srcColumns, columnStyles, options.columnTitles);
                        var keys = columns.map(function (x) { return x.dataKey; });
                        var entities = response.Entities || [];
                        var data = toAutoTableData(entities, keys, srcColumns);
                        doc.setFontSize(options.titleFontSize || 10);
                        doc.setFontStyle('bold');
                        var reportTitle = options.reportTitle || g.getTitle() || "Report";
                        doc.autoTableText(reportTitle, doc.internal.pageSize.width / 2, options.titleTop || 25, { halign: 'center' });
                        var totalPagesExp = "{{T}}";
                        var pageNumbers = options.pageNumbers == null || options.pageNumbers;
                        var autoOptions = $.extend({
                            margin: { top: 25, left: 25, right: 25, bottom: pageNumbers ? 25 : 30 },
                            startY: 60,
                            styles: {
                                fontSize: 8,
                                overflow: 'linebreak',
                                cellPadding: 2,
                                valign: 'middle'
                            },
                            columnStyles: columnStyles
                        }, options.tableOptions);
                        if (pageNumbers) {
                            var footer = function (data) {
                                var str = data.pageCount;
                                // Total page number plugin only available in jspdf v1.0+
                                if (typeof doc.putTotalPages === 'function') {
                                    str = str + " / " + totalPagesExp;
                                }
                                doc.autoTableText(str, doc.internal.pageSize.width / 2, doc.internal.pageSize.height - autoOptions.margin.bottom, {
                                    halign: 'center'
                                });
                            };
                            autoOptions.afterPageContent = footer;
                        }
                        // Print header of page
                        if (options.printDateTimeHeader == null || options.printDateTimeHeader) {
                            var beforePage = function (data) {
                                doc.setFontStyle('normal');
                                doc.setFontSize(8);
                                // Date and time of the report
                                doc.autoTableText(Q.formatDate(new Date(), "dd-MM-yyyy HH:mm"), doc.internal.pageSize.width - autoOptions.margin.right, 13, {
                                    halign: 'right'
                                });
                            };
                            autoOptions.beforePageContent = beforePage;
                        }
                        doc.autoTable(columns, data, autoOptions);
                        if (typeof doc.putTotalPages === 'function') {
                            doc.putTotalPages(totalPagesExp);
                        }
                        if (!options.output || options.output == "file") {
                            var fileName = options.fileName || options.reportTitle || "{0}_{1}.pdf";
                            fileName = Q.format(fileName, g.getTitle() || "report", Q.formatDate(new Date(), "yyyyMMdd_HHmm"));
                            doc.save(fileName);
                            return;
                        }
                        if (options.autoPrint)
                            doc.autoPrint();
                        var output = options.output;
                        if (output == 'newwindow' || '_blank')
                            output = 'dataurlnewwindow';
                        else if (output == 'window')
                            output = 'datauri';
                        if (output == 'datauri')
                            doc.output(output);
                        else {
                            var tmpOut = doc.output('datauristring');
                            if (output == 'dataurlnewwindow') {
                                var fileTmpName = options.reportTitle || g.getTitle();
                                var url_with_name = tmpOut.replace("data:application/pdf;", "data:application/pdf;name=" + fileTmpName + ".pdf;");
                                var html = '<html>' +
                                    '<style>html, body { padding: 0; margin: 0; } iframe { width: 100%; height: 100%; border: 0;}  </style>' +
                                    '<body>' +
                                    '<p></p>' +
                                    '<iframe type="application/pdf" src="' + url_with_name + '"></iframe>' +
                                    '</body></html>';
                                var a = window.open("about:blank", "_blank");
                                a.document.write(html);
                                a.document.close();
                            }
                        }
                    }
                });
            }
            PdfExportHelper.exportToPdf = exportToPdf;
            function createToolButton(options) {
                return {
                    title: options.title || '',
                    hint: options.hint || 'PDF',
                    cssClass: 'export-pdf-button',
                    onClick: function () { return exportToPdf(options); },
                    separator: options.separator
                };
            }
            PdfExportHelper.createToolButton = createToolButton;
            function includeJsPDF() {
                if (typeof jsPDF !== "undefined")
                    return;
                var script = $("jsPDFScript");
                if (script.length > 0)
                    return;
                $("<script/>")
                    .attr("type", "text/javascript")
                    .attr("id", "jsPDFScript")
                    .attr("src", Q.resolveUrl("~/Scripts/jspdf.min.js"))
                    .appendTo(document.head);
            }
            function includeAutoTable() {
                includeJsPDF();
                if (typeof jsPDF === "undefined" ||
                    typeof jsPDF.API == "undefined" ||
                    typeof jsPDF.API.autoTable !== "undefined")
                    return;
                var script = $("jsPDFAutoTableScript");
                if (script.length > 0)
                    return;
                $("<script/>")
                    .attr("type", "text/javascript")
                    .attr("id", "jsPDFAutoTableScript")
                    .attr("src", Q.resolveUrl("~/Scripts/jspdf.plugin.autotable.min.js"))
                    .appendTo(document.head);
            }
        })(PdfExportHelper = Common.PdfExportHelper || (Common.PdfExportHelper = {}));
    })(Common = Serene3.Common || (Serene3.Common = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Common;
    (function (Common) {
        var ReportDialog = /** @class */ (function (_super) {
            __extends(ReportDialog, _super);
            function ReportDialog(options) {
                var _this = _super.call(this, options) || this;
                _this.updateInterface();
                _this.loadReport(_this.options.reportKey);
                return _this;
            }
            ReportDialog.prototype.getDialogButtons = function () {
                return null;
            };
            ReportDialog.prototype.createPropertyGrid = function () {
                this.propertyGrid && this.byId('PropertyGrid').html('').attr('class', '');
                this.propertyGrid = new Serenity.PropertyGrid(this.byId('PropertyGrid'), {
                    idPrefix: this.idPrefix,
                    useCategories: true,
                    items: this.report.Properties
                }).init(null);
            };
            ReportDialog.prototype.loadReport = function (reportKey) {
                var _this = this;
                Q.serviceCall({
                    url: Q.resolveUrl('~/Report/Retrieve'),
                    request: {
                        ReportKey: reportKey
                    },
                    onSuccess: function (response) {
                        _this.report = response;
                        _this.element.dialog().dialog('option', 'title', _this.report.Title);
                        _this.createPropertyGrid();
                        _this.propertyGrid.load(_this.report.InitialSettings || {});
                        _this.updateInterface();
                        _this.dialogOpen();
                    }
                });
            };
            ReportDialog.prototype.updateInterface = function () {
                this.toolbar.findButton('print-preview-button')
                    .toggle(this.report && !this.report.IsDataOnlyReport);
                this.toolbar.findButton('export-pdf-button')
                    .toggle(this.report && !this.report.IsDataOnlyReport);
                this.toolbar.findButton('export-xlsx-button')
                    .toggle(this.report && this.report.IsDataOnlyReport);
            };
            ReportDialog.prototype.executeReport = function (target, ext, download) {
                if (!this.validateForm()) {
                    return;
                }
                var opt = {};
                this.propertyGrid.save(opt);
                Common.ReportHelper.execute({
                    download: download,
                    reportKey: this.report.ReportKey,
                    extension: ext,
                    target: target,
                    params: opt
                });
            };
            ReportDialog.prototype.getToolbarButtons = function () {
                var _this = this;
                return [
                    {
                        title: 'Preview',
                        cssClass: 'print-preview-button',
                        onClick: function () { return _this.executeReport('_blank', null, false); }
                    },
                    {
                        title: 'PDF',
                        cssClass: 'export-pdf-button',
                        onClick: function () { return _this.executeReport('_blank', 'pdf', true); }
                    },
                    {
                        title: 'Excel',
                        cssClass: 'export-xlsx-button',
                        onClick: function () { return _this.executeReport('_blank', 'xlsx', true); }
                    }
                ];
            };
            return ReportDialog;
        }(Serenity.TemplatedDialog));
        Common.ReportDialog = ReportDialog;
    })(Common = Serene3.Common || (Serene3.Common = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Common;
    (function (Common) {
        var ReportHelper;
        (function (ReportHelper) {
            function createToolButton(options) {
                return {
                    title: Q.coalesce(options.title, 'Report'),
                    cssClass: Q.coalesce(options.cssClass, 'print-button'),
                    icon: options.icon,
                    onClick: function () {
                        ReportHelper.execute(options);
                    }
                };
            }
            ReportHelper.createToolButton = createToolButton;
            function execute(options) {
                var opt = options.getParams ? options.getParams() : options.params;
                Q.postToUrl({
                    url: '~/Report/' + (options.download ? 'Download' : 'Render'),
                    params: {
                        key: options.reportKey,
                        ext: Q.coalesce(options.extension, 'pdf'),
                        opt: opt ? $.toJSON(opt) : ''
                    },
                    target: Q.coalesce(options.target, '_blank')
                });
            }
            ReportHelper.execute = execute;
        })(ReportHelper = Common.ReportHelper || (Common.ReportHelper = {}));
    })(Common = Serene3.Common || (Serene3.Common = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Common;
    (function (Common) {
        var ReportPage = /** @class */ (function (_super) {
            __extends(ReportPage, _super);
            function ReportPage(element) {
                var _this = _super.call(this, element) || this;
                $('.report-link', element).click(function (e) { return _this.reportLinkClick(e); });
                $('div.line', element).click(function (e) { return _this.categoryClick(e); });
                new Serenity.QuickSearchInput($('.s-QuickSearchBar input', element), {
                    onSearch: function (field, text, done) {
                        _this.updateMatchFlags(text);
                        done(true);
                    }
                });
                return _this;
            }
            ReportPage.prototype.updateMatchFlags = function (text) {
                var liList = $('.report-list', this.element).find('li').removeClass('non-match');
                text = Q.trimToNull(text);
                if (!text) {
                    liList.children('ul').hide();
                    liList.show().removeClass('expanded');
                    return;
                }
                text = Select2.util.stripDiacritics(text).toUpperCase();
                var reportItems = liList.filter('.report-item');
                reportItems.each(function (ix, e) {
                    var x = $(e);
                    var title = Select2.util.stripDiacritics(Q.coalesce(x.text(), '').toUpperCase());
                    if (title.indexOf(text) < 0) {
                        x.addClass('non-match');
                    }
                });
                var matchingItems = reportItems.not('.non-match');
                var visibles = matchingItems.parents('li').add(matchingItems);
                var nonVisibles = liList.not(visibles);
                nonVisibles.hide().addClass('non-match');
                visibles.show();
                if (visibles.length <= 100) {
                    liList.children('ul').show();
                    liList.addClass('expanded');
                }
            };
            ReportPage.prototype.categoryClick = function (e) {
                var li = $(e.target).closest('li');
                if (li.hasClass('expanded')) {
                    li.find('ul').hide('fast');
                    li.removeClass('expanded');
                    li.find('li').removeClass('expanded');
                }
                else {
                    li.addClass('expanded');
                    li.children('ul').show('fast');
                    if (li.children('ul').children('li').length === 1 && !li.children('ul').children('li').hasClass('expanded')) {
                        li.children('ul').children('li').children('.line').click();
                    }
                }
            };
            ReportPage.prototype.reportLinkClick = function (e) {
                e.preventDefault();
                new Common.ReportDialog({
                    reportKey: $(e.target).data('key')
                }).dialogOpen();
            };
            return ReportPage;
        }(Serenity.Widget));
        Common.ReportPage = ReportPage;
    })(Common = Serene3.Common || (Serene3.Common = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Common;
    (function (Common) {
        var UserPreferenceStorage = /** @class */ (function () {
            function UserPreferenceStorage() {
            }
            UserPreferenceStorage.prototype.getItem = function (key) {
                var value;
                Common.UserPreferenceService.Retrieve({
                    PreferenceType: "UserPreferenceStorage",
                    Name: key
                }, function (response) { return value = response.Value; }, {
                    async: false
                });
                return value;
            };
            UserPreferenceStorage.prototype.setItem = function (key, data) {
                Common.UserPreferenceService.Update({
                    PreferenceType: "UserPreferenceStorage",
                    Name: key,
                    Value: data
                });
            };
            return UserPreferenceStorage;
        }());
        Common.UserPreferenceStorage = UserPreferenceStorage;
    })(Common = Serene3.Common || (Serene3.Common = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var CategoryDialog = /** @class */ (function (_super) {
            __extends(CategoryDialog, _super);
            function CategoryDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new Northwind.CategoryForm(_this.idPrefix);
                return _this;
            }
            CategoryDialog.prototype.getFormKey = function () { return Northwind.CategoryForm.formKey; };
            CategoryDialog.prototype.getIdProperty = function () { return Northwind.CategoryRow.idProperty; };
            CategoryDialog.prototype.getLocalTextPrefix = function () { return Northwind.CategoryRow.localTextPrefix; };
            CategoryDialog.prototype.getNameProperty = function () { return Northwind.CategoryRow.nameProperty; };
            CategoryDialog.prototype.getService = function () { return Northwind.CategoryService.baseUrl; };
            CategoryDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], CategoryDialog);
            return CategoryDialog;
        }(Serenity.EntityDialog));
        Northwind.CategoryDialog = CategoryDialog;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var CategoryGrid = /** @class */ (function (_super) {
            __extends(CategoryGrid, _super);
            function CategoryGrid(container) {
                return _super.call(this, container) || this;
            }
            CategoryGrid.prototype.getColumnsKey = function () { return "Northwind.Category"; };
            CategoryGrid.prototype.getDialogType = function () { return Northwind.CategoryDialog; };
            CategoryGrid.prototype.getIdProperty = function () { return Northwind.CategoryRow.idProperty; };
            CategoryGrid.prototype.getLocalTextPrefix = function () { return Northwind.CategoryRow.localTextPrefix; };
            CategoryGrid.prototype.getService = function () { return Northwind.CategoryService.baseUrl; };
            CategoryGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], CategoryGrid);
            return CategoryGrid;
        }(Serenity.EntityGrid));
        Northwind.CategoryGrid = CategoryGrid;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var CustomerDialog = /** @class */ (function (_super) {
            __extends(CustomerDialog, _super);
            function CustomerDialog() {
                var _this = _super.call(this) || this;
                _this.form = new Northwind.CustomerForm(_this.idPrefix);
                _this.ordersGrid = new Northwind.CustomerOrdersGrid(_this.byId('OrdersGrid'));
                // force order dialog to open in Dialog mode instead of Panel mode
                // which is set as default on OrderDialog with @panelAttribute
                _this.ordersGrid.openDialogsAsPanel = false;
                _this.byId('NoteList').closest('.field').hide().end().appendTo(_this.byId('TabNotes'));
                Serene3.DialogUtils.pendingChangesConfirmation(_this.element, function () { return _this.getSaveState() != _this.loadedState; });
                return _this;
            }
            CustomerDialog.prototype.getFormKey = function () { return Northwind.CustomerForm.formKey; };
            CustomerDialog.prototype.getIdProperty = function () { return Northwind.CustomerRow.idProperty; };
            CustomerDialog.prototype.getLocalTextPrefix = function () { return Northwind.CustomerRow.localTextPrefix; };
            CustomerDialog.prototype.getNameProperty = function () { return Northwind.CustomerRow.nameProperty; };
            CustomerDialog.prototype.getService = function () { return Northwind.CustomerService.baseUrl; };
            CustomerDialog.prototype.getSaveState = function () {
                try {
                    return $.toJSON(this.getSaveEntity());
                }
                catch (e) {
                    return null;
                }
            };
            CustomerDialog.prototype.loadResponse = function (data) {
                _super.prototype.loadResponse.call(this, data);
                this.loadedState = this.getSaveState();
            };
            CustomerDialog.prototype.loadEntity = function (entity) {
                _super.prototype.loadEntity.call(this, entity);
                Serenity.TabsExtensions.setDisabled(this.tabs, 'Orders', this.isNewOrDeleted());
                this.ordersGrid.customerID = entity.CustomerID;
            };
            CustomerDialog.prototype.onSaveSuccess = function (response) {
                _super.prototype.onSaveSuccess.call(this, response);
                Q.reloadLookup('Northwind.Customer');
            };
            CustomerDialog = __decorate([
                Serenity.Decorators.registerClass(),
                Serenity.Decorators.panel()
            ], CustomerDialog);
            return CustomerDialog;
        }(Serenity.EntityDialog));
        Northwind.CustomerDialog = CustomerDialog;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var CustomerEditor = /** @class */ (function (_super) {
            __extends(CustomerEditor, _super);
            function CustomerEditor(hidden) {
                return _super.call(this, hidden) || this;
            }
            CustomerEditor.prototype.getLookupKey = function () {
                return Northwind.CustomerRow.lookupKey;
            };
            CustomerEditor.prototype.getItemText = function (item, lookup) {
                return _super.prototype.getItemText.call(this, item, lookup) + ' [' + item.CustomerID + ']';
            };
            CustomerEditor = __decorate([
                Serenity.Decorators.registerEditor()
            ], CustomerEditor);
            return CustomerEditor;
        }(Serenity.LookupEditorBase));
        Northwind.CustomerEditor = CustomerEditor;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var CustomerGrid = /** @class */ (function (_super) {
            __extends(CustomerGrid, _super);
            function CustomerGrid(container) {
                return _super.call(this, container) || this;
            }
            CustomerGrid.prototype.getColumnsKey = function () { return "Northwind.Customer"; };
            CustomerGrid.prototype.getDialogType = function () { return Northwind.CustomerDialog; };
            CustomerGrid.prototype.getIdProperty = function () { return Northwind.CustomerRow.idProperty; };
            CustomerGrid.prototype.getLocalTextPrefix = function () { return Northwind.CustomerRow.localTextPrefix; };
            CustomerGrid.prototype.getService = function () { return Northwind.CustomerService.baseUrl; };
            CustomerGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    service: 'Northwind/Customer/ListExcel',
                    separator: true
                }));
                buttons.push(Serene3.Common.PdfExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); }
                }));
                return buttons;
            };
            CustomerGrid = __decorate([
                Serenity.Decorators.registerClass(),
                Serenity.Decorators.filterable()
            ], CustomerGrid);
            return CustomerGrid;
        }(Serenity.EntityGrid));
        Northwind.CustomerGrid = CustomerGrid;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var OrderDialog = /** @class */ (function (_super) {
            __extends(OrderDialog, _super);
            function OrderDialog() {
                var _this = _super.call(this) || this;
                _this.form = new Northwind.OrderForm(_this.idPrefix);
                return _this;
            }
            OrderDialog.prototype.getFormKey = function () { return Northwind.OrderForm.formKey; };
            OrderDialog.prototype.getIdProperty = function () { return Northwind.OrderRow.idProperty; };
            OrderDialog.prototype.getLocalTextPrefix = function () { return Northwind.OrderRow.localTextPrefix; };
            OrderDialog.prototype.getNameProperty = function () { return Northwind.OrderRow.nameProperty; };
            OrderDialog.prototype.getService = function () { return Northwind.OrderService.baseUrl; };
            OrderDialog.prototype.getToolbarButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getToolbarButtons.call(this);
                buttons.push(Serene3.Common.ReportHelper.createToolButton({
                    title: 'Invoice',
                    cssClass: 'export-pdf-button',
                    reportKey: 'Northwind.OrderDetail',
                    getParams: function () { return ({
                        OrderID: _this.get_entityId()
                    }); }
                }));
                return buttons;
            };
            OrderDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                this.toolbar.findButton('export-pdf-button').toggle(this.isEditMode());
            };
            OrderDialog = __decorate([
                Serenity.Decorators.registerClass(),
                Serenity.Decorators.panel()
            ], OrderDialog);
            return OrderDialog;
        }(Serenity.EntityDialog));
        Northwind.OrderDialog = OrderDialog;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../Order/OrderDialog.ts" />
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var CustomerOrderDialog = /** @class */ (function (_super) {
            __extends(CustomerOrderDialog, _super);
            function CustomerOrderDialog() {
                return _super.call(this) || this;
            }
            CustomerOrderDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                Serenity.EditorUtils.setReadOnly(this.form.CustomerID, true);
            };
            CustomerOrderDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], CustomerOrderDialog);
            return CustomerOrderDialog;
        }(Northwind.OrderDialog));
        Northwind.CustomerOrderDialog = CustomerOrderDialog;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var OrderGrid = /** @class */ (function (_super) {
            __extends(OrderGrid, _super);
            function OrderGrid(container) {
                return _super.call(this, container) || this;
            }
            OrderGrid.prototype.getColumnsKey = function () { return "Northwind.Order"; };
            OrderGrid.prototype.getDialogType = function () { return Northwind.OrderDialog; };
            OrderGrid.prototype.getIdProperty = function () { return Northwind.OrderRow.idProperty; };
            OrderGrid.prototype.getLocalTextPrefix = function () { return Northwind.OrderRow.localTextPrefix; };
            OrderGrid.prototype.getService = function () { return Northwind.OrderService.baseUrl; };
            OrderGrid.prototype.getQuickFilters = function () {
                var _this = this;
                var filters = _super.prototype.getQuickFilters.call(this);
                filters.push({
                    type: Serenity.LookupEditor,
                    options: {
                        lookupKey: Northwind.ProductRow.lookupKey
                    },
                    field: 'ProductID',
                    title: 'Contains Product in Details',
                    handler: function (w) {
                        _this.view.params.ProductID = Q.toId(w.value);
                    },
                    cssClass: 'hidden-xs'
                });
                return filters;
            };
            OrderGrid.prototype.createQuickFilters = function () {
                _super.prototype.createQuickFilters.call(this);
                this.shippingStateFilter = this.findQuickFilter(Serenity.EnumEditor, "ShippingState" /* ShippingState */);
            };
            OrderGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    service: Northwind.OrderService.baseUrl + '/ListExcel',
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    separator: true
                }));
                buttons.push(Serene3.Common.PdfExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); }
                }));
                return buttons;
            };
            OrderGrid.prototype.getColumns = function () {
                var columns = _super.prototype.getColumns.call(this);
                columns.splice(1, 0, {
                    field: 'Print Invoice',
                    name: '',
                    format: function (ctx) { return '<a class="inline-action print-invoice" title="invoice">' +
                        '<i class="fa fa-file-pdf-o text-red"></i></a>'; },
                    width: 24,
                    minWidth: 24,
                    maxWidth: 24
                });
                return columns;
            };
            OrderGrid.prototype.onClick = function (e, row, cell) {
                _super.prototype.onClick.call(this, e, row, cell);
                if (e.isDefaultPrevented())
                    return;
                var item = this.itemAt(row);
                var target = $(e.target);
                // if user clicks "i" element, e.g. icon
                if (target.parent().hasClass('inline-action'))
                    target = target.parent();
                if (target.hasClass('inline-action')) {
                    e.preventDefault();
                    if (target.hasClass('print-invoice')) {
                        Serene3.Common.ReportHelper.execute({
                            reportKey: 'Northwind.OrderDetail',
                            params: {
                                OrderID: item.OrderID
                            }
                        });
                    }
                }
            };
            OrderGrid.prototype.set_shippingState = function (value) {
                this.shippingStateFilter.value = value == null ? '' : value.toString();
            };
            OrderGrid.prototype.addButtonClick = function () {
                var eq = this.view.params.EqualityFilter;
                this.editItem({
                    CustomerID: eq ? eq.CustomerID : null
                });
            };
            OrderGrid = __decorate([
                Serenity.Decorators.registerClass(),
                Serenity.Decorators.filterable()
            ], OrderGrid);
            return OrderGrid;
        }(Serenity.EntityGrid));
        Northwind.OrderGrid = OrderGrid;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../Order/OrderGrid.ts" />
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var CustomerOrdersGrid = /** @class */ (function (_super) {
            __extends(CustomerOrdersGrid, _super);
            function CustomerOrdersGrid(container) {
                return _super.call(this, container) || this;
            }
            CustomerOrdersGrid.prototype.getDialogType = function () { return Northwind.CustomerOrderDialog; };
            CustomerOrdersGrid.prototype.getColumns = function () {
                return _super.prototype.getColumns.call(this).filter(function (x) { return x.field !== "CustomerCompanyName" /* CustomerCompanyName */; });
            };
            CustomerOrdersGrid.prototype.initEntityDialog = function (itemType, dialog) {
                _super.prototype.initEntityDialog.call(this, itemType, dialog);
                Serenity.SubDialogHelper.cascade(dialog, this.element.closest('.ui-dialog'));
            };
            CustomerOrdersGrid.prototype.addButtonClick = function () {
                this.editItem({ CustomerID: this.customerID });
            };
            CustomerOrdersGrid.prototype.getInitialTitle = function () {
                return null;
            };
            CustomerOrdersGrid.prototype.getGridCanLoad = function () {
                return _super.prototype.getGridCanLoad.call(this) && !!this.customerID;
            };
            Object.defineProperty(CustomerOrdersGrid.prototype, "customerID", {
                get: function () {
                    return this._customerID;
                },
                set: function (value) {
                    if (this._customerID !== value) {
                        this._customerID = value;
                        this.setEquality('CustomerID', value);
                        this.refresh();
                    }
                },
                enumerable: true,
                configurable: true
            });
            CustomerOrdersGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], CustomerOrdersGrid);
            return CustomerOrdersGrid;
        }(Northwind.OrderGrid));
        Northwind.CustomerOrdersGrid = CustomerOrdersGrid;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var EmployeeListFormatter = /** @class */ (function () {
            function EmployeeListFormatter() {
            }
            EmployeeListFormatter.prototype.format = function (ctx) {
                var idList = ctx.value;
                if (!idList || !idList.length)
                    return "";
                var byId = Northwind.EmployeeRow.getLookup().itemById;
                var z;
                return idList.map(function (x) { return ((z = byId[x]) ? z.FullName : x); }).join(", ");
            };
            EmployeeListFormatter = __decorate([
                Serenity.Decorators.registerFormatter()
            ], EmployeeListFormatter);
            return EmployeeListFormatter;
        }());
        Northwind.EmployeeListFormatter = EmployeeListFormatter;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var EmployeeFormatter = /** @class */ (function () {
            function EmployeeFormatter() {
            }
            EmployeeFormatter.prototype.format = function (ctx) {
                var text = Q.htmlEncode(ctx.value);
                if (!this.genderProperty) {
                    return text;
                }
                var gender = ctx.item[this.genderProperty];
                return "<span class='" + ((gender === Northwind.Gender.Female) ?
                    'employee-symbol female' : 'employee-symbol male') +
                    "'>" + text + '</span>';
            };
            EmployeeFormatter.prototype.initializeColumn = function (column) {
                column.referencedFields = column.referencedFields || [];
                if (this.genderProperty)
                    column.referencedFields.push(this.genderProperty);
            };
            __decorate([
                Serenity.Decorators.option()
            ], EmployeeFormatter.prototype, "genderProperty", void 0);
            EmployeeFormatter = __decorate([
                Serenity.Decorators.registerFormatter([Serenity.ISlickFormatter, Serenity.IInitializeColumn])
            ], EmployeeFormatter);
            return EmployeeFormatter;
        }());
        Northwind.EmployeeFormatter = EmployeeFormatter;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var NoteDialog = /** @class */ (function (_super) {
            __extends(NoteDialog, _super);
            function NoteDialog() {
                var _this = _super.call(this) || this;
                _this.textEditor = new Serenity.HtmlNoteContentEditor(_this.byId('Text'));
                return _this;
            }
            NoteDialog.prototype.getTemplate = function () {
                return ("<form id='~_Form' class='s-Form'>" +
                    "<textarea id='~_Text' class='required'></textarea>" +
                    "</form>");
            };
            NoteDialog.prototype.getDialogOptions = function () {
                var _this = this;
                var opt = _super.prototype.getDialogOptions.call(this);
                opt.buttons = [{
                        text: Q.text('Dialogs.OkButton'),
                        click: function () {
                            if (!_this.validateForm()) {
                                return;
                            }
                            _this.okClick && _this.okClick();
                        }
                    }, {
                        text: Q.text('Dialogs.CancelButton'),
                        click: function () { return _this.dialogClose(); }
                    }
                ];
                return opt;
            };
            Object.defineProperty(NoteDialog.prototype, "text", {
                get: function () {
                    return this.textEditor.value;
                },
                set: function (value) {
                    this.textEditor.value = value;
                },
                enumerable: true,
                configurable: true
            });
            NoteDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], NoteDialog);
            return NoteDialog;
        }(Serenity.TemplatedDialog));
        Northwind.NoteDialog = NoteDialog;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var NotesEditor = /** @class */ (function (_super) {
            __extends(NotesEditor, _super);
            function NotesEditor(div) {
                var _this = _super.call(this, div) || this;
                new Serenity.Toolbar(_this.byId('Toolbar'), {
                    buttons: [{
                            title: 'Add Note',
                            cssClass: 'add-button',
                            onClick: function (e) {
                                e.preventDefault();
                                _this.addClick();
                            }
                        }]
                });
                return _this;
            }
            NotesEditor.prototype.getTemplate = function () {
                return "<div><div id='~_Toolbar'></div><ul id='~_NoteList'></ul></div>";
            };
            NotesEditor.prototype.updateContent = function () {
                var _this = this;
                var noteList = this.byId('NoteList');
                noteList.children().remove();
                if (this.items) {
                    var index = 0;
                    for (var t1 = 0; t1 < this.items.length; t1++) {
                        var item = this.items[t1];
                        var li = $('<li/>');
                        $('<div/>').addClass('note-text').html(Q.coalesce(item.Text, '')).appendTo(li);
                        $('<a/>').attr('href', '#').addClass('note-date')
                            .text(item.InsertUserDisplayName + ' - ' +
                            Q.formatDate(item.InsertDate, 'g'))
                            .data('index', index).appendTo(li).click(function (e) { return _this.editClick(e); });
                        $('<a/>').attr('href', '#').addClass('note-delete')
                            .attr('title', 'delete note').data('index', index)
                            .appendTo(li).click(function (e) { return _this.deleteClick(e); });
                        li.appendTo(noteList);
                        index++;
                    }
                }
            };
            NotesEditor.prototype.addClick = function () {
                var _this = this;
                var dlg = new Northwind.NoteDialog();
                dlg.dialogTitle = 'Add Note';
                dlg.okClick = function () {
                    var text = Q.trimToNull(dlg.text);
                    if (text == null) {
                        return;
                    }
                    _this.items = _this.items || [];
                    Q.insert(_this.items, 0, {
                        Text: text,
                        InsertUserDisplayName: Serene3.Authorization.userDefinition.DisplayName,
                        InsertDate: Q.formatISODateTimeUTC(new Date())
                    });
                    _this.updateContent();
                    dlg.dialogClose();
                    _this.set_isDirty(true);
                    _this.onChange && _this.onChange();
                };
                dlg.dialogOpen();
            };
            NotesEditor.prototype.editClick = function (e) {
                var _this = this;
                e.preventDefault();
                var index = $(e.target).data('index');
                var old = this.items[index];
                var dlg = new Northwind.NoteDialog();
                dlg.dialogTitle = 'Edit Note';
                dlg.text = old.Text;
                dlg.okClick = function () {
                    var text = Q.trimToNull(dlg.text);
                    if (!text) {
                        return;
                    }
                    _this.items[index].Text = text;
                    _this.updateContent();
                    dlg.dialogClose();
                    _this.set_isDirty(true);
                    _this.onChange && _this.onChange();
                };
                dlg.dialogOpen();
            };
            NotesEditor.prototype.deleteClick = function (e) {
                var _this = this;
                e.preventDefault();
                var index = $(e.target).data('index');
                Q.confirm('Delete this note?', function () {
                    _this.items.splice(index, 1);
                    _this.updateContent();
                    _this.set_isDirty(true);
                    _this.onChange && _this.onChange();
                });
            };
            Object.defineProperty(NotesEditor.prototype, "value", {
                get: function () {
                    return this.items;
                },
                set: function (value) {
                    this.items = value || [];
                    this.set_isDirty(false);
                    this.updateContent();
                },
                enumerable: true,
                configurable: true
            });
            NotesEditor.prototype.getEditValue = function (prop, target) {
                target[prop.name] = this.value;
            };
            NotesEditor.prototype.setEditValue = function (source, prop) {
                this.value = source[prop.name] || [];
            };
            NotesEditor.prototype.get_isDirty = function () {
                return this.isDirty;
            };
            NotesEditor.prototype.set_isDirty = function (value) {
                this.isDirty = value;
            };
            NotesEditor = __decorate([
                Serenity.Decorators.registerEditor([Serenity.IGetEditValue, Serenity.ISetEditValue]),
                Serenity.Decorators.element("<div/>")
            ], NotesEditor);
            return NotesEditor;
        }(Serenity.TemplatedWidget));
        Northwind.NotesEditor = NotesEditor;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var FreightFormatter = /** @class */ (function () {
            function FreightFormatter() {
            }
            FreightFormatter.prototype.format = function (ctx) {
                return "<span class='freight-symbol'>" + Q.htmlEncode(ctx.value) + '</span>';
            };
            FreightFormatter = __decorate([
                Serenity.Decorators.registerFormatter()
            ], FreightFormatter);
            return FreightFormatter;
        }());
        Northwind.FreightFormatter = FreightFormatter;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var OrderDetailDialog = /** @class */ (function (_super) {
            __extends(OrderDetailDialog, _super);
            function OrderDetailDialog() {
                var _this = _super.call(this) || this;
                _this.form = new Northwind.OrderDetailForm(_this.idPrefix);
                _this.form.ProductID.changeSelect2(function (e) {
                    var productID = Q.toId(_this.form.ProductID.value);
                    if (productID != null) {
                        _this.form.UnitPrice.value = Northwind.ProductRow.getLookup().itemById[productID].UnitPrice;
                    }
                });
                _this.form.Discount.addValidationRule(_this.uniqueName, function (e) {
                    var price = _this.form.UnitPrice.value;
                    var quantity = _this.form.Quantity.value;
                    var discount = _this.form.Discount.value;
                    if (price != null && quantity != null && discount != null &&
                        discount > 0 && discount >= price * quantity) {
                        return "Discount can't be higher than total price!";
                    }
                });
                return _this;
            }
            OrderDetailDialog.prototype.getFormKey = function () { return Northwind.OrderDetailForm.formKey; };
            OrderDetailDialog.prototype.getLocalTextPrefix = function () { return Northwind.OrderDetailRow.localTextPrefix; };
            OrderDetailDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], OrderDetailDialog);
            return OrderDetailDialog;
        }(Serene3.Common.GridEditorDialog));
        Northwind.OrderDetailDialog = OrderDetailDialog;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var OrderDetailsEditor = /** @class */ (function (_super) {
            __extends(OrderDetailsEditor, _super);
            function OrderDetailsEditor(container) {
                return _super.call(this, container) || this;
            }
            OrderDetailsEditor.prototype.getColumnsKey = function () { return "Northwind.OrderDetail"; };
            OrderDetailsEditor.prototype.getDialogType = function () { return Northwind.OrderDetailDialog; };
            OrderDetailsEditor.prototype.getLocalTextPrefix = function () { return Northwind.OrderDetailRow.localTextPrefix; };
            OrderDetailsEditor.prototype.validateEntity = function (row, id) {
                row.ProductID = Q.toId(row.ProductID);
                var sameProduct = Q.tryFirst(this.view.getItems(), function (x) { return x.ProductID === row.ProductID; });
                if (sameProduct && this.id(sameProduct) !== id) {
                    Q.alert('This product is already in order details!');
                    return false;
                }
                row.ProductName = Northwind.ProductRow.getLookup().itemById[row.ProductID].ProductName;
                row.LineTotal = (row.Quantity || 0) * (row.UnitPrice || 0) - (row.Discount || 0);
                return true;
            };
            OrderDetailsEditor = __decorate([
                Serenity.Decorators.registerClass()
            ], OrderDetailsEditor);
            return OrderDetailsEditor;
        }(Serene3.Common.GridEditorBase));
        Northwind.OrderDetailsEditor = OrderDetailsEditor;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var ProductDialog = /** @class */ (function (_super) {
            __extends(ProductDialog, _super);
            function ProductDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new Northwind.ProductForm(_this.idPrefix);
                return _this;
            }
            ProductDialog.prototype.getFormKey = function () { return Northwind.ProductForm.formKey; };
            ProductDialog.prototype.getIdProperty = function () { return Northwind.ProductRow.idProperty; };
            ProductDialog.prototype.getLocalTextPrefix = function () { return Northwind.ProductRow.localTextPrefix; };
            ProductDialog.prototype.getNameProperty = function () { return Northwind.ProductRow.nameProperty; };
            ProductDialog.prototype.getService = function () { return Northwind.ProductService.baseUrl; };
            ProductDialog = __decorate([
                Serenity.Decorators.registerClass(),
                Serenity.Decorators.maximizable()
            ], ProductDialog);
            return ProductDialog;
        }(Serenity.EntityDialog));
        Northwind.ProductDialog = ProductDialog;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var ProductGrid = /** @class */ (function (_super) {
            __extends(ProductGrid, _super);
            /// private pendingChanges: Q.Dictionary<any> = {};
            function ProductGrid(container) {
                return _super.call(this, container) || this;
                // this.slickContainer.on('change', '.edit:input', (e) => this.inputsChange(e));
            }
            ProductGrid.prototype.getColumnsKey = function () { return "Northwind.Product"; };
            ProductGrid.prototype.getDialogType = function () { return Northwind.ProductDialog; };
            ProductGrid.prototype.getIdProperty = function () { return Northwind.ProductRow.idProperty; };
            ProductGrid.prototype.getLocalTextPrefix = function () { return Northwind.ProductRow.localTextPrefix; };
            ProductGrid.prototype.getService = function () { return Northwind.ProductService.baseUrl; };
            ProductGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    service: Northwind.ProductService.baseUrl + '/ListExcel',
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    separator: true
                }));
                buttons.push(Serene3.Common.PdfExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    reportTitle: 'Product List',
                    columnTitles: {
                        'Discontinued': 'Dis.',
                    },
                    tableOptions: {
                        columnStyles: {
                            ProductID: {
                                columnWidth: 25,
                                halign: 'right'
                            },
                            Discountinued: {
                                columnWidth: 25
                            }
                        }
                    }
                }));
                buttons.push({
                    title: 'Save Changes',
                    cssClass: 'apply-changes-button disabled',
                    onClick: function (e) { return _this.saveClick(); },
                    separator: true
                });
                return buttons;
            };
            ProductGrid.prototype.onViewProcessData = function (response) {
                this.pendingChanges = {};
                this.setSaveButtonState();
                return _super.prototype.onViewProcessData.call(this, response);
            };
            // PLEASE NOTE! Inline editing in grids is not something Serenity supports nor recommends.
            // SlickGrid has some set of limitations, UI is very hard to use on some devices like mobile, 
            // custom widgets and validations are not possible, and as a bonus the code can become a mess.
            // 
            // This was just a sample how-to after much requests, and is not supported. 
            // This is all we can offer, please don't ask us to Guide you...
            /**
             * It would be nice if we could use autonumeric, Serenity editors etc. here, to control input validation,
             * but it's not supported by SlickGrid as we are only allowed to return a string, and should attach
             * no event handlers to rendered cell contents
             */
            ProductGrid.prototype.numericInputFormatter = function (ctx) {
                var klass = 'edit numeric';
                var item = ctx.item;
                var pending = this.pendingChanges[item.ProductID];
                if (pending && pending[ctx.column.field] !== undefined) {
                    klass += ' dirty';
                }
                var value = this.getEffectiveValue(item, ctx.column.field);
                return "<input type='text' class='" + klass +
                    "' data-field='" + ctx.column.field +
                    "' value='" + Q.formatNumber(value, '0.##') + "'/>";
            };
            ProductGrid.prototype.stringInputFormatter = function (ctx) {
                var klass = 'edit string';
                var item = ctx.item;
                var pending = this.pendingChanges[item.ProductID];
                var column = ctx.column;
                if (pending && pending[column.field] !== undefined) {
                    klass += ' dirty';
                }
                var value = this.getEffectiveValue(item, column.field);
                return "<input type='text' class='" + klass +
                    "' data-field='" + column.field +
                    "' value='" + Q.attrEncode(value) +
                    "' maxlength='" + column.sourceItem.maxLength + "'/>";
            };
            /**
             * Sorry but you cannot use LookupEditor, e.g. Select2 here, only possible is a SELECT element
             */
            ProductGrid.prototype.selectFormatter = function (ctx, idField, lookup) {
                var klass = 'edit';
                var item = ctx.item;
                var pending = this.pendingChanges[item.ProductID];
                var column = ctx.column;
                if (pending && pending[idField] !== undefined) {
                    klass += ' dirty';
                }
                var value = this.getEffectiveValue(item, idField);
                var markup = "<select class='" + klass +
                    "' data-field='" + idField +
                    "' style='width: 100%; max-width: 100%'>";
                for (var _i = 0, _a = lookup.items; _i < _a.length; _i++) {
                    var c = _a[_i];
                    var id = c[lookup.idField];
                    markup += "<option value='" + Q.attrEncode(id) + "'";
                    if (id == value) {
                        markup += " selected";
                    }
                    markup += ">" + Q.htmlEncode(c[lookup.textField]) + "</option>";
                }
                return markup + "</select>";
            };
            ProductGrid.prototype.getEffectiveValue = function (item, field) {
                var pending = this.pendingChanges[item.ProductID];
                if (pending && pending[field] !== undefined) {
                    return pending[field];
                }
                return item[field];
            };
            ProductGrid.prototype.getColumns = function () {
                var _this = this;
                var columns = _super.prototype.getColumns.call(this);
                var num = function (ctx) { return _this.numericInputFormatter(ctx); };
                var str = function (ctx) { return _this.stringInputFormatter(ctx); };
                Q.first(columns, function (x) { return x.field === 'QuantityPerUnit'; }).format = str;
                var category = Q.first(columns, function (x) { return x.field === "CategoryName" /* CategoryName */; });
                category.referencedFields = ["CategoryID" /* CategoryID */];
                category.format = function (ctx) { return _this.selectFormatter(ctx, "CategoryID" /* CategoryID */, Northwind.CategoryRow.getLookup()); };
                var supplier = Q.first(columns, function (x) { return x.field === "SupplierCompanyName" /* SupplierCompanyName */; });
                supplier.referencedFields = ["SupplierID" /* SupplierID */];
                supplier.format = function (ctx) { return _this.selectFormatter(ctx, "SupplierID" /* SupplierID */, Northwind.SupplierRow.getLookup()); };
                Q.first(columns, function (x) { return x.field === "UnitPrice" /* UnitPrice */; }).format = num;
                Q.first(columns, function (x) { return x.field === "UnitsInStock" /* UnitsInStock */; }).format = num;
                Q.first(columns, function (x) { return x.field === "UnitsOnOrder" /* UnitsOnOrder */; }).format = num;
                Q.first(columns, function (x) { return x.field === "ReorderLevel" /* ReorderLevel */; }).format = num;
                return columns;
            };
            ProductGrid.prototype.inputsChange = function (e) {
                var cell = this.slickGrid.getCellFromEvent(e);
                var item = this.itemAt(cell.row);
                var input = $(e.target);
                var field = input.data('field');
                var text = Q.coalesce(Q.trimToNull(input.val()), '0');
                var pending = this.pendingChanges[item.ProductID];
                var effective = this.getEffectiveValue(item, field);
                var oldText;
                if (input.hasClass("numeric"))
                    oldText = Q.formatNumber(effective, '0.##');
                else
                    oldText = effective;
                var value;
                if (field === 'UnitPrice') {
                    value = Q.parseDecimal(text);
                    if (value == null || isNaN(value)) {
                        Q.notifyError(Q.text('Validation.Decimal'), '', null);
                        input.val(oldText);
                        input.focus();
                        return;
                    }
                }
                else if (input.hasClass("numeric")) {
                    var i = Q.parseInteger(text);
                    if (isNaN(i) || i > 32767 || i < 0) {
                        Q.notifyError(Q.text('Validation.Integer'), '', null);
                        input.val(oldText);
                        input.focus();
                        return;
                    }
                    value = i;
                }
                else
                    value = text;
                if (!pending) {
                    this.pendingChanges[item.ProductID] = pending = {};
                }
                pending[field] = value;
                item[field] = value;
                this.view.refresh();
                if (input.hasClass("numeric"))
                    value = Q.formatNumber(value, '0.##');
                input.val(value).addClass('dirty');
                this.setSaveButtonState();
            };
            ProductGrid.prototype.setSaveButtonState = function () {
                this.toolbar.findButton('apply-changes-button').toggleClass('disabled', Object.keys(this.pendingChanges).length === 0);
            };
            ProductGrid.prototype.saveClick = function () {
                if (Object.keys(this.pendingChanges).length === 0) {
                    return;
                }
                // this calls save service for all modified rows, one by one
                // you could write a batch update service
                var keys = Object.keys(this.pendingChanges);
                var current = -1;
                var self = this;
                (function saveNext() {
                    if (++current >= keys.length) {
                        self.refresh();
                        return;
                    }
                    var key = keys[current];
                    var entity = Q.deepClone(self.pendingChanges[key]);
                    entity.ProductID = key;
                    Q.serviceRequest('Northwind/Product/Update', {
                        EntityId: key,
                        Entity: entity
                    }, function (response) {
                        delete self.pendingChanges[key];
                        saveNext();
                    });
                })();
            };
            ProductGrid.prototype.getQuickFilters = function () {
                var flt = _super.prototype.getQuickFilters.call(this);
                var q = Q.parseQueryString();
                if (q["cat"]) {
                    var category = Q.tryFirst(flt, function (x) { return x.field == "CategoryID"; });
                    category.init = function (e) {
                        e.element.getWidget(Serenity.LookupEditor).value = q["cat"];
                    };
                }
                return flt;
            };
            ProductGrid = __decorate([
                Serenity.Decorators.registerClass(),
                Serenity.Decorators.filterable()
            ], ProductGrid);
            return ProductGrid;
        }(Serenity.EntityGrid));
        Northwind.ProductGrid = ProductGrid;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var RegionDialog = /** @class */ (function (_super) {
            __extends(RegionDialog, _super);
            function RegionDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new Northwind.RegionForm(_this.idPrefix);
                return _this;
            }
            RegionDialog.prototype.getFormKey = function () { return Northwind.RegionForm.formKey; };
            RegionDialog.prototype.getIdProperty = function () { return Northwind.RegionRow.idProperty; };
            RegionDialog.prototype.getLocalTextPrefix = function () { return Northwind.RegionRow.localTextPrefix; };
            RegionDialog.prototype.getNameProperty = function () { return Northwind.RegionRow.nameProperty; };
            RegionDialog.prototype.getService = function () { return Northwind.RegionService.baseUrl; };
            RegionDialog.prototype.getLanguages = function () {
                return Serene3.LanguageList.getValue();
            };
            RegionDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], RegionDialog);
            return RegionDialog;
        }(Serenity.EntityDialog));
        Northwind.RegionDialog = RegionDialog;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var RegionGrid = /** @class */ (function (_super) {
            __extends(RegionGrid, _super);
            function RegionGrid(container) {
                return _super.call(this, container) || this;
            }
            RegionGrid.prototype.getColumnsKey = function () { return "Northwind.Region"; };
            RegionGrid.prototype.getDialogType = function () { return Northwind.RegionDialog; };
            RegionGrid.prototype.getIdProperty = function () { return Northwind.RegionRow.idProperty; };
            RegionGrid.prototype.getLocalTextPrefix = function () { return Northwind.RegionRow.localTextPrefix; };
            RegionGrid.prototype.getService = function () { return Northwind.RegionService.baseUrl; };
            RegionGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], RegionGrid);
            return RegionGrid;
        }(Serenity.EntityGrid));
        Northwind.RegionGrid = RegionGrid;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var PhoneEditor = /** @class */ (function (_super) {
            __extends(PhoneEditor, _super);
            function PhoneEditor(input) {
                var _this = _super.call(this, input) || this;
                _this.addValidationRule(_this.uniqueName, function (e) {
                    var value = Q.trimToNull(_this.get_value());
                    if (value == null) {
                        return null;
                    }
                    return PhoneEditor_1.validate(value, _this.multiple);
                });
                input.bind('change', function (e) {
                    if (!Serenity.WX.hasOriginalEvent(e)) {
                        return;
                    }
                    _this.formatValue();
                });
                input.bind('blur', function (e) {
                    if (_this.element.hasClass('valid')) {
                        _this.formatValue();
                    }
                });
                return _this;
            }
            PhoneEditor_1 = PhoneEditor;
            PhoneEditor.prototype.formatValue = function () {
                this.element.val(this.getFormattedValue());
            };
            PhoneEditor.prototype.getFormattedValue = function () {
                var value = this.element.val();
                if (this.multiple) {
                    return PhoneEditor_1.formatMulti(value, PhoneEditor_1.formatPhone);
                }
                return PhoneEditor_1.formatPhone(value);
            };
            PhoneEditor.prototype.get_value = function () {
                return this.getFormattedValue();
            };
            PhoneEditor.prototype.set_value = function (value) {
                this.element.val(value);
            };
            PhoneEditor.validate = function (phone, isMultiple) {
                var valid = (isMultiple ? PhoneEditor_1.isValidMulti(phone, PhoneEditor_1.isValidPhone) : PhoneEditor_1.isValidPhone(phone));
                if (valid) {
                    return null;
                }
                return Q.text((isMultiple ? 'Validation.NorthwindPhoneMultiple' : 'Validation.NorthwindPhone'));
            };
            PhoneEditor.isValidPhone = function (phone) {
                if (Q.isEmptyOrNull(phone)) {
                    return false;
                }
                phone = Q.replaceAll(Q.replaceAll(phone, ' ', ''), '-', '');
                if (phone.length < 10) {
                    return false;
                }
                if (Q.startsWith(phone, '0')) {
                    phone = phone.substring(1);
                }
                if (Q.startsWith(phone, '(') && phone.charAt(4) === ')') {
                    phone = phone.substr(1, 3) + phone.substring(5);
                }
                if (phone.length !== 10) {
                    return false;
                }
                if (Q.startsWith(phone, '0')) {
                    return false;
                }
                for (var i = 0; i < phone.length; i++) {
                    var c = phone.charAt(i);
                    if (c < '0' || c > '9') {
                        return false;
                    }
                }
                return true;
            };
            PhoneEditor.formatPhone = function (phone) {
                if (!PhoneEditor_1.isValidPhone(phone)) {
                    return phone;
                }
                phone = Q.replaceAll(Q.replaceAll(Q.replaceAll(Q.replaceAll(phone, ' ', ''), '-', ''), '(', ''), ')', '');
                if (Q.startsWith(phone, '0')) {
                    phone = phone.substring(1);
                }
                phone = '(' + phone.substr(0, 3) + ') ' + phone.substr(3, 3) + '-' + phone.substr(6, 2) + phone.substr(8, 2);
                return phone;
            };
            PhoneEditor.formatMulti = function (phone, format) {
                var phones = Q.replaceAll(phone, String.fromCharCode(59), String.fromCharCode(44)).split(String.fromCharCode(44));
                var result = '';
                for (var _i = 0, phones_1 = phones; _i < phones_1.length; _i++) {
                    var x = phones_1[_i];
                    var s = Q.trimToNull(x);
                    if (s == null) {
                        continue;
                    }
                    if (result.length > 0) {
                        result += ', ';
                    }
                    result += format(s);
                }
                return result;
            };
            PhoneEditor.isValidMulti = function (phone, check) {
                if (Q.isEmptyOrNull(phone)) {
                    return false;
                }
                var phones = Q.replaceAll(phone, String.fromCharCode(59), String.fromCharCode(44)).split(String.fromCharCode(44));
                var anyValid = false;
                for (var $t1 = 0; $t1 < phones.length; $t1++) {
                    var x = phones[$t1];
                    var s = Q.trimToNull(x);
                    if (s == null) {
                        continue;
                    }
                    if (!check(s)) {
                        return false;
                    }
                    anyValid = true;
                }
                if (!anyValid) {
                    return false;
                }
                return true;
            };
            __decorate([
                Serenity.Decorators.option()
            ], PhoneEditor.prototype, "multiple", void 0);
            PhoneEditor = PhoneEditor_1 = __decorate([
                Serenity.Decorators.registerEditor()
            ], PhoneEditor);
            return PhoneEditor;
            var PhoneEditor_1;
        }(Serenity.StringEditor));
        Northwind.PhoneEditor = PhoneEditor;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var ShipperDialog = /** @class */ (function (_super) {
            __extends(ShipperDialog, _super);
            function ShipperDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new Northwind.ShipperForm(_this.idPrefix);
                return _this;
            }
            ShipperDialog.prototype.getFormKey = function () { return Northwind.ShipperForm.formKey; };
            ShipperDialog.prototype.getIdProperty = function () { return Northwind.ShipperRow.idProperty; };
            ShipperDialog.prototype.getLocalTextPrefix = function () { return Northwind.ShipperRow.localTextPrefix; };
            ShipperDialog.prototype.getNameProperty = function () { return Northwind.ShipperRow.nameProperty; };
            ShipperDialog.prototype.getService = function () { return Northwind.ShipperService.baseUrl; };
            ShipperDialog.prototype.getLanguages = function () {
                return Serene3.LanguageList.getValue();
            };
            ShipperDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], ShipperDialog);
            return ShipperDialog;
        }(Serenity.EntityDialog));
        Northwind.ShipperDialog = ShipperDialog;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var ShipperFormatter = /** @class */ (function () {
            function ShipperFormatter() {
            }
            ShipperFormatter.prototype.format = function (ctx) {
                return "<span class='shipper-symbol shipper-" +
                    Q.replaceAll((ctx.value || '').toString(), ' ', '') +
                    "'>" + Q.htmlEncode(ctx.value) + '</span>';
            };
            ShipperFormatter = __decorate([
                Serenity.Decorators.registerFormatter()
            ], ShipperFormatter);
            return ShipperFormatter;
        }());
        Northwind.ShipperFormatter = ShipperFormatter;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var ShipperGrid = /** @class */ (function (_super) {
            __extends(ShipperGrid, _super);
            function ShipperGrid(container) {
                return _super.call(this, container) || this;
            }
            ShipperGrid.prototype.getColumnsKey = function () { return "Northwind.Shipper"; };
            ShipperGrid.prototype.getDialogType = function () { return Northwind.ShipperDialog; };
            ShipperGrid.prototype.getIdProperty = function () { return Northwind.ShipperRow.idProperty; };
            ShipperGrid.prototype.getLocalTextPrefix = function () { return Northwind.ShipperRow.localTextPrefix; };
            ShipperGrid.prototype.getService = function () { return Northwind.ShipperService.baseUrl; };
            ShipperGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], ShipperGrid);
            return ShipperGrid;
        }(Serenity.EntityGrid));
        Northwind.ShipperGrid = ShipperGrid;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var SupplierDialog = /** @class */ (function (_super) {
            __extends(SupplierDialog, _super);
            function SupplierDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new Northwind.SupplierForm(_this.idPrefix);
                return _this;
            }
            SupplierDialog.prototype.getFormKey = function () { return Northwind.SupplierForm.formKey; };
            SupplierDialog.prototype.getIdProperty = function () { return Northwind.SupplierRow.idProperty; };
            SupplierDialog.prototype.getLocalTextPrefix = function () { return Northwind.SupplierRow.localTextPrefix; };
            SupplierDialog.prototype.getNameProperty = function () { return Northwind.SupplierRow.nameProperty; };
            SupplierDialog.prototype.getService = function () { return Northwind.SupplierService.baseUrl; };
            SupplierDialog.prototype.getLanguages = function () {
                return Serene3.LanguageList.getValue();
            };
            SupplierDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], SupplierDialog);
            return SupplierDialog;
        }(Serenity.EntityDialog));
        Northwind.SupplierDialog = SupplierDialog;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var SupplierGrid = /** @class */ (function (_super) {
            __extends(SupplierGrid, _super);
            function SupplierGrid(container) {
                return _super.call(this, container) || this;
            }
            SupplierGrid.prototype.getColumnsKey = function () { return "Northwind.Supplier"; };
            SupplierGrid.prototype.getDialogType = function () { return Northwind.SupplierDialog; };
            SupplierGrid.prototype.getIdProperty = function () { return Northwind.SupplierRow.idProperty; };
            SupplierGrid.prototype.getLocalTextPrefix = function () { return Northwind.SupplierRow.localTextPrefix; };
            SupplierGrid.prototype.getService = function () { return Northwind.SupplierService.baseUrl; };
            SupplierGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], SupplierGrid);
            return SupplierGrid;
        }(Serenity.EntityGrid));
        Northwind.SupplierGrid = SupplierGrid;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var TerritoryDialog = /** @class */ (function (_super) {
            __extends(TerritoryDialog, _super);
            function TerritoryDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new Northwind.TerritoryForm(_this.idPrefix);
                return _this;
            }
            TerritoryDialog.prototype.getFormKey = function () { return Northwind.TerritoryForm.formKey; };
            TerritoryDialog.prototype.getIdProperty = function () { return Northwind.TerritoryRow.idProperty; };
            TerritoryDialog.prototype.getLocalTextPrefix = function () { return Northwind.TerritoryRow.localTextPrefix; };
            TerritoryDialog.prototype.getNameProperty = function () { return Northwind.TerritoryRow.nameProperty; };
            TerritoryDialog.prototype.getService = function () { return Northwind.TerritoryService.baseUrl; };
            TerritoryDialog.prototype.getLanguages = function () {
                return Serene3.LanguageList.getValue();
            };
            TerritoryDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], TerritoryDialog);
            return TerritoryDialog;
        }(Serenity.EntityDialog));
        Northwind.TerritoryDialog = TerritoryDialog;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Northwind;
    (function (Northwind) {
        var TerritoryGrid = /** @class */ (function (_super) {
            __extends(TerritoryGrid, _super);
            function TerritoryGrid(container) {
                return _super.call(this, container) || this;
            }
            TerritoryGrid.prototype.getColumnsKey = function () { return "Northwind.Territory"; };
            TerritoryGrid.prototype.getDialogType = function () { return Northwind.TerritoryDialog; };
            TerritoryGrid.prototype.getIdProperty = function () { return Northwind.TerritoryRow.idProperty; };
            TerritoryGrid.prototype.getLocalTextPrefix = function () { return Northwind.TerritoryRow.localTextPrefix; };
            TerritoryGrid.prototype.getService = function () { return Northwind.TerritoryService.baseUrl; };
            TerritoryGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], TerritoryGrid);
            return TerritoryGrid;
        }(Serenity.EntityGrid));
        Northwind.TerritoryGrid = TerritoryGrid;
    })(Northwind = Serene3.Northwind || (Serene3.Northwind = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VTrangThaiBoBtpGrid = /** @class */ (function (_super) {
            __extends(VTrangThaiBoBtpGrid, _super);
            function VTrangThaiBoBtpGrid(container) {
                return _super.call(this, container) || this;
            }
            VTrangThaiBoBtpGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.VTrangThaiBoBtp'; };
            VTrangThaiBoBtpGrid.prototype.getDialogType = function () { return SpringPrintingConnection.VTrangThaiBoBtpDialog; };
            VTrangThaiBoBtpGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.VTrangThaiBoBtpRow.idProperty; };
            VTrangThaiBoBtpGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.VTrangThaiBoBtpRow.localTextPrefix; };
            VTrangThaiBoBtpGrid.prototype.getService = function () { return SpringPrintingConnection.VTrangThaiBoBtpService.baseUrl; };
            VTrangThaiBoBtpGrid.prototype.getSlickOptions = function () {
                var opt = _super.prototype.getSlickOptions.call(this);
                opt.showFooterRow = true;
                return opt;
            };
            VTrangThaiBoBtpGrid.prototype.usePager = function () {
                return false;
            };
            VTrangThaiBoBtpGrid.prototype.getButtons = function () {
                var _this = this;
                return [{
                        title: 'Group By Category',
                        cssClass: 'expand-all-button',
                        onClick: function () { return _this.view.setGrouping([{
                                getter: 'MaHd'
                            }]); }
                    },
                    {
                        title: 'No Grouping',
                        cssClass: 'collapse-all-button',
                        onClick: function () { return _this.view.setGrouping([]); }
                    }];
            };
            VTrangThaiBoBtpGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], VTrangThaiBoBtpGrid);
            return VTrangThaiBoBtpGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.VTrangThaiBoBtpGrid = VTrangThaiBoBtpGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../vtrangthaibobtp/vtrangthaibobtpgrid.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var GroupingInGrid = /** @class */ (function (_super) {
            __extends(GroupingInGrid, _super);
            function GroupingInGrid(container) {
                return _super.call(this, container) || this;
            }
            GroupingInGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], GroupingInGrid);
            return GroupingInGrid;
        }(Serene3.SpringPrintingConnection.VTrangThaiBoBtpGrid));
        SpringPrintingConnection.GroupingInGrid = GroupingInGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblBanThanhPhamDialog = /** @class */ (function (_super) {
            __extends(TblBanThanhPhamDialog, _super);
            function TblBanThanhPhamDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblBanThanhPhamForm(_this.idPrefix);
                return _this;
            }
            TblBanThanhPhamDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblBanThanhPhamForm.formKey; };
            TblBanThanhPhamDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblBanThanhPhamRow.idProperty; };
            TblBanThanhPhamDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblBanThanhPhamRow.localTextPrefix; };
            TblBanThanhPhamDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.TblBanThanhPhamRow.nameProperty; };
            TblBanThanhPhamDialog.prototype.getService = function () { return SpringPrintingConnection.TblBanThanhPhamService.baseUrl; };
            TblBanThanhPhamDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], TblBanThanhPhamDialog);
            return TblBanThanhPhamDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblBanThanhPhamDialog = TblBanThanhPhamDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblBanThanhPhamGrid = /** @class */ (function (_super) {
            __extends(TblBanThanhPhamGrid, _super);
            function TblBanThanhPhamGrid(container) {
                return _super.call(this, container) || this;
            }
            TblBanThanhPhamGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblBanThanhPham'; };
            TblBanThanhPhamGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblBanThanhPhamDialog; };
            TblBanThanhPhamGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblBanThanhPhamRow.idProperty; };
            TblBanThanhPhamGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblBanThanhPhamRow.localTextPrefix; };
            TblBanThanhPhamGrid.prototype.getService = function () { return SpringPrintingConnection.TblBanThanhPhamService.baseUrl; };
            TblBanThanhPhamGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblBanThanhPhamGrid);
            return TblBanThanhPhamGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblBanThanhPhamGrid = TblBanThanhPhamGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblBoBtpDialog = /** @class */ (function (_super) {
            __extends(TblBoBtpDialog, _super);
            function TblBoBtpDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblBoBtpForm(_this.idPrefix);
                return _this;
            }
            TblBoBtpDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblBoBtpForm.formKey; };
            TblBoBtpDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblBoBtpRow.idProperty; };
            TblBoBtpDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblBoBtpRow.localTextPrefix; };
            TblBoBtpDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.TblBoBtpRow.nameProperty; };
            TblBoBtpDialog.prototype.getService = function () { return SpringPrintingConnection.TblBoBtpService.baseUrl; };
            TblBoBtpDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                if (!(Serene3.Authorization.hasPermission("Serene3:TblBoBtp:Modify"))) {
                    this.deleteButton.hide();
                    this.saveAndCloseButton.hide();
                    this.applyChangesButton.hide();
                    Serenity.EditorUtils.setReadonly(this.element.find('.editor'), true);
                }
                if (!(Serene3.Authorization.hasPermission("Serene3:TblBoBtp:Delete"))) {
                    this.deleteButton.hide();
                }
            };
            TblBoBtpDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], TblBoBtpDialog);
            return TblBoBtpDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblBoBtpDialog = TblBoBtpDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblBoBtpEditDialog = /** @class */ (function (_super) {
            __extends(TblBoBtpEditDialog, _super);
            function TblBoBtpEditDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblBoBtpForm(_this.idPrefix);
                return _this;
            }
            TblBoBtpEditDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblBoBtpForm.formKey; };
            TblBoBtpEditDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblBoBtpRow.idProperty; };
            TblBoBtpEditDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblBoBtpRow.localTextPrefix; };
            TblBoBtpEditDialog.prototype.getService = function () { return SpringPrintingConnection.TblBoBtpService.baseUrl; };
            TblBoBtpEditDialog = __decorate([
                Serenity.Decorators.registerClass()
                //export class TblBoBtpDialog extends Serenity.EntityDialog<TblBoBtpRow, any> {
            ], TblBoBtpEditDialog);
            return TblBoBtpEditDialog;
        }(Serene3.Common.GridEditorDialog));
        SpringPrintingConnection.TblBoBtpEditDialog = TblBoBtpEditDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblBoBtpEditor = /** @class */ (function (_super) {
            __extends(TblBoBtpEditor, _super);
            function TblBoBtpEditor(container) {
                return _super.call(this, container) || this;
            }
            TblBoBtpEditor.prototype.getColumnsKey = function () { return "SpringPrintingConnection.TblBoBtp"; };
            TblBoBtpEditor.prototype.getDialogType = function () { return SpringPrintingConnection.TblBoBtpEditDialog; };
            TblBoBtpEditor.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblBoBtpRow.localTextPrefix; };
            TblBoBtpEditor.prototype.validateEntity = function (row, id) {
                //row.MaLo = Q.toId(row.MaLo);
                //var sameProduct = Q.tryFirst(this.view.getItems(), x => x.MaLo === row.MaLo);
                //if (sameProduct && this.id(sameProduct) !== id) {
                //    Q.alert('This product is already in order details!');
                //    return false;
                //}
                return true;
            };
            TblBoBtpEditor = __decorate([
                Serenity.Decorators.registerClass()
            ], TblBoBtpEditor);
            return TblBoBtpEditor;
        }(Serene3.Common.GridEditorBase));
        SpringPrintingConnection.TblBoBtpEditor = TblBoBtpEditor;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblBoBtpGrid = /** @class */ (function (_super) {
            __extends(TblBoBtpGrid, _super);
            function TblBoBtpGrid(container) {
                return _super.call(this, container) || this;
            }
            TblBoBtpGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblBoBtp'; };
            TblBoBtpGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblBoBtpDialog; };
            TblBoBtpGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblBoBtpRow.idProperty; };
            TblBoBtpGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblBoBtpRow.localTextPrefix; };
            TblBoBtpGrid.prototype.getService = function () { return SpringPrintingConnection.TblBoBtpService.baseUrl; };
            TblBoBtpGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    service: SpringPrintingConnection.TblBoBtpService.baseUrl + '/ListExcel',
                    separator: true
                }));
                if (!(Serene3.Authorization.hasPermission("Serene3:TblBoBtp:Modify"))) {
                    buttons.splice(Q.indexOf(buttons, function (x) { return x.cssClass == "add-button"; }), 1);
                }
                return buttons;
            };
            TblBoBtpGrid.prototype.createToolbarExtensions = function () {
                var _this = this;
                _super.prototype.createToolbarExtensions.call(this);
                //this.country = Serenity.Widget.create({
                //    type: Serenity.StringEditor,
                //    element: el => el.appendTo(this.toolbar.element).attr('placeholder', '--- ' +
                //        Q.text('Ma Lo') + ' ---'
                //    ).css("width", "100px")
                //});
                this.month = Serenity.Widget.create({
                    type: Serenity.StringEditor,
                    options: {},
                    element: function (e) { return e.insertAfter(_this.toolbar.element).attr('placeholder', '-Scan Card-').css("width", "150px"); },
                    init: function (w) { return w.change(function (x) {
                        if (!(Serene3.Authorization.hasPermission("Serene3:TblBoBtp:Modify"))) {
                            alert(Q.text("Controls.NotPermission"));
                            return;
                        }
                        //alert(this.sMaLo111);
                        if (_this.sMaLo111 != "" && _this.sMaLo111 != undefined) {
                            //  alert("kkkkk");
                            SpringPrintingConnection.TblBoBtpService.GetData({
                                Note: w.value.toString(),
                                MaLo: _this.sMaLo111 //this.country.value.toString()
                            }, function (response) {
                                //this.form.Days.value = parseFloat(response.toString());
                                //this.country.value = response.toString();
                                _this.sMaLo = response.toString();
                                _this.refresh();
                            });
                        }
                        else {
                            //alert("kkkkk");
                            SpringPrintingConnection.TblBoBtpService.GetData({
                                Note: w.value.toString(),
                                MaLo: _this.sMaLo //this.country.value.toString()
                            }, function (response) {
                                //this.form.Days.value = parseFloat(response.toString());
                                //this.country.value = response.toString();
                                _this.sMaLo = response.toString();
                                _this.sMaLo111 = _this.sMaLo;
                                _this.refresh();
                            });
                        }
                        // this.refresh();
                        w.value = null;
                        // this.city.get_items[0].va = this.country.cascadeValue[0];
                        return;
                    }); }
                });
            };
            TblBoBtpGrid.prototype.getQuickFilters = function () {
                var _this = this;
                var filters = _super.prototype.getQuickFilters.call(this);
                var fld = Serene3.SpringPrintingConnection.TblBoBtpRow.Fields;
                //alert(this.sMaLo);
                //if (this.sMaLo111 != undefined)
                //    Q.first(filters, x => x.field == fld.MaLo).init = w => {
                //        (w as Serenity.IntegerEditor).value = parseInt(this.sMaLo111);// this.sMaLo;
                var MaloFilter = Q.first(filters, function (x) { return x.field == "MaLo" /* MaLo */; });
                MaloFilter.handler = function (h) {
                    if ((h.value == "" || h.value == null) && _this.sMaLo != undefined) {
                        h.request.EqualityFilter["MaLo" /* MaLo */] = _this.sMaLo; // h.value;
                    }
                    else {
                        h.request.EqualityFilter["MaLo" /* MaLo */] = h.value; // h.value;
                    }
                    if (h.active) {
                        _this.sMaLo = undefined;
                        h.request.EqualityFilter["MaLo" /* MaLo */] = h.value; // h.value;
                        _this.sMaLo111 = h.value;
                    }
                    else {
                        if (_this.sMaLo == undefined) {
                            h.request.EqualityFilter["MaLo" /* MaLo */] = null;
                            _this.sMaLo111 = "";
                        }
                    }
                    _this.sMaLo111 = h.value;
                    // var values = (h.widget as Serenity.LookupEditor).values;
                    //alert( h.value);
                    if (_this.sMaLo != undefined && (_this.sMaLo111 == "" || _this.sMaLo111 == null)) {
                        _this.sMaLo111 = _this.sMaLo;
                    }
                    // alert(this.sMaLo111);
                    //alert(this.sMaLo111);
                };
                return filters;
            };
            TblBoBtpGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblBoBtpGrid);
            return TblBoBtpGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblBoBtpGrid = TblBoBtpGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblBo_BTPDialog = /** @class */ (function (_super) {
            __extends(TblBo_BTPDialog, _super);
            function TblBo_BTPDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                // protected getService() { return TblBo_BTPService.baseUrl; }
                _this.form = new SpringPrintingConnection.TblBo_BTPForm(_this.idPrefix);
                return _this;
            }
            TblBo_BTPDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblBo_BTPForm.formKey; };
            // protected getIdProperty() { return TblBo_BTPRow.idProperty; }
            TblBo_BTPDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblBo_BTPRow.localTextPrefix; };
            TblBo_BTPDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.TblBo_BTPRow.nameProperty; };
            TblBo_BTPDialog = __decorate([
                Serenity.Decorators.registerClass()
                //export class TblBo_BTPDialog extends Serenity.EntityDialog<TblBo_BTPRow, any> {
            ], TblBo_BTPDialog);
            return TblBo_BTPDialog;
        }(Serene3.Common.GridEditorDialog));
        SpringPrintingConnection.TblBo_BTPDialog = TblBo_BTPDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblBo_BTPEditor = /** @class */ (function (_super) {
            __extends(TblBo_BTPEditor, _super);
            function TblBo_BTPEditor(container) {
                return _super.call(this, container) || this;
            }
            TblBo_BTPEditor.prototype.getColumnsKey = function () { return "SpringPrintingConnection.TblBo_BTP"; };
            TblBo_BTPEditor.prototype.getDialogType = function () { return SpringPrintingConnection.TblBo_BTPDialog; };
            TblBo_BTPEditor.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblBo_BTPRow.localTextPrefix; };
            TblBo_BTPEditor.prototype.validateEntity = function (row, id) {
                //row.MaLo = Q.toId(row.MaLo);
                //var sameProduct = Q.tryFirst(this.view.getItems(), x => x.MaLo === row.MaLo);
                //if (sameProduct && this.id(sameProduct) !== id) {
                //    Q.alert('This product is already in order details!');
                //    return false;
                //}
                //alert(TblRefMauRow.getLookup().itemById[row.MaMau].TenMau);
                //alert(row.MaBtp.value);
                var MaBtp = Q.toId(row.MaBtp);
                if (MaBtp != null) {
                    row.MaBtpMotaBtp = SpringPrintingConnection.TblBanThanhPhamRow.getLookup().itemById[row.MaBtp].MotaBtp;
                }
                else {
                    row.MaBtpMotaBtp = null;
                }
                var MaMau = Q.toId(row.MaMau);
                if (MaMau != null) {
                    row.MaMauTenMau = SpringPrintingConnection.TblRefMauRow.getLookup().itemById[row.MaMau].TenMau;
                }
                else {
                    row.MaMauTenMau = null;
                }
                var MaSize = Q.toId(row.MaSize);
                if (MaSize != null) {
                    row.MaSizeTenSize = SpringPrintingConnection.TblRefSizeRow.getLookup().itemById[row.MaSize].TenSize;
                }
                else {
                    row.MaSizeTenSize = null;
                }
                var MaStyle = Q.toId(row.MaStyle);
                if (MaStyle != null) {
                    row.MaStyleTenStyle = SpringPrintingConnection.TblRefStyleRow.getLookup().itemById[row.MaStyle].TenStyle;
                }
                else {
                    row.MaStyleTenStyle = null;
                }
                return true;
            };
            TblBo_BTPEditor = __decorate([
                Serenity.Decorators.registerClass()
            ], TblBo_BTPEditor);
            return TblBo_BTPEditor;
        }(Serene3.Common.GridEditorBase));
        SpringPrintingConnection.TblBo_BTPEditor = TblBo_BTPEditor;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblBo_BTPGrid = /** @class */ (function (_super) {
            __extends(TblBo_BTPGrid, _super);
            function TblBo_BTPGrid(container) {
                return _super.call(this, container) || this;
            }
            TblBo_BTPGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblBo_BTP'; };
            TblBo_BTPGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblBo_BTPDialog; };
            TblBo_BTPGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblBo_BTPRow.idProperty; };
            TblBo_BTPGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblBo_BTPRow.localTextPrefix; };
            TblBo_BTPGrid.prototype.getService = function () { return SpringPrintingConnection.TblBo_BTPService.baseUrl; };
            TblBo_BTPGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblBo_BTPGrid);
            return TblBo_BTPGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblBo_BTPGrid = TblBo_BTPGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblFeCardInfoDialog = /** @class */ (function (_super) {
            __extends(TblFeCardInfoDialog, _super);
            function TblFeCardInfoDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblFeCardInfoForm(_this.idPrefix);
                return _this;
            }
            TblFeCardInfoDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblFeCardInfoForm.formKey; };
            TblFeCardInfoDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblFeCardInfoRow.idProperty; };
            TblFeCardInfoDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblFeCardInfoRow.localTextPrefix; };
            TblFeCardInfoDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.TblFeCardInfoRow.nameProperty; };
            TblFeCardInfoDialog.prototype.getService = function () { return SpringPrintingConnection.TblFeCardInfoService.baseUrl; };
            TblFeCardInfoDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                this.deleteButton.hide();
                this.saveAndCloseButton.hide();
                this.applyChangesButton.hide();
            };
            TblFeCardInfoDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], TblFeCardInfoDialog);
            return TblFeCardInfoDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblFeCardInfoDialog = TblFeCardInfoDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblFeCardInfoGrid = /** @class */ (function (_super) {
            __extends(TblFeCardInfoGrid, _super);
            function TblFeCardInfoGrid(container) {
                return _super.call(this, container) || this;
            }
            TblFeCardInfoGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblFeCardInfo'; };
            TblFeCardInfoGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblFeCardInfoDialog; };
            TblFeCardInfoGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblFeCardInfoRow.idProperty; };
            TblFeCardInfoGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblFeCardInfoRow.localTextPrefix; };
            TblFeCardInfoGrid.prototype.getService = function () { return SpringPrintingConnection.TblFeCardInfoService.baseUrl; };
            TblFeCardInfoGrid.prototype.getButtons = function () {
                var buttons = _super.prototype.getButtons.call(this);
                buttons.splice(Q.indexOf(buttons, function (x) { return x.cssClass == "add-button"; }), 1);
                return buttons;
            };
            TblFeCardInfoGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblFeCardInfoGrid);
            return TblFeCardInfoGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblFeCardInfoGrid = TblFeCardInfoGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblFeStockOutInfoDialog = /** @class */ (function (_super) {
            __extends(TblFeStockOutInfoDialog, _super);
            function TblFeStockOutInfoDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblFeStockOutInfoForm(_this.idPrefix);
                return _this;
            }
            TblFeStockOutInfoDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblFeStockOutInfoForm.formKey; };
            TblFeStockOutInfoDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblFeStockOutInfoRow.idProperty; };
            TblFeStockOutInfoDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblFeStockOutInfoRow.localTextPrefix; };
            TblFeStockOutInfoDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.TblFeStockOutInfoRow.nameProperty; };
            TblFeStockOutInfoDialog.prototype.getService = function () { return SpringPrintingConnection.TblFeStockOutInfoService.baseUrl; };
            TblFeStockOutInfoDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                this.deleteButton.hide();
                this.saveAndCloseButton.hide();
                this.applyChangesButton.hide();
            };
            TblFeStockOutInfoDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], TblFeStockOutInfoDialog);
            return TblFeStockOutInfoDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblFeStockOutInfoDialog = TblFeStockOutInfoDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblFeStockOutInfoGrid = /** @class */ (function (_super) {
            __extends(TblFeStockOutInfoGrid, _super);
            function TblFeStockOutInfoGrid(container) {
                return _super.call(this, container) || this;
            }
            TblFeStockOutInfoGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblFeStockOutInfo'; };
            TblFeStockOutInfoGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblFeStockOutInfoDialog; };
            TblFeStockOutInfoGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblFeStockOutInfoRow.idProperty; };
            TblFeStockOutInfoGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblFeStockOutInfoRow.localTextPrefix; };
            TblFeStockOutInfoGrid.prototype.getService = function () { return SpringPrintingConnection.TblFeStockOutInfoService.baseUrl; };
            TblFeStockOutInfoGrid.prototype.getButtons = function () {
                var buttons = _super.prototype.getButtons.call(this);
                buttons.splice(Q.indexOf(buttons, function (x) { return x.cssClass == "add-button"; }), 1);
                return buttons;
            };
            TblFeStockOutInfoGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblFeStockOutInfoGrid);
            return TblFeStockOutInfoGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblFeStockOutInfoGrid = TblFeStockOutInfoGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDongDialog = /** @class */ (function (_super) {
            __extends(TblHopDongDialog, _super);
            function TblHopDongDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblHopDongForm(_this.idPrefix);
                return _this;
            }
            TblHopDongDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblHopDongForm.formKey; };
            TblHopDongDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblHopDongRow.idProperty; };
            TblHopDongDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblHopDongRow.localTextPrefix; };
            TblHopDongDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.TblHopDongRow.nameProperty; };
            TblHopDongDialog.prototype.getService = function () { return SpringPrintingConnection.TblHopDongService.baseUrl; };
            TblHopDongDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                if (!(Serene3.Authorization.hasPermission("Serene3:TblHopDong:Modify"))) {
                    this.deleteButton.hide();
                    this.saveAndCloseButton.hide();
                    this.applyChangesButton.hide();
                    Serenity.EditorUtils.setReadonly(this.element.find('.editor'), true);
                }
                if (!(Serene3.Authorization.hasPermission("Serene3:TblHopDong:Delete"))) {
                    this.deleteButton.hide();
                }
            };
            TblHopDongDialog = __decorate([
                Serenity.Decorators.registerClass(),
                Serenity.Decorators.panel()
            ], TblHopDongDialog);
            return TblHopDongDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblHopDongDialog = TblHopDongDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDongGrid = /** @class */ (function (_super) {
            __extends(TblHopDongGrid, _super);
            function TblHopDongGrid(container) {
                return _super.call(this, container) || this;
                ////Hide NoiDung column
                //let columns = this.getColumns();
                //columns = columns.filter(f => f.field != 'MaKhTenKh');
                //this.slickGrid.setColumns(columns);
            }
            TblHopDongGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblHopDong'; };
            TblHopDongGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblHopDongDialog; };
            TblHopDongGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblHopDongRow.idProperty; };
            TblHopDongGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblHopDongRow.localTextPrefix; };
            TblHopDongGrid.prototype.getService = function () { return SpringPrintingConnection.TblHopDongService.baseUrl; };
            TblHopDongGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    service: SpringPrintingConnection.TblHopDongService.baseUrl + '/ListExcel',
                    separator: true
                }));
                if (!(Serene3.Authorization.hasPermission("Serene3:TblHopDong:Modify"))) {
                    buttons.splice(Q.indexOf(buttons, function (x) { return x.cssClass == "add-button"; }), 1);
                }
                return buttons;
            };
            TblHopDongGrid = __decorate([
                Serenity.Decorators.registerClass(),
                Serenity.Decorators.filterable()
            ], TblHopDongGrid);
            return TblHopDongGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblHopDongGrid = TblHopDongGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDongChiTietDialog = /** @class */ (function (_super) {
            __extends(TblHopDongChiTietDialog, _super);
            function TblHopDongChiTietDialog() {
                var _this = _super.call(this) || this;
                _this.form = new SpringPrintingConnection.TblHopDongChiTietForm(_this.idPrefix);
                _this.form.SoLuong.changeSelect2(function (e) {
                    _this.form.ThanhTien.value = _this.form.SoLuong.value * _this.form.DonGia.value;
                    //alert("aaa");
                });
                _this.form.DonGia.changeSelect2(function (e) {
                    _this.form.ThanhTien.value = _this.form.SoLuong.value * _this.form.DonGia.value;
                    //alert("bbbb");
                });
                return _this;
            }
            // export class TblHopDongChiTietDialog extends Common.GridEditorDialog<TblHopDongChiTietRow> {
            TblHopDongChiTietDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblHopDongChiTietForm.formKey; };
            TblHopDongChiTietDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblHopDongChiTietRow.idProperty; };
            TblHopDongChiTietDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblHopDongChiTietRow.localTextPrefix; };
            TblHopDongChiTietDialog.prototype.getService = function () { return SpringPrintingConnection.TblHopDongChiTietService.baseUrl; };
            TblHopDongChiTietDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], TblHopDongChiTietDialog);
            return TblHopDongChiTietDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblHopDongChiTietDialog = TblHopDongChiTietDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDongChiTietEditor = /** @class */ (function (_super) {
            __extends(TblHopDongChiTietEditor, _super);
            function TblHopDongChiTietEditor(container) {
                return _super.call(this, container) || this;
            }
            TblHopDongChiTietEditor.prototype.getColumnsKey = function () { return "SpringPrintingConnection.TblHopDongChiTiet"; };
            TblHopDongChiTietEditor.prototype.getDialogType = function () { return SpringPrintingConnection.TblHopDongChiTietDialog; };
            TblHopDongChiTietEditor.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblHopDongChiTietRow.localTextPrefix; };
            //protected getAddButtonCaption() { return "Add";}
            TblHopDongChiTietEditor.prototype.validateEntity = function (row, id) {
                alert("aaaaaa");
                row.KeyId = Q.toId(row.KeyId);
                var sameProduct = Q.tryFirst(this.view.getItems(), function (x) { return x.MaHd = row.MaHd; });
                if (sameProduct && this.id(sameProduct) !== id) {
                    Q.alert('This Contract is already in order details!');
                    return false;
                }
                return true;
            };
            TblHopDongChiTietEditor = __decorate([
                Serenity.Decorators.registerClass()
            ], TblHopDongChiTietEditor);
            return TblHopDongChiTietEditor;
        }(Serene3.Common.GridEditorBase));
        SpringPrintingConnection.TblHopDongChiTietEditor = TblHopDongChiTietEditor;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDongChiTietGrid = /** @class */ (function (_super) {
            __extends(TblHopDongChiTietGrid, _super);
            function TblHopDongChiTietGrid(container) {
                return _super.call(this, container) || this;
            }
            TblHopDongChiTietGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblHopDongChiTiet'; };
            TblHopDongChiTietGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblHopDongChiTietDialog; };
            TblHopDongChiTietGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblHopDongChiTietRow.idProperty; };
            TblHopDongChiTietGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblHopDongChiTietRow.localTextPrefix; };
            TblHopDongChiTietGrid.prototype.getService = function () { return SpringPrintingConnection.TblHopDongChiTietService.baseUrl; };
            TblHopDongChiTietGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblHopDongChiTietGrid);
            return TblHopDongChiTietGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblHopDongChiTietGrid = TblHopDongChiTietGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDongDieuChinhDialog = /** @class */ (function (_super) {
            __extends(TblHopDongDieuChinhDialog, _super);
            function TblHopDongDieuChinhDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblHopDongDieuChinhForm(_this.idPrefix);
                return _this;
            }
            TblHopDongDieuChinhDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblHopDongDieuChinhForm.formKey; };
            TblHopDongDieuChinhDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblHopDongDieuChinhRow.idProperty; };
            TblHopDongDieuChinhDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblHopDongDieuChinhRow.localTextPrefix; };
            TblHopDongDieuChinhDialog.prototype.getService = function () { return SpringPrintingConnection.TblHopDongDieuChinhService.baseUrl; };
            TblHopDongDieuChinhDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], TblHopDongDieuChinhDialog);
            return TblHopDongDieuChinhDialog;
        }(Serene3.Common.GridEditorDialog));
        SpringPrintingConnection.TblHopDongDieuChinhDialog = TblHopDongDieuChinhDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDongDieuChinhGrid = /** @class */ (function (_super) {
            __extends(TblHopDongDieuChinhGrid, _super);
            function TblHopDongDieuChinhGrid(container) {
                return _super.call(this, container) || this;
            }
            TblHopDongDieuChinhGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblHopDongDieuChinh'; };
            TblHopDongDieuChinhGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblHopDongDieuChinhDialog; };
            TblHopDongDieuChinhGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblHopDongDieuChinhRow.idProperty; };
            TblHopDongDieuChinhGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblHopDongDieuChinhRow.localTextPrefix; };
            TblHopDongDieuChinhGrid.prototype.getService = function () { return SpringPrintingConnection.TblHopDongDieuChinhService.baseUrl; };
            TblHopDongDieuChinhGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblHopDongDieuChinhGrid);
            return TblHopDongDieuChinhGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblHopDongDieuChinhGrid = TblHopDongDieuChinhGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDongDieuChinhsEditor = /** @class */ (function (_super) {
            __extends(TblHopDongDieuChinhsEditor, _super);
            function TblHopDongDieuChinhsEditor(container) {
                return _super.call(this, container) || this;
            }
            TblHopDongDieuChinhsEditor.prototype.getColumnsKey = function () { return "SpringPrintingConnection.TblHopDongDieuChinh"; };
            TblHopDongDieuChinhsEditor.prototype.getDialogType = function () { return SpringPrintingConnection.TblHopDongDieuChinhDialog; };
            TblHopDongDieuChinhsEditor.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblHopDongDieuChinhRow.localTextPrefix; };
            TblHopDongDieuChinhsEditor.prototype.validateEntity = function (row, id) {
                row.KeyId = Q.toId(row.KeyId);
                var sameProduct = Q.tryFirst(this.view.getItems(), function (x) { return x.MaHd === row.KeyId; });
                if (sameProduct && this.id(sameProduct) !== id) {
                    Q.alert('This Contract is already in order details!');
                    return false;
                }
                return true;
            };
            TblHopDongDieuChinhsEditor = __decorate([
                Serenity.Decorators.registerClass()
            ], TblHopDongDieuChinhsEditor);
            return TblHopDongDieuChinhsEditor;
        }(Serene3.Common.GridEditorBase));
        SpringPrintingConnection.TblHopDongDieuChinhsEditor = TblHopDongDieuChinhsEditor;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDongChiTiet_Editor = /** @class */ (function (_super) {
            __extends(TblHopDongChiTiet_Editor, _super);
            function TblHopDongChiTiet_Editor(container) {
                return _super.call(this, container) || this;
            }
            TblHopDongChiTiet_Editor.prototype.getColumnsKey = function () { return "SpringPrintingConnection.TblHopDong_ChiTiet"; };
            TblHopDongChiTiet_Editor.prototype.getDialogType = function () { return SpringPrintingConnection.TblHopDong_ChiTietDialog; };
            TblHopDongChiTiet_Editor.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblHopDong_ChiTietRow.localTextPrefix; };
            TblHopDongChiTiet_Editor.prototype.getAddButtonCaption = function () { return "Add"; };
            TblHopDongChiTiet_Editor.prototype.validateEntity = function (row, id) {
                //alert(Q.toId(id));
                ////row.KeyId = Q.toId(row.KeyId);
                //var sameProduct = Q.tryFirst(this.view.getItems(), x => (x.MaBtp = row.MaBtp) && (x.MaSize = row.MaSize) );
                //alert(sameProduct);
                //if (sameProduct && this.id(sameProduct) !== id) {
                //    Q.alert('This Contract is already in order details!');
                //    return false;
                //}
                //row.MaMauTenMau = "aaa";
                var MaBtp = Q.toId(row.MaBtp);
                if (MaBtp != null) {
                    row.MaBtpMotaBtp = SpringPrintingConnection.TblBanThanhPhamRow.getLookup().itemById[row.MaBtp].MotaBtp;
                }
                else {
                    row.MaBtpMotaBtp = null;
                }
                // row.MaBtpMotaBtp = TblBanThanhPhamRow.getLookup().itemById[row.MaBtp].MotaBtp;
                var MaMau = Q.toId(row.MaMau);
                if (MaMau != null) {
                    row.MaMauTenMau = SpringPrintingConnection.TblRefMauRow.getLookup().itemById[row.MaMau].TenMau;
                }
                else {
                    row.MaMauTenMau = null;
                }
                var MaSize = Q.toId(row.MaSize);
                if (MaSize != null) {
                    row.MaSizeTenSize = SpringPrintingConnection.TblRefSizeRow.getLookup().itemById[row.MaSize].TenSize;
                }
                else {
                    row.MaSizeTenSize = null;
                }
                var MaStyle = Q.toId(row.MaStyle);
                if (MaStyle != null) {
                    row.MaStyleTenStyle = SpringPrintingConnection.TblRefStyleRow.getLookup().itemById[row.MaStyle].TenStyle;
                }
                else {
                    row.MaStyleTenStyle = null;
                }
                return true;
            };
            TblHopDongChiTiet_Editor = __decorate([
                Serenity.Decorators.registerClass()
            ], TblHopDongChiTiet_Editor);
            return TblHopDongChiTiet_Editor;
        }(Serene3.Common.GridEditorBase));
        SpringPrintingConnection.TblHopDongChiTiet_Editor = TblHopDongChiTiet_Editor;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        //@Serenity.Decorators.panel()
        var TblHopDong_ChiTietDialog = /** @class */ (function (_super) {
            __extends(TblHopDong_ChiTietDialog, _super);
            function TblHopDong_ChiTietDialog() {
                var _this = _super.call(this) || this;
                _this.form = new SpringPrintingConnection.TblHopDong_ChiTietForm(_this.idPrefix);
                _this.form.SoLuong.changeSelect2(function (e) {
                    _this.form.ThanhTien.value = _this.form.SoLuong.value * _this.form.DonGia.value;
                    //alert("aaa");
                });
                _this.form.DonGia.changeSelect2(function (e) {
                    _this.form.ThanhTien.value = _this.form.SoLuong.value * _this.form.DonGia.value;
                    //alert("bbbb");
                });
                return _this;
            }
            TblHopDong_ChiTietDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblHopDong_ChiTietForm.formKey; };
            // protected getIdProperty() { return TblHopDong_ChiTietRow.idProperty; }
            // protected getLocalTextPrefix() { return TblHopDong_ChiTietRow.localTextPrefix; }
            TblHopDong_ChiTietDialog.prototype.getService = function () { return SpringPrintingConnection.TblHopDong_ChiTietService.baseUrl; };
            TblHopDong_ChiTietDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], TblHopDong_ChiTietDialog);
            return TblHopDong_ChiTietDialog;
        }(Serene3.Common.GridEditorDialog));
        SpringPrintingConnection.TblHopDong_ChiTietDialog = TblHopDong_ChiTietDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDong_ChiTietGrid = /** @class */ (function (_super) {
            __extends(TblHopDong_ChiTietGrid, _super);
            function TblHopDong_ChiTietGrid(container) {
                return _super.call(this, container) || this;
            }
            TblHopDong_ChiTietGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblHopDong_ChiTiet'; };
            TblHopDong_ChiTietGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblHopDong_ChiTietDialog; };
            TblHopDong_ChiTietGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblHopDong_ChiTietRow.idProperty; };
            TblHopDong_ChiTietGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblHopDong_ChiTietRow.localTextPrefix; };
            TblHopDong_ChiTietGrid.prototype.getService = function () { return SpringPrintingConnection.TblHopDong_ChiTietService.baseUrl; };
            TblHopDong_ChiTietGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblHopDong_ChiTietGrid);
            return TblHopDong_ChiTietGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblHopDong_ChiTietGrid = TblHopDong_ChiTietGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDong_DieuChinhDialog = /** @class */ (function (_super) {
            __extends(TblHopDong_DieuChinhDialog, _super);
            function TblHopDong_DieuChinhDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                // protected getService() { return TblHopDong_DieuChinhService.baseUrl; }
                _this.form = new SpringPrintingConnection.TblHopDong_DieuChinhForm(_this.idPrefix);
                return _this;
            }
            TblHopDong_DieuChinhDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblHopDong_DieuChinhForm.formKey; };
            //  protected getIdProperty() { return TblHopDong_DieuChinhRow.idProperty; }
            TblHopDong_DieuChinhDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblHopDong_DieuChinhRow.localTextPrefix; };
            TblHopDong_DieuChinhDialog = __decorate([
                Serenity.Decorators.registerClass()
                //export class TblHopDong_DieuChinhDialog extends Serenity.EntityDialog<TblHopDong_DieuChinhRow, any> {
            ], TblHopDong_DieuChinhDialog);
            return TblHopDong_DieuChinhDialog;
        }(Serene3.Common.GridEditorDialog));
        SpringPrintingConnection.TblHopDong_DieuChinhDialog = TblHopDong_DieuChinhDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDong_DieuChinhEditor = /** @class */ (function (_super) {
            __extends(TblHopDong_DieuChinhEditor, _super);
            function TblHopDong_DieuChinhEditor(container) {
                return _super.call(this, container) || this;
                //this.form = new TblHopDong_DieuChinhForm(this.idPrefix);
                //alert( this.view.getLength());
            }
            TblHopDong_DieuChinhEditor.prototype.getColumnsKey = function () { return "SpringPrintingConnection.TblHopDong_DieuChinh"; };
            TblHopDong_DieuChinhEditor.prototype.getDialogType = function () { return SpringPrintingConnection.TblHopDong_DieuChinhDialog; };
            TblHopDong_DieuChinhEditor.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblHopDong_DieuChinhRow.localTextPrefix; };
            //  protected getAddButtonCaption() { return "Add";}
            TblHopDong_DieuChinhEditor.prototype.getButtons = function () {
                // call base method to get list of buttons
                // by default, base entity grid adds a few buttons, 
                // add, refresh, column selection in order.
                var buttons = _super.prototype.getButtons.call(this);
                // here is several methods to remove add button
                // only one is enabled, others are commented
                // METHOD 1
                // we would be able to simply return an empty button list,
                // but this would also remove all other buttons
                // return [];
                // METHOD 2
                // remove by splicing (something like delete by index)
                // here we hard code add button index (not nice!)
                // buttons.splice(0, 1);
                // METHOD 3 - recommended
                // remove by splicing, but this time find button index
                // by its css class. it is the best and safer method
                //buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
                //alert('Test');
                return buttons;
            };
            TblHopDong_DieuChinhEditor.prototype.validateEntity = function (row, id) {
                //  alert("Haaaaaa");
                //row.KeyId = Q.toId(row.KeyId);
                //var sameProduct = Q.tryFirst(this.view.getItems(), x => x.MaHd = row.MaHd);
                //if (sameProduct && this.id(sameProduct) !== id) {
                //    Q.alert('This Contract is already in order details!');
                //    return false;
                //}
                // row.MaNvHoTen = TblNguoiDungRow.getLookup().itemById[row.MaNv].HoTen;
                var MaNv = Q.toId(row.MaNv);
                if (MaNv != null) {
                    row.MaNvHoTen = SpringPrintingConnection.TblNguoiDungRow.getLookup().itemById[row.MaNv].HoTen;
                }
                else {
                    row.MaNvHoTen = null;
                }
                return true;
            };
            TblHopDong_DieuChinhEditor = __decorate([
                Serenity.Decorators.registerClass()
            ], TblHopDong_DieuChinhEditor);
            return TblHopDong_DieuChinhEditor;
        }(Serene3.Common.GridEditorBase));
        SpringPrintingConnection.TblHopDong_DieuChinhEditor = TblHopDong_DieuChinhEditor;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblHopDong_DieuChinhGrid = /** @class */ (function (_super) {
            __extends(TblHopDong_DieuChinhGrid, _super);
            function TblHopDong_DieuChinhGrid(container) {
                return _super.call(this, container) || this;
            }
            TblHopDong_DieuChinhGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblHopDong_DieuChinh'; };
            TblHopDong_DieuChinhGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblHopDong_DieuChinhDialog; };
            TblHopDong_DieuChinhGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblHopDong_DieuChinhRow.idProperty; };
            TblHopDong_DieuChinhGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblHopDong_DieuChinhRow.localTextPrefix; };
            TblHopDong_DieuChinhGrid.prototype.getService = function () { return SpringPrintingConnection.TblHopDong_DieuChinhService.baseUrl; };
            TblHopDong_DieuChinhGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblHopDong_DieuChinhGrid);
            return TblHopDong_DieuChinhGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblHopDong_DieuChinhGrid = TblHopDong_DieuChinhGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblKhachHangDialog = /** @class */ (function (_super) {
            __extends(TblKhachHangDialog, _super);
            function TblKhachHangDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblKhachHangForm(_this.idPrefix);
                return _this;
            }
            TblKhachHangDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblKhachHangForm.formKey; };
            TblKhachHangDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblKhachHangRow.idProperty; };
            TblKhachHangDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblKhachHangRow.localTextPrefix; };
            TblKhachHangDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.TblKhachHangRow.nameProperty; };
            TblKhachHangDialog.prototype.getService = function () { return SpringPrintingConnection.TblKhachHangService.baseUrl; };
            TblKhachHangDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], TblKhachHangDialog);
            return TblKhachHangDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblKhachHangDialog = TblKhachHangDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblKhachHangGrid = /** @class */ (function (_super) {
            __extends(TblKhachHangGrid, _super);
            function TblKhachHangGrid(container) {
                return _super.call(this, container) || this;
            }
            TblKhachHangGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblKhachHang'; };
            TblKhachHangGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblKhachHangDialog; };
            TblKhachHangGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblKhachHangRow.idProperty; };
            TblKhachHangGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblKhachHangRow.localTextPrefix; };
            TblKhachHangGrid.prototype.getService = function () { return SpringPrintingConnection.TblKhachHangService.baseUrl; };
            TblKhachHangGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblKhachHangGrid);
            return TblKhachHangGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblKhachHangGrid = TblKhachHangGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLenChuyenDialog = /** @class */ (function (_super) {
            __extends(TblLenChuyenDialog, _super);
            function TblLenChuyenDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblLenChuyenForm(_this.idPrefix);
                return _this;
            }
            TblLenChuyenDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblLenChuyenForm.formKey; };
            TblLenChuyenDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblLenChuyenRow.idProperty; };
            TblLenChuyenDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblLenChuyenRow.localTextPrefix; };
            TblLenChuyenDialog.prototype.getService = function () { return SpringPrintingConnection.TblLenChuyenService.baseUrl; };
            TblLenChuyenDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                if (!(Serene3.Authorization.hasPermission("Serene3:TblLenChuyen:Modify"))) {
                    this.deleteButton.hide();
                    this.saveAndCloseButton.hide();
                    this.applyChangesButton.hide();
                    Serenity.EditorUtils.setReadonly(this.element.find('.editor'), true);
                }
                if (!(Serene3.Authorization.hasPermission("Serene3:TblLenChuyen:Delete"))) {
                    this.deleteButton.hide();
                }
            };
            TblLenChuyenDialog = __decorate([
                Serenity.Decorators.registerClass(),
                Serenity.Decorators.panel()
            ], TblLenChuyenDialog);
            return TblLenChuyenDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblLenChuyenDialog = TblLenChuyenDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLenChuyenGrid = /** @class */ (function (_super) {
            __extends(TblLenChuyenGrid, _super);
            function TblLenChuyenGrid(container) {
                return _super.call(this, container) || this;
            }
            TblLenChuyenGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblLenChuyen'; };
            TblLenChuyenGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblLenChuyenDialog; };
            TblLenChuyenGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblLenChuyenRow.idProperty; };
            TblLenChuyenGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblLenChuyenRow.localTextPrefix; };
            TblLenChuyenGrid.prototype.getService = function () { return SpringPrintingConnection.TblLenChuyenService.baseUrl; };
            TblLenChuyenGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    service: SpringPrintingConnection.TblLenChuyenService.baseUrl + '/ListExcel',
                    separator: true
                }));
                if (!(Serene3.Authorization.hasPermission("Serene3:TblLenChuyen:Modify"))) {
                    buttons.splice(Q.indexOf(buttons, function (x) { return x.cssClass == "add-button"; }), 1);
                }
                return buttons;
            };
            TblLenChuyenGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblLenChuyenGrid);
            return TblLenChuyenGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblLenChuyenGrid = TblLenChuyenGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLenChuyenInChiTietDialog = /** @class */ (function (_super) {
            __extends(TblLenChuyenInChiTietDialog, _super);
            function TblLenChuyenInChiTietDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblLenChuyenInChiTietForm(_this.idPrefix);
                return _this;
            }
            TblLenChuyenInChiTietDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblLenChuyenInChiTietForm.formKey; };
            TblLenChuyenInChiTietDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblLenChuyenInChiTietRow.idProperty; };
            TblLenChuyenInChiTietDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblLenChuyenInChiTietRow.localTextPrefix; };
            TblLenChuyenInChiTietDialog.prototype.getService = function () { return SpringPrintingConnection.TblLenChuyenInChiTietService.baseUrl; };
            TblLenChuyenInChiTietDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], TblLenChuyenInChiTietDialog);
            return TblLenChuyenInChiTietDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblLenChuyenInChiTietDialog = TblLenChuyenInChiTietDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLenChuyenInChiTietGrid = /** @class */ (function (_super) {
            __extends(TblLenChuyenInChiTietGrid, _super);
            function TblLenChuyenInChiTietGrid(container) {
                return _super.call(this, container) || this;
            }
            TblLenChuyenInChiTietGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblLenChuyenInChiTiet'; };
            TblLenChuyenInChiTietGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblLenChuyenInChiTietDialog; };
            TblLenChuyenInChiTietGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblLenChuyenInChiTietRow.idProperty; };
            TblLenChuyenInChiTietGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblLenChuyenInChiTietRow.localTextPrefix; };
            TblLenChuyenInChiTietGrid.prototype.getService = function () { return SpringPrintingConnection.TblLenChuyenInChiTietService.baseUrl; };
            TblLenChuyenInChiTietGrid.prototype.createToolbarExtensions = function () {
                var _this = this;
                _super.prototype.createToolbarExtensions.call(this);
                //this.country = Serenity.Widget.create({
                //    type: Serenity.StringEditor,
                //    element: el => el.appendTo(this.toolbar.element).attr('placeholder', '--- ' +
                //        Q.text('Ma Lo') + ' ---'
                //    ).css("width", "100px")
                //});
                this.month = Serenity.Widget.create({
                    type: Serenity.StringEditor,
                    options: {},
                    element: function (e) { return e.insertAfter(_this.toolbar.element).attr('placeholder', '-Scan Card-').css("width", "150px"); },
                    init: function (w) { return w.change(function (x) {
                        if (!(Serene3.Authorization.hasPermission("Serene3:TblLenChuyenInChiTiet:Modify"))) {
                            alert(Q.text("Controls.NotPermission"));
                            return;
                        }
                        if (_this.sMaLo111 != "" && _this.sMaLo111 != undefined) {
                            SpringPrintingConnection.TblLenChuyenInChiTietService.GetData({
                                Note: w.value.toString(),
                                MaLenChuyen: _this.sMaLo111
                            }, function (response) {
                                // alert(response.KeyID); alert(response.ErrorCode);
                                _this.sMaLo = response.KeyID.toString();
                                //alert(response.toString());
                                //this.form.Days.value = parseFloat(response.toString());
                                //this.country.value = response.toString();
                                _this.refresh();
                            });
                        }
                        else {
                            SpringPrintingConnection.TblLenChuyenInChiTietService.GetData({
                                Note: w.value.toString(),
                                MaLenChuyen: _this.sMaLo
                            }, function (response) {
                                //alert(response.KeyID); alert(response.ErrorCode);
                                _this.sMaLo = response.KeyID.toString();
                                _this.sMaLo111 = _this.sMaLo;
                                //alert(response.toString());
                                //this.form.Days.value = parseFloat(response.toString());
                                //this.country.value = response.toString();
                                _this.refresh();
                            });
                        }
                        // this.refresh();
                        w.value = null;
                        // this.city.get_items[0].va = this.country.cascadeValue[0];
                        return;
                    }); }
                });
            };
            TblLenChuyenInChiTietGrid.prototype.getQuickFilters = function () {
                var _this = this;
                var filters = _super.prototype.getQuickFilters.call(this);
                var fld = Serene3.SpringPrintingConnection.TblLenChuyenInChiTietRow.Fields;
                //alert(this.sMaLo);
                //if (this.sMaLo111 != undefined)
                //    Q.first(filters, x => x.field == fld.MaLo).init = w => {
                //        (w as Serenity.IntegerEditor).value = parseInt(this.sMaLo111);// this.sMaLo;
                // alert(this.sMaLo);
                var MaloFilter = Q.first(filters, function (x) { return x.field == "MaLenChuyen" /* MaLenChuyen */; });
                MaloFilter.handler = function (h) {
                    if ((h.value == "" || h.value == null) && _this.sMaLo != undefined) {
                        h.request.EqualityFilter["MaLenChuyen" /* MaLenChuyen */] = _this.sMaLo; // h.value;
                    }
                    else {
                        h.request.EqualityFilter["MaLenChuyen" /* MaLenChuyen */] = h.value; // h.value;
                    }
                    if (h.active) {
                        _this.sMaLo = undefined;
                        h.request.EqualityFilter["MaLenChuyen" /* MaLenChuyen */] = h.value; // h.value;
                        _this.sMaLo111 = h.value;
                    }
                    else {
                        if (_this.sMaLo == undefined) {
                            h.request.EqualityFilter["MaLenChuyen" /* MaLenChuyen */] = null;
                            _this.sMaLo111 = "";
                        }
                    }
                    _this.sMaLo111 = h.value;
                    // var values = (h.widget as Serenity.LookupEditor).values;
                    //alert( h.value);
                    if (_this.sMaLo != undefined && (_this.sMaLo111 == "" || _this.sMaLo111 == null)) {
                        _this.sMaLo111 = _this.sMaLo;
                    }
                    // alert(this.sMaLo111);
                    //alert(this.sMaLo111);
                };
                return filters;
            };
            TblLenChuyenInChiTietGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblLenChuyenInChiTietGrid);
            return TblLenChuyenInChiTietGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblLenChuyenInChiTietGrid = TblLenChuyenInChiTietGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLenChuyenInChiTietsEditor = /** @class */ (function (_super) {
            __extends(TblLenChuyenInChiTietsEditor, _super);
            function TblLenChuyenInChiTietsEditor(container) {
                return _super.call(this, container) || this;
            }
            TblLenChuyenInChiTietsEditor.prototype.getColumnsKey = function () { return "SpringPrintingConnection.TblLenChuyenInChiTiet"; };
            TblLenChuyenInChiTietsEditor.prototype.getDialogType = function () { return SpringPrintingConnection.TblLenChuyenInChiTietDialog; };
            TblLenChuyenInChiTietsEditor.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblLenChuyenInChiTietRow.localTextPrefix; };
            TblLenChuyenInChiTietsEditor.prototype.validateEntity = function (row, id) {
                row.KeyId = Q.toId(row.KeyId);
                var sameProduct = Q.tryFirst(this.view.getItems(), function (x) { return x.MaLenChuyen === row.KeyId; });
                if (sameProduct && this.id(sameProduct) !== id) {
                    Q.alert('This Contract is already in order details!');
                    return false;
                }
                return true;
            };
            TblLenChuyenInChiTietsEditor = __decorate([
                Serenity.Decorators.registerClass()
            ], TblLenChuyenInChiTietsEditor);
            return TblLenChuyenInChiTietsEditor;
        }(Serene3.Common.GridEditorBase));
        SpringPrintingConnection.TblLenChuyenInChiTietsEditor = TblLenChuyenInChiTietsEditor;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLenChuyenIn_ChiTietDialog = /** @class */ (function (_super) {
            __extends(TblLenChuyenIn_ChiTietDialog, _super);
            function TblLenChuyenIn_ChiTietDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                //  protected getService() { return TblLenChuyenIn_ChiTietService.baseUrl; }
                _this.form = new SpringPrintingConnection.TblLenChuyenIn_ChiTietForm(_this.idPrefix);
                return _this;
                //protected form: TblLenChuyenIn_ChiTietForm;
                //constructor() {
                //    super();
                //    this.form = new TblLenChuyenIn_ChiTietForm(this.idPrefix);
                //    this.form.SoLuong.changeSelect2(e => {
                //        this.form.ThanhTien.value = this.form.SoLuong.value * this.form.DonGia.value;
                //        //alert("aaa");
                //    });
                //    this.form.DonGia.changeSelect2(e => {
                //        this.form.ThanhTien.value = this.form.SoLuong.value * this.form.DonGia.value;
                //        //alert("bbbb");
                //    });
                //}
            }
            // export class TblLenChuyenIn_ChiTietDialog extends Serenity.EntityDialog<TblLenChuyenIn_ChiTietRow, any> {
            TblLenChuyenIn_ChiTietDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblLenChuyenIn_ChiTietForm.formKey; };
            // protected getIdProperty() { return TblLenChuyenIn_ChiTietRow.idProperty; }
            TblLenChuyenIn_ChiTietDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblLenChuyenIn_ChiTietRow.localTextPrefix; };
            TblLenChuyenIn_ChiTietDialog = __decorate([
                Serenity.Decorators.panel(),
                Serenity.Decorators.registerClass()
            ], TblLenChuyenIn_ChiTietDialog);
            return TblLenChuyenIn_ChiTietDialog;
        }(Serene3.Common.GridEditorDialog));
        SpringPrintingConnection.TblLenChuyenIn_ChiTietDialog = TblLenChuyenIn_ChiTietDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLenChuyenIn_ChiTietEditor = /** @class */ (function (_super) {
            __extends(TblLenChuyenIn_ChiTietEditor, _super);
            function TblLenChuyenIn_ChiTietEditor(container) {
                return _super.call(this, container) || this;
            }
            TblLenChuyenIn_ChiTietEditor.prototype.getColumnsKey = function () { return "SpringPrintingConnection.TblLenChuyenIn_ChiTiet"; };
            TblLenChuyenIn_ChiTietEditor.prototype.getDialogType = function () { return SpringPrintingConnection.TblLenChuyenIn_ChiTietDialog; };
            TblLenChuyenIn_ChiTietEditor.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblLenChuyenIn_ChiTietRow.localTextPrefix; };
            TblLenChuyenIn_ChiTietEditor.prototype.validateEntity = function (row, id) {
                //row.KeyId = Q.toId(row.KeyId);
                // alert(VChiTietBtp_StyleRow.getLookup().itemById[row.MaBo].MaStyle);
                // alert(VChiTietBtp_SizeRow.getLookup().itemById[row.MaBo].MaSize);
                //var sameProduct = Q.tryFirst(this.view.getItems(), x => x.MaLenChuyen === row.KeyId);
                //if (sameProduct && this.id(sameProduct) !== id) {
                //    Q.alert('This Contract is already in order details!');
                //    return false;
                //}
                //row.MaBtpMotaBtp = TblBo_BTPRow.getLookup().itemById[row.MaBtp].MotaBtp;
                row.CT_MaBTP = SpringPrintingConnection.VChiTietBtpRow.getLookup().itemById[row.MaBo].MaBtp;
                row.CT_MaMau = SpringPrintingConnection.VChiTietBtp_Style_ColorRow.getLookup().itemById[row.MaBo].MaMau;
                row.CT_MaStyle = SpringPrintingConnection.VChiTietBtp_StyleRow.getLookup().itemById[row.MaBo].MaStyle;
                row.CT_MaSize = SpringPrintingConnection.VChiTietBtp_SizeRow.getLookup().itemById[row.MaBo].MaSize;
                //var MaBtp = Q.toId(row.MaBtp.value);
                //if (MaBtp != null) {
                //    row.CT_MaBTP = TblBanThanhPhamRow.getLookup().itemById[row.MaBtp].MotaBtp;
                //}
                //else {
                //    row.CT_MaBTP = null;
                //}
                //var MaMau = Q.toId(row.MaMau.value);
                //if (MaMau != null) {
                //    row.CT_MaMau = TblRefMauRow.getLookup().itemById[row.MaMau].TenMau;
                //}
                //else {
                //    row.CT_MaMau = null;
                //}
                //var MaSize = Q.toId(row.MaSize.value);
                //if (MaSize != null) {
                //    row.CT_MaSize = TblRefSizeRow.getLookup().itemById[row.MaSize].TenSize;
                //}
                //else {
                //    row.CT_MaSize = null;
                //}
                //var MaStyle = Q.toId(row.MaStyle.value);
                //if (MaStyle != null) {
                //    row.CT_MaStyle = TblRefStyleRow.getLookup().itemById[row.MaStyle].TenStyle;
                //}
                //else {
                //    row.CT_MaStyle = null;
                //}
                //row.MaSizeTenSize = TblBo_BTPRow.getLookup().itemById[row.MaSize].TenSize;
                //row.MaStyleTenStyle = TblBo_BTPRow.getLookup().itemById[row.MaStyle].TenStyle;
                return true;
            };
            TblLenChuyenIn_ChiTietEditor = __decorate([
                Serenity.Decorators.registerClass()
            ], TblLenChuyenIn_ChiTietEditor);
            return TblLenChuyenIn_ChiTietEditor;
        }(Serene3.Common.GridEditorBase));
        SpringPrintingConnection.TblLenChuyenIn_ChiTietEditor = TblLenChuyenIn_ChiTietEditor;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLenChuyenIn_ChiTietGrid = /** @class */ (function (_super) {
            __extends(TblLenChuyenIn_ChiTietGrid, _super);
            function TblLenChuyenIn_ChiTietGrid(container) {
                return _super.call(this, container) || this;
            }
            TblLenChuyenIn_ChiTietGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblLenChuyenIn_ChiTiet'; };
            TblLenChuyenIn_ChiTietGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblLenChuyenIn_ChiTietDialog; };
            TblLenChuyenIn_ChiTietGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblLenChuyenIn_ChiTietRow.idProperty; };
            TblLenChuyenIn_ChiTietGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblLenChuyenIn_ChiTietRow.localTextPrefix; };
            TblLenChuyenIn_ChiTietGrid.prototype.getService = function () { return SpringPrintingConnection.TblLenChuyenIn_ChiTietService.baseUrl; };
            TblLenChuyenIn_ChiTietGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblLenChuyenIn_ChiTietGrid);
            return TblLenChuyenIn_ChiTietGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblLenChuyenIn_ChiTietGrid = TblLenChuyenIn_ChiTietGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLoSpDialog = /** @class */ (function (_super) {
            __extends(TblLoSpDialog, _super);
            function TblLoSpDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblLoSpForm(_this.idPrefix);
                return _this;
            }
            TblLoSpDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblLoSpForm.formKey; };
            TblLoSpDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblLoSpRow.idProperty; };
            TblLoSpDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblLoSpRow.localTextPrefix; };
            TblLoSpDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.TblLoSpRow.nameProperty; };
            TblLoSpDialog.prototype.getService = function () { return SpringPrintingConnection.TblLoSpService.baseUrl; };
            TblLoSpDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                if (!(Serene3.Authorization.hasPermission("Serene3:TblLoSp:Modify"))) {
                    this.deleteButton.hide();
                    this.saveAndCloseButton.hide();
                    this.applyChangesButton.hide();
                    Serenity.EditorUtils.setReadonly(this.element.find('.editor'), true);
                }
                if (!(Serene3.Authorization.hasPermission("Serene3:TblLoSp:Delete"))) {
                    this.deleteButton.hide();
                }
            };
            TblLoSpDialog = __decorate([
                Serenity.Decorators.registerClass(),
                Serenity.Decorators.panel()
            ], TblLoSpDialog);
            return TblLoSpDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblLoSpDialog = TblLoSpDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblLoSpGrid = /** @class */ (function (_super) {
            __extends(TblLoSpGrid, _super);
            function TblLoSpGrid(container) {
                return _super.call(this, container) || this;
            }
            TblLoSpGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblLoSp'; };
            TblLoSpGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblLoSpDialog; };
            TblLoSpGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblLoSpRow.idProperty; };
            TblLoSpGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblLoSpRow.localTextPrefix; };
            TblLoSpGrid.prototype.getService = function () { return SpringPrintingConnection.TblLoSpService.baseUrl; };
            TblLoSpGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    service: SpringPrintingConnection.TblLoSpService.baseUrl + '/ListExcel',
                    separator: true
                }));
                if (!(Serene3.Authorization.hasPermission("Serene3:TblLoSp:Modify"))) {
                    buttons.splice(Q.indexOf(buttons, function (x) { return x.cssClass == "add-button"; }), 1);
                }
                return buttons;
            };
            TblLoSpGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblLoSpGrid);
            return TblLoSpGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblLoSpGrid = TblLoSpGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblNguoiDungDialog = /** @class */ (function (_super) {
            __extends(TblNguoiDungDialog, _super);
            function TblNguoiDungDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblNguoiDungForm(_this.idPrefix);
                return _this;
            }
            TblNguoiDungDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblNguoiDungForm.formKey; };
            TblNguoiDungDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblNguoiDungRow.idProperty; };
            TblNguoiDungDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblNguoiDungRow.localTextPrefix; };
            TblNguoiDungDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.TblNguoiDungRow.nameProperty; };
            TblNguoiDungDialog.prototype.getService = function () { return SpringPrintingConnection.TblNguoiDungService.baseUrl; };
            TblNguoiDungDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], TblNguoiDungDialog);
            return TblNguoiDungDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblNguoiDungDialog = TblNguoiDungDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblNguoiDungGrid = /** @class */ (function (_super) {
            __extends(TblNguoiDungGrid, _super);
            function TblNguoiDungGrid(container) {
                return _super.call(this, container) || this;
            }
            TblNguoiDungGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblNguoiDung'; };
            TblNguoiDungGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblNguoiDungDialog; };
            TblNguoiDungGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblNguoiDungRow.idProperty; };
            TblNguoiDungGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblNguoiDungRow.localTextPrefix; };
            TblNguoiDungGrid.prototype.getService = function () { return SpringPrintingConnection.TblNguoiDungService.baseUrl; };
            TblNguoiDungGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblNguoiDungGrid);
            return TblNguoiDungGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblNguoiDungGrid = TblNguoiDungGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefMauDialog = /** @class */ (function (_super) {
            __extends(TblRefMauDialog, _super);
            function TblRefMauDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblRefMauForm(_this.idPrefix);
                return _this;
            }
            TblRefMauDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblRefMauForm.formKey; };
            TblRefMauDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblRefMauRow.idProperty; };
            TblRefMauDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblRefMauRow.localTextPrefix; };
            TblRefMauDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.TblRefMauRow.nameProperty; };
            TblRefMauDialog.prototype.getService = function () { return SpringPrintingConnection.TblRefMauService.baseUrl; };
            TblRefMauDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], TblRefMauDialog);
            return TblRefMauDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblRefMauDialog = TblRefMauDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefMauGrid = /** @class */ (function (_super) {
            __extends(TblRefMauGrid, _super);
            function TblRefMauGrid(container) {
                return _super.call(this, container) || this;
            }
            TblRefMauGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblRefMau'; };
            TblRefMauGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblRefMauDialog; };
            TblRefMauGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblRefMauRow.idProperty; };
            TblRefMauGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblRefMauRow.localTextPrefix; };
            TblRefMauGrid.prototype.getService = function () { return SpringPrintingConnection.TblRefMauService.baseUrl; };
            TblRefMauGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblRefMauGrid);
            return TblRefMauGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblRefMauGrid = TblRefMauGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefNguoiDaiDienDialog = /** @class */ (function (_super) {
            __extends(TblRefNguoiDaiDienDialog, _super);
            function TblRefNguoiDaiDienDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblRefNguoiDaiDienForm(_this.idPrefix);
                return _this;
            }
            TblRefNguoiDaiDienDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblRefNguoiDaiDienForm.formKey; };
            TblRefNguoiDaiDienDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblRefNguoiDaiDienRow.idProperty; };
            TblRefNguoiDaiDienDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblRefNguoiDaiDienRow.localTextPrefix; };
            TblRefNguoiDaiDienDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.TblRefNguoiDaiDienRow.nameProperty; };
            TblRefNguoiDaiDienDialog.prototype.getService = function () { return SpringPrintingConnection.TblRefNguoiDaiDienService.baseUrl; };
            TblRefNguoiDaiDienDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], TblRefNguoiDaiDienDialog);
            return TblRefNguoiDaiDienDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblRefNguoiDaiDienDialog = TblRefNguoiDaiDienDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefNguoiDaiDienGrid = /** @class */ (function (_super) {
            __extends(TblRefNguoiDaiDienGrid, _super);
            function TblRefNguoiDaiDienGrid(container) {
                return _super.call(this, container) || this;
            }
            TblRefNguoiDaiDienGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblRefNguoiDaiDien'; };
            TblRefNguoiDaiDienGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblRefNguoiDaiDienDialog; };
            TblRefNguoiDaiDienGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblRefNguoiDaiDienRow.idProperty; };
            TblRefNguoiDaiDienGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblRefNguoiDaiDienRow.localTextPrefix; };
            TblRefNguoiDaiDienGrid.prototype.getService = function () { return SpringPrintingConnection.TblRefNguoiDaiDienService.baseUrl; };
            TblRefNguoiDaiDienGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblRefNguoiDaiDienGrid);
            return TblRefNguoiDaiDienGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblRefNguoiDaiDienGrid = TblRefNguoiDaiDienGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefSexDialog = /** @class */ (function (_super) {
            __extends(TblRefSexDialog, _super);
            function TblRefSexDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblRefSexForm(_this.idPrefix);
                return _this;
            }
            TblRefSexDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblRefSexForm.formKey; };
            TblRefSexDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblRefSexRow.idProperty; };
            TblRefSexDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblRefSexRow.localTextPrefix; };
            TblRefSexDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.TblRefSexRow.nameProperty; };
            TblRefSexDialog.prototype.getService = function () { return SpringPrintingConnection.TblRefSexService.baseUrl; };
            TblRefSexDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], TblRefSexDialog);
            return TblRefSexDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblRefSexDialog = TblRefSexDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefSexGrid = /** @class */ (function (_super) {
            __extends(TblRefSexGrid, _super);
            function TblRefSexGrid(container) {
                return _super.call(this, container) || this;
            }
            TblRefSexGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblRefSex'; };
            TblRefSexGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblRefSexDialog; };
            TblRefSexGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblRefSexRow.idProperty; };
            TblRefSexGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblRefSexRow.localTextPrefix; };
            TblRefSexGrid.prototype.getService = function () { return SpringPrintingConnection.TblRefSexService.baseUrl; };
            TblRefSexGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblRefSexGrid);
            return TblRefSexGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblRefSexGrid = TblRefSexGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefSizeDialog = /** @class */ (function (_super) {
            __extends(TblRefSizeDialog, _super);
            function TblRefSizeDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblRefSizeForm(_this.idPrefix);
                return _this;
            }
            TblRefSizeDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblRefSizeForm.formKey; };
            TblRefSizeDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblRefSizeRow.idProperty; };
            TblRefSizeDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblRefSizeRow.localTextPrefix; };
            TblRefSizeDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.TblRefSizeRow.nameProperty; };
            TblRefSizeDialog.prototype.getService = function () { return SpringPrintingConnection.TblRefSizeService.baseUrl; };
            TblRefSizeDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], TblRefSizeDialog);
            return TblRefSizeDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblRefSizeDialog = TblRefSizeDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefSizeGrid = /** @class */ (function (_super) {
            __extends(TblRefSizeGrid, _super);
            function TblRefSizeGrid(container) {
                return _super.call(this, container) || this;
            }
            TblRefSizeGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblRefSize'; };
            TblRefSizeGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblRefSizeDialog; };
            TblRefSizeGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblRefSizeRow.idProperty; };
            TblRefSizeGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblRefSizeRow.localTextPrefix; };
            TblRefSizeGrid.prototype.getService = function () { return SpringPrintingConnection.TblRefSizeService.baseUrl; };
            TblRefSizeGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblRefSizeGrid);
            return TblRefSizeGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblRefSizeGrid = TblRefSizeGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefStyleDialog = /** @class */ (function (_super) {
            __extends(TblRefStyleDialog, _super);
            function TblRefStyleDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblRefStyleForm(_this.idPrefix);
                return _this;
            }
            TblRefStyleDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblRefStyleForm.formKey; };
            TblRefStyleDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblRefStyleRow.idProperty; };
            TblRefStyleDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblRefStyleRow.localTextPrefix; };
            TblRefStyleDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.TblRefStyleRow.nameProperty; };
            TblRefStyleDialog.prototype.getService = function () { return SpringPrintingConnection.TblRefStyleService.baseUrl; };
            TblRefStyleDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], TblRefStyleDialog);
            return TblRefStyleDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblRefStyleDialog = TblRefStyleDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefStyleGrid = /** @class */ (function (_super) {
            __extends(TblRefStyleGrid, _super);
            function TblRefStyleGrid(container) {
                return _super.call(this, container) || this;
            }
            TblRefStyleGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblRefStyle'; };
            TblRefStyleGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblRefStyleDialog; };
            TblRefStyleGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblRefStyleRow.idProperty; };
            TblRefStyleGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblRefStyleRow.localTextPrefix; };
            TblRefStyleGrid.prototype.getService = function () { return SpringPrintingConnection.TblRefStyleService.baseUrl; };
            TblRefStyleGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblRefStyleGrid);
            return TblRefStyleGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblRefStyleGrid = TblRefStyleGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefTypeDialog = /** @class */ (function (_super) {
            __extends(TblRefTypeDialog, _super);
            function TblRefTypeDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblRefTypeForm(_this.idPrefix);
                return _this;
            }
            TblRefTypeDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblRefTypeForm.formKey; };
            TblRefTypeDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblRefTypeRow.idProperty; };
            TblRefTypeDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblRefTypeRow.localTextPrefix; };
            TblRefTypeDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.TblRefTypeRow.nameProperty; };
            TblRefTypeDialog.prototype.getService = function () { return SpringPrintingConnection.TblRefTypeService.baseUrl; };
            TblRefTypeDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], TblRefTypeDialog);
            return TblRefTypeDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblRefTypeDialog = TblRefTypeDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblRefTypeGrid = /** @class */ (function (_super) {
            __extends(TblRefTypeGrid, _super);
            function TblRefTypeGrid(container) {
                return _super.call(this, container) || this;
            }
            TblRefTypeGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblRefType'; };
            TblRefTypeGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblRefTypeDialog; };
            TblRefTypeGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblRefTypeRow.idProperty; };
            TblRefTypeGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblRefTypeRow.localTextPrefix; };
            TblRefTypeGrid.prototype.getService = function () { return SpringPrintingConnection.TblRefTypeService.baseUrl; };
            TblRefTypeGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblRefTypeGrid);
            return TblRefTypeGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblRefTypeGrid = TblRefTypeGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuatKhoChiTietDialog = /** @class */ (function (_super) {
            __extends(TblXuatKhoChiTietDialog, _super);
            function TblXuatKhoChiTietDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblXuatKhoChiTietForm(_this.idPrefix);
                return _this;
            }
            TblXuatKhoChiTietDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblXuatKhoChiTietForm.formKey; };
            TblXuatKhoChiTietDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblXuatKhoChiTietRow.idProperty; };
            TblXuatKhoChiTietDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblXuatKhoChiTietRow.localTextPrefix; };
            TblXuatKhoChiTietDialog.prototype.getService = function () { return SpringPrintingConnection.TblXuatKhoChiTietService.baseUrl; };
            TblXuatKhoChiTietDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                if (!(Serene3.Authorization.hasPermission("Serene3:TblXuatKhoChiTiet:Modify"))) {
                    this.deleteButton.hide();
                    this.saveAndCloseButton.hide();
                    this.applyChangesButton.hide();
                    Serenity.EditorUtils.setReadonly(this.element.find('.editor'), true);
                }
                if (!(Serene3.Authorization.hasPermission("Serene3:TblXuatKhoChiTiet:Delete"))) {
                    this.deleteButton.hide();
                }
            };
            TblXuatKhoChiTietDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], TblXuatKhoChiTietDialog);
            return TblXuatKhoChiTietDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblXuatKhoChiTietDialog = TblXuatKhoChiTietDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuatKhoChiTietGrid = /** @class */ (function (_super) {
            __extends(TblXuatKhoChiTietGrid, _super);
            function TblXuatKhoChiTietGrid(container) {
                return _super.call(this, container) || this;
            }
            TblXuatKhoChiTietGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblXuatKhoChiTiet'; };
            TblXuatKhoChiTietGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblXuatKhoChiTietDialog; };
            TblXuatKhoChiTietGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblXuatKhoChiTietRow.idProperty; };
            TblXuatKhoChiTietGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblXuatKhoChiTietRow.localTextPrefix; };
            TblXuatKhoChiTietGrid.prototype.getService = function () { return SpringPrintingConnection.TblXuatKhoChiTietService.baseUrl; };
            TblXuatKhoChiTietGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    service: SpringPrintingConnection.TblXuatKhoChiTietService.baseUrl + '/ListExcel',
                    separator: true
                }));
                if (!(Serene3.Authorization.hasPermission("Serene3:TblXuatKhoChiTiet:Modify"))) {
                    buttons.splice(Q.indexOf(buttons, function (x) { return x.cssClass == "add-button"; }), 1);
                }
                return buttons;
            };
            TblXuatKhoChiTietGrid.prototype.createToolbarExtensions = function () {
                var _this = this;
                _super.prototype.createToolbarExtensions.call(this);
                //this.country = Serenity.Widget.create({
                //    type: Serenity.StringEditor,
                //    element: el => el.appendTo(this.toolbar.element).attr('placeholder', '--- ' +
                //        Q.text('Ma Lo') + ' ---'
                //    ).css("width", "100px")
                //});
                this.month = Serenity.Widget.create({
                    type: Serenity.StringEditor,
                    options: {},
                    element: function (e) { return e.insertAfter(_this.toolbar.element).attr('placeholder', '-Scan Card-').css("width", "150px"); },
                    init: function (w) { return w.change(function (x) {
                        if (!(Serene3.Authorization.hasPermission("Serene3:TblXuatKhoChiTiet:Modify"))) {
                            alert(Q.text("Permission.NotPermission"));
                            return;
                        }
                        if (_this.sMaLo111 != "" && _this.sMaLo111 != undefined) {
                            SpringPrintingConnection.TblXuatKhoChiTietService.GetData({
                                Note: w.value.toString(),
                                MaBo: _this.sMaLo111
                            }, function (response) {
                                //alert(response.toString());
                                //this.form.Days.value = parseFloat(response.toString());
                                _this.sMaLo = response.KeyID.toString();
                                _this.refresh();
                            });
                        }
                        else {
                            SpringPrintingConnection.TblXuatKhoChiTietService.GetData({
                                Note: w.value.toString(),
                                MaBo: _this.sMaLo
                            }, function (response) {
                                //alert(response.toString());
                                //this.form.Days.value = parseFloat(response.toString());
                                _this.sMaLo = response.KeyID.toString();
                                _this.sMaLo111 = _this.sMaLo;
                                _this.refresh();
                            });
                        }
                        // this.refresh();
                        w.value = null;
                        // this.city.get_items[0].va = this.country.cascadeValue[0];
                        return;
                    }); }
                });
            };
            TblXuatKhoChiTietGrid.prototype.getQuickFilters = function () {
                var _this = this;
                var filters = _super.prototype.getQuickFilters.call(this);
                var fld = Serene3.SpringPrintingConnection.TblXuatKhoChiTietRow.Fields;
                //alert(this.sMaLo);
                //if (this.sMaLo111 != undefined)
                //    Q.first(filters, x => x.field == fld.MaLo).init = w => {
                //        (w as Serenity.IntegerEditor).value = parseInt(this.sMaLo111);// this.sMaLo;
                // alert(this.sMaLo);
                var MaloFilter = Q.first(filters, function (x) { return x.field == "MaPhieuXuat" /* MaPhieuXuat */; });
                MaloFilter.handler = function (h) {
                    if ((h.value == "" || h.value == null) && _this.sMaLo != undefined) {
                        h.request.EqualityFilter["MaPhieuXuat" /* MaPhieuXuat */] = _this.sMaLo; // h.value;
                    }
                    else {
                        h.request.EqualityFilter["MaPhieuXuat" /* MaPhieuXuat */] = h.value; // h.value;
                    }
                    if (h.active) {
                        _this.sMaLo = undefined;
                        h.request.EqualityFilter["MaPhieuXuat" /* MaPhieuXuat */] = h.value; // h.value;
                        _this.sMaLo111 = h.value;
                    }
                    else {
                        if (_this.sMaLo == undefined) {
                            h.request.EqualityFilter["MaPhieuXuat" /* MaPhieuXuat */] = null;
                            _this.sMaLo111 = "";
                        }
                    }
                    _this.sMaLo111 = h.value;
                    // var values = (h.widget as Serenity.LookupEditor).values;
                    //alert( h.value);
                    if (_this.sMaLo != undefined && (_this.sMaLo111 == "" || _this.sMaLo111 == null)) {
                        _this.sMaLo111 = _this.sMaLo;
                    }
                    // alert(this.sMaLo111);
                    //alert(this.sMaLo111);
                };
                return filters;
            };
            TblXuatKhoChiTietGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblXuatKhoChiTietGrid);
            return TblXuatKhoChiTietGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblXuatKhoChiTietGrid = TblXuatKhoChiTietGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuatKhoChiTietsEditor = /** @class */ (function (_super) {
            __extends(TblXuatKhoChiTietsEditor, _super);
            function TblXuatKhoChiTietsEditor(container) {
                return _super.call(this, container) || this;
            }
            TblXuatKhoChiTietsEditor.prototype.getColumnsKey = function () { return "SpringPrintingConnection.TblXuatKhoChiTiet"; };
            TblXuatKhoChiTietsEditor.prototype.getDialogType = function () { return SpringPrintingConnection.TblXuatKhoChiTietDialog; };
            TblXuatKhoChiTietsEditor.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblXuatKhoChiTietRow.localTextPrefix; };
            TblXuatKhoChiTietsEditor.prototype.validateEntity = function (row, id) {
                row.KeyId = Q.toId(row.KeyId);
                var sameProduct = Q.tryFirst(this.view.getItems(), function (x) { return x.MaPhieuXuat === row.KeyId; });
                if (sameProduct && this.id(sameProduct) !== id) {
                    Q.alert('This Contract is already in order details!');
                    return false;
                }
                return true;
            };
            TblXuatKhoChiTietsEditor = __decorate([
                Serenity.Decorators.registerClass()
            ], TblXuatKhoChiTietsEditor);
            return TblXuatKhoChiTietsEditor;
        }(Serene3.Common.GridEditorBase));
        SpringPrintingConnection.TblXuatKhoChiTietsEditor = TblXuatKhoChiTietsEditor;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuatKhoKhDialog = /** @class */ (function (_super) {
            __extends(TblXuatKhoKhDialog, _super);
            function TblXuatKhoKhDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblXuatKhoKhForm(_this.idPrefix);
                return _this;
            }
            TblXuatKhoKhDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblXuatKhoKhForm.formKey; };
            TblXuatKhoKhDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblXuatKhoKhRow.idProperty; };
            TblXuatKhoKhDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblXuatKhoKhRow.localTextPrefix; };
            TblXuatKhoKhDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.TblXuatKhoKhRow.nameProperty; };
            TblXuatKhoKhDialog.prototype.getService = function () { return SpringPrintingConnection.TblXuatKhoKhService.baseUrl; };
            TblXuatKhoKhDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                if (!(Serene3.Authorization.hasPermission("Serene3:TblXuatKhoKh:Modify"))) {
                    this.deleteButton.hide();
                    this.saveAndCloseButton.hide();
                    this.applyChangesButton.hide();
                    Serenity.EditorUtils.setReadonly(this.element.find('.editor'), true);
                }
                if (!(Serene3.Authorization.hasPermission("Serene3:TblXuatKhoKh:Delete"))) {
                    this.deleteButton.hide();
                }
            };
            TblXuatKhoKhDialog = __decorate([
                Serenity.Decorators.registerClass(),
                Serenity.Decorators.panel()
            ], TblXuatKhoKhDialog);
            return TblXuatKhoKhDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblXuatKhoKhDialog = TblXuatKhoKhDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuatKhoKhGrid = /** @class */ (function (_super) {
            __extends(TblXuatKhoKhGrid, _super);
            function TblXuatKhoKhGrid(container) {
                return _super.call(this, container) || this;
            }
            TblXuatKhoKhGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblXuatKhoKh'; };
            TblXuatKhoKhGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblXuatKhoKhDialog; };
            TblXuatKhoKhGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblXuatKhoKhRow.idProperty; };
            TblXuatKhoKhGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblXuatKhoKhRow.localTextPrefix; };
            TblXuatKhoKhGrid.prototype.getService = function () { return SpringPrintingConnection.TblXuatKhoKhService.baseUrl; };
            TblXuatKhoKhGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    service: SpringPrintingConnection.TblXuatKhoKhService.baseUrl + '/ListExcel',
                    separator: true
                }));
                if (!(Serene3.Authorization.hasPermission("Serene3:TblXuatKhoKh:Modify"))) {
                    buttons.splice(Q.indexOf(buttons, function (x) { return x.cssClass == "add-button"; }), 1);
                }
                return buttons;
            };
            TblXuatKhoKhGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblXuatKhoKhGrid);
            return TblXuatKhoKhGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblXuatKhoKhGrid = TblXuatKhoKhGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuatKho_ChiTietDialog = /** @class */ (function (_super) {
            __extends(TblXuatKho_ChiTietDialog, _super);
            function TblXuatKho_ChiTietDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                // protected getService() { return TblXuatKho_ChiTietService.baseUrl; }
                _this.form = new SpringPrintingConnection.TblXuatKho_ChiTietForm(_this.idPrefix);
                return _this;
            }
            //export class TblXuatKho_ChiTietDialog extends Serenity.EntityDialog<TblXuatKho_ChiTietRow, any> {
            TblXuatKho_ChiTietDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblXuatKho_ChiTietForm.formKey; };
            // protected getIdProperty() { return TblXuatKho_ChiTietRow.idProperty; }
            TblXuatKho_ChiTietDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblXuatKho_ChiTietRow.localTextPrefix; };
            TblXuatKho_ChiTietDialog = __decorate([
                Serenity.Decorators.panel(),
                Serenity.Decorators.registerClass()
            ], TblXuatKho_ChiTietDialog);
            return TblXuatKho_ChiTietDialog;
        }(Serene3.Common.GridEditorDialog));
        SpringPrintingConnection.TblXuatKho_ChiTietDialog = TblXuatKho_ChiTietDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuatKho_ChiTietEditor = /** @class */ (function (_super) {
            __extends(TblXuatKho_ChiTietEditor, _super);
            function TblXuatKho_ChiTietEditor(container) {
                return _super.call(this, container) || this;
            }
            TblXuatKho_ChiTietEditor.prototype.getColumnsKey = function () { return "SpringPrintingConnection.TblXuatKho_ChiTiet"; };
            TblXuatKho_ChiTietEditor.prototype.getDialogType = function () { return SpringPrintingConnection.TblXuatKho_ChiTietDialog; };
            TblXuatKho_ChiTietEditor.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblXuatKho_ChiTietRow.localTextPrefix; };
            TblXuatKho_ChiTietEditor.prototype.validateEntity = function (row, id) {
                //row.KeyId = Q.toId(row.KeyId);
                //var sameProduct = Q.tryFirst(this.view.getItems(), x => x.MaPhieuXuat === row.KeyId);
                //if (sameProduct && this.id(sameProduct) !== id) {
                //    Q.alert('This Contract is already in order details!');
                //    return false;
                //}
                row.CT_MaBTP = SpringPrintingConnection.VChiTietBtpRow.getLookup().itemById[row.MaBo].MaBtp;
                row.CT_MaMau = SpringPrintingConnection.VChiTietBtp_Style_ColorRow.getLookup().itemById[row.MaBo].MaMau;
                row.CT_MaStyle = SpringPrintingConnection.VChiTietBtp_StyleRow.getLookup().itemById[row.MaBo].MaStyle;
                row.CT_MaSize = SpringPrintingConnection.VChiTietBtp_SizeRow.getLookup().itemById[row.MaBo].MaSize;
                return true;
            };
            TblXuatKho_ChiTietEditor = __decorate([
                Serenity.Decorators.registerClass()
            ], TblXuatKho_ChiTietEditor);
            return TblXuatKho_ChiTietEditor;
        }(Serene3.Common.GridEditorBase));
        SpringPrintingConnection.TblXuatKho_ChiTietEditor = TblXuatKho_ChiTietEditor;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuatKho_ChiTietGrid = /** @class */ (function (_super) {
            __extends(TblXuatKho_ChiTietGrid, _super);
            function TblXuatKho_ChiTietGrid(container) {
                return _super.call(this, container) || this;
            }
            TblXuatKho_ChiTietGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblXuatKho_ChiTiet'; };
            TblXuatKho_ChiTietGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblXuatKho_ChiTietDialog; };
            TblXuatKho_ChiTietGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblXuatKho_ChiTietRow.idProperty; };
            TblXuatKho_ChiTietGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblXuatKho_ChiTietRow.localTextPrefix; };
            TblXuatKho_ChiTietGrid.prototype.getService = function () { return SpringPrintingConnection.TblXuatKho_ChiTietService.baseUrl; };
            TblXuatKho_ChiTietGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblXuatKho_ChiTietGrid);
            return TblXuatKho_ChiTietGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblXuatKho_ChiTietGrid = TblXuatKho_ChiTietGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuongChuyenDialog = /** @class */ (function (_super) {
            __extends(TblXuongChuyenDialog, _super);
            function TblXuongChuyenDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblXuongChuyenForm(_this.idPrefix);
                return _this;
            }
            TblXuongChuyenDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblXuongChuyenForm.formKey; };
            TblXuongChuyenDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblXuongChuyenRow.idProperty; };
            TblXuongChuyenDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblXuongChuyenRow.localTextPrefix; };
            TblXuongChuyenDialog.prototype.getService = function () { return SpringPrintingConnection.TblXuongChuyenService.baseUrl; };
            TblXuongChuyenDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                if (!(Serene3.Authorization.hasPermission("Serene3:TblXuongChuyen:Modify"))) {
                    this.deleteButton.hide();
                    this.saveAndCloseButton.hide();
                    this.applyChangesButton.hide();
                    Serenity.EditorUtils.setReadonly(this.element.find('.editor'), true);
                }
                if (!(Serene3.Authorization.hasPermission("Serene3:TblXuongChuyen:Delete"))) {
                    this.deleteButton.hide();
                }
            };
            TblXuongChuyenDialog = __decorate([
                Serenity.Decorators.registerClass(),
                Serenity.Decorators.panel()
            ], TblXuongChuyenDialog);
            return TblXuongChuyenDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblXuongChuyenDialog = TblXuongChuyenDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuongChuyenGrid = /** @class */ (function (_super) {
            __extends(TblXuongChuyenGrid, _super);
            function TblXuongChuyenGrid(container) {
                return _super.call(this, container) || this;
            }
            TblXuongChuyenGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblXuongChuyen'; };
            TblXuongChuyenGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblXuongChuyenDialog; };
            TblXuongChuyenGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblXuongChuyenRow.idProperty; };
            TblXuongChuyenGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblXuongChuyenRow.localTextPrefix; };
            TblXuongChuyenGrid.prototype.getService = function () { return SpringPrintingConnection.TblXuongChuyenService.baseUrl; };
            TblXuongChuyenGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    service: SpringPrintingConnection.TblXuongChuyenService.baseUrl + '/ListExcel',
                    separator: true
                }));
                if (!(Serene3.Authorization.hasPermission("Serene3:TblXuongChuyen:Modify"))) {
                    buttons.splice(Q.indexOf(buttons, function (x) { return x.cssClass == "add-button"; }), 1);
                }
                return buttons;
            };
            TblXuongChuyenGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblXuongChuyenGrid);
            return TblXuongChuyenGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblXuongChuyenGrid = TblXuongChuyenGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuongChuyenInChiTietDialog = /** @class */ (function (_super) {
            __extends(TblXuongChuyenInChiTietDialog, _super);
            function TblXuongChuyenInChiTietDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.TblXuongChuyenInChiTietForm(_this.idPrefix);
                return _this;
            }
            TblXuongChuyenInChiTietDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblXuongChuyenInChiTietForm.formKey; };
            TblXuongChuyenInChiTietDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.TblXuongChuyenInChiTietRow.idProperty; };
            TblXuongChuyenInChiTietDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblXuongChuyenInChiTietRow.localTextPrefix; };
            TblXuongChuyenInChiTietDialog.prototype.getService = function () { return SpringPrintingConnection.TblXuongChuyenInChiTietService.baseUrl; };
            TblXuongChuyenInChiTietDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                if (!(Serene3.Authorization.hasPermission("Serene3:TblXuongChuyenInChiTiet:Modify"))) {
                    this.deleteButton.hide();
                    this.saveAndCloseButton.hide();
                    this.applyChangesButton.hide();
                    Serenity.EditorUtils.setReadonly(this.element.find('.editor'), true);
                }
                if (!(Serene3.Authorization.hasPermission("Serene3:TblXuongChuyenInChiTiet:Delete"))) {
                    this.deleteButton.hide();
                }
            };
            TblXuongChuyenInChiTietDialog = __decorate([
                Serenity.Decorators.registerClass()
                //export class TblXuongChuyenInChiTietDialog extends Serenity.EntityDialog<TblXuongChuyenInChiTietRow, any> {
            ], TblXuongChuyenInChiTietDialog);
            return TblXuongChuyenInChiTietDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.TblXuongChuyenInChiTietDialog = TblXuongChuyenInChiTietDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuongChuyenInChiTietGrid = /** @class */ (function (_super) {
            __extends(TblXuongChuyenInChiTietGrid, _super);
            function TblXuongChuyenInChiTietGrid(container) {
                return _super.call(this, container) || this;
            }
            TblXuongChuyenInChiTietGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblXuongChuyenInChiTiet'; };
            TblXuongChuyenInChiTietGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblXuongChuyenInChiTietDialog; };
            TblXuongChuyenInChiTietGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblXuongChuyenInChiTietRow.idProperty; };
            TblXuongChuyenInChiTietGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblXuongChuyenInChiTietRow.localTextPrefix; };
            TblXuongChuyenInChiTietGrid.prototype.getService = function () { return SpringPrintingConnection.TblXuongChuyenInChiTietService.baseUrl; };
            TblXuongChuyenInChiTietGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    service: SpringPrintingConnection.TblXuongChuyenInChiTietService.baseUrl + '/ListExcel',
                    separator: true
                }));
                if (!(Serene3.Authorization.hasPermission("Serene3:TblXuongChuyenInChiTiet:Modify"))) {
                    buttons.splice(Q.indexOf(buttons, function (x) { return x.cssClass == "add-button"; }), 1);
                }
                return buttons;
            };
            TblXuongChuyenInChiTietGrid.prototype.createToolbarExtensions = function () {
                var _this = this;
                _super.prototype.createToolbarExtensions.call(this);
                //this.country = Serenity.Widget.create({
                //    type: Serenity.StringEditor,
                //    element: el => el.appendTo(this.toolbar.element).attr('placeholder', '--- ' +
                //        Q.text('Ma Lo') + ' ---'
                //    ).css("width", "100px")
                //});
                this.month = Serenity.Widget.create({
                    type: Serenity.StringEditor,
                    options: {},
                    element: function (e) { return e.insertAfter(_this.toolbar.element).attr('placeholder', '-Scan Card-').css("width", "150px"); },
                    init: function (w) { return w.change(function (x) {
                        if (!(Serene3.Authorization.hasPermission("Serene3:TblXuongChuyenInChiTiet:Modify"))) {
                            alert(Q.text("Permission.NotPermission"));
                            return;
                        }
                        if (_this.sMaLo111 != "" && _this.sMaLo111 != undefined) {
                            SpringPrintingConnection.TblXuongChuyenInChiTietService.GetData({
                                Note: w.value.toString(),
                                MaXuongChuyen: _this.sMaLo111
                            }, function (response) {
                                _this.sMaLo = response.KeyID.toString();
                                _this.sMaLo111 = _this.sMaLo;
                                //alert(response.toString());
                                //this.form.Days.value = parseFloat(response.toString());
                                //this.country.value = response.toString();
                                _this.refresh();
                            });
                        }
                        else {
                            SpringPrintingConnection.TblXuongChuyenInChiTietService.GetData({
                                Note: w.value.toString(),
                                MaXuongChuyen: _this.sMaLo
                            }, function (response) {
                                _this.sMaLo = response.KeyID.toString();
                                //alert(response.toString());
                                //this.form.Days.value = parseFloat(response.toString());
                                // this.country.value = response.toString();
                                _this.refresh();
                            });
                        }
                        // this.refresh();
                        w.value = null;
                        // this.city.get_items[0].va = this.country.cascadeValue[0];
                        return;
                    }); }
                });
            };
            TblXuongChuyenInChiTietGrid.prototype.getQuickFilters = function () {
                var _this = this;
                var filters = _super.prototype.getQuickFilters.call(this);
                var fld = Serene3.SpringPrintingConnection.TblXuongChuyenInChiTietRow.Fields;
                //alert(this.sMaLo);
                //if (this.sMaLo111 != undefined)
                //    Q.first(filters, x => x.field == fld.MaLo).init = w => {
                //        (w as Serenity.IntegerEditor).value = parseInt(this.sMaLo111);// this.sMaLo;
                // alert(this.sMaLo);
                var MaloFilter = Q.first(filters, function (x) { return x.field == "MaXuongChuyen" /* MaXuongChuyen */; });
                MaloFilter.handler = function (h) {
                    if ((h.value == "" || h.value == null) && _this.sMaLo != undefined) {
                        h.request.EqualityFilter["MaXuongChuyen" /* MaXuongChuyen */] = _this.sMaLo; // h.value;
                    }
                    else {
                        h.request.EqualityFilter["MaXuongChuyen" /* MaXuongChuyen */] = h.value; // h.value;
                    }
                    if (h.active) {
                        _this.sMaLo = undefined;
                        h.request.EqualityFilter["MaXuongChuyen" /* MaXuongChuyen */] = h.value; // h.value;
                        _this.sMaLo111 = h.value;
                    }
                    else {
                        if (_this.sMaLo == undefined) {
                            h.request.EqualityFilter["MaXuongChuyen" /* MaXuongChuyen */] = null;
                            _this.sMaLo111 = "";
                        }
                    }
                    _this.sMaLo111 = h.value;
                    // var values = (h.widget as Serenity.LookupEditor).values;
                    //alert( h.value);
                    if (_this.sMaLo != undefined && (_this.sMaLo111 == "" || _this.sMaLo111 == null)) {
                        _this.sMaLo111 = _this.sMaLo;
                    }
                    // alert(this.sMaLo111);
                    //alert(this.sMaLo111);
                };
                return filters;
            };
            TblXuongChuyenInChiTietGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblXuongChuyenInChiTietGrid);
            return TblXuongChuyenInChiTietGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblXuongChuyenInChiTietGrid = TblXuongChuyenInChiTietGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuongChuyenInChiTietsEditor = /** @class */ (function (_super) {
            __extends(TblXuongChuyenInChiTietsEditor, _super);
            function TblXuongChuyenInChiTietsEditor(container) {
                return _super.call(this, container) || this;
            }
            TblXuongChuyenInChiTietsEditor.prototype.getColumnsKey = function () { return "SpringPrintingConnection.TblXuongChuyenInChiTiet"; };
            TblXuongChuyenInChiTietsEditor.prototype.getDialogType = function () { return SpringPrintingConnection.TblXuongChuyenInChiTietDialog; };
            TblXuongChuyenInChiTietsEditor.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblXuongChuyenInChiTietRow.localTextPrefix; };
            TblXuongChuyenInChiTietsEditor.prototype.validateEntity = function (row, id) {
                row.KeyId = Q.toId(row.KeyId);
                var sameProduct = Q.tryFirst(this.view.getItems(), function (x) { return x.MaXuongChuyen === row.KeyId; });
                if (sameProduct && this.id(sameProduct) !== id) {
                    Q.alert('This Contract is already in order details!');
                    return false;
                }
                return true;
            };
            TblXuongChuyenInChiTietsEditor = __decorate([
                Serenity.Decorators.registerClass()
            ], TblXuongChuyenInChiTietsEditor);
            return TblXuongChuyenInChiTietsEditor;
        }(Serene3.Common.GridEditorBase));
        SpringPrintingConnection.TblXuongChuyenInChiTietsEditor = TblXuongChuyenInChiTietsEditor;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuongChuyenIn_ChiTietDialog = /** @class */ (function (_super) {
            __extends(TblXuongChuyenIn_ChiTietDialog, _super);
            function TblXuongChuyenIn_ChiTietDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                //protected getService() { return TblXuongChuyenIn_ChiTietService.baseUrl; }
                _this.form = new SpringPrintingConnection.TblXuongChuyenIn_ChiTietForm(_this.idPrefix);
                return _this;
            }
            //export class TblXuongChuyenIn_ChiTietDialog extends Serenity.EntityDialog<TblXuongChuyenIn_ChiTietRow, any> {
            TblXuongChuyenIn_ChiTietDialog.prototype.getFormKey = function () { return SpringPrintingConnection.TblXuongChuyenIn_ChiTietForm.formKey; };
            //  protected getIdProperty() { return TblXuongChuyenIn_ChiTietRow.idProperty; }
            TblXuongChuyenIn_ChiTietDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblXuongChuyenIn_ChiTietRow.localTextPrefix; };
            TblXuongChuyenIn_ChiTietDialog = __decorate([
                Serenity.Decorators.panel(),
                Serenity.Decorators.registerClass()
            ], TblXuongChuyenIn_ChiTietDialog);
            return TblXuongChuyenIn_ChiTietDialog;
        }(Serene3.Common.GridEditorDialog));
        SpringPrintingConnection.TblXuongChuyenIn_ChiTietDialog = TblXuongChuyenIn_ChiTietDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuongChuyenIn_ChiTietEditor = /** @class */ (function (_super) {
            __extends(TblXuongChuyenIn_ChiTietEditor, _super);
            function TblXuongChuyenIn_ChiTietEditor(container) {
                return _super.call(this, container) || this;
            }
            TblXuongChuyenIn_ChiTietEditor.prototype.getColumnsKey = function () { return "SpringPrintingConnection.TblXuongChuyenIn_ChiTiet"; };
            TblXuongChuyenIn_ChiTietEditor.prototype.getDialogType = function () { return SpringPrintingConnection.TblXuongChuyenIn_ChiTietDialog; };
            TblXuongChuyenIn_ChiTietEditor.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblXuongChuyenIn_ChiTietRow.localTextPrefix; };
            TblXuongChuyenIn_ChiTietEditor.prototype.validateEntity = function (row, id) {
                row.KeyId = Q.toId(row.KeyId);
                //alert(VChiTietBtp_StyleRow.getLookup().itemById[row.MaBo].MaStyle);
                //alert(VChiTietBtp_SizeRow.getLookup().itemById[row.MaBo].MaSize);
                //var sameProduct = Q.tryFirst(this.view.getItems(), x => x.MaXuongChuyen === row.KeyId);
                //if (sameProduct && this.id(sameProduct) !== id) {
                //    Q.alert('This Contract is already in order details!');
                //    return false;
                //}
                row.CT_MaBTP = SpringPrintingConnection.VChiTietBtpRow.getLookup().itemById[row.MaBo].MaBtp;
                row.CT_MaMau = SpringPrintingConnection.VChiTietBtp_Style_ColorRow.getLookup().itemById[row.MaBo].MaMau;
                row.CT_MaStyle = SpringPrintingConnection.VChiTietBtp_StyleRow.getLookup().itemById[row.MaBo].MaStyle;
                row.CT_MaSize = SpringPrintingConnection.VChiTietBtp_SizeRow.getLookup().itemById[row.MaBo].MaSize;
                return true;
            };
            TblXuongChuyenIn_ChiTietEditor = __decorate([
                Serenity.Decorators.registerClass()
            ], TblXuongChuyenIn_ChiTietEditor);
            return TblXuongChuyenIn_ChiTietEditor;
        }(Serene3.Common.GridEditorBase));
        SpringPrintingConnection.TblXuongChuyenIn_ChiTietEditor = TblXuongChuyenIn_ChiTietEditor;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var TblXuongChuyenIn_ChiTietGrid = /** @class */ (function (_super) {
            __extends(TblXuongChuyenIn_ChiTietGrid, _super);
            function TblXuongChuyenIn_ChiTietGrid(container) {
                return _super.call(this, container) || this;
            }
            TblXuongChuyenIn_ChiTietGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.TblXuongChuyenIn_ChiTiet'; };
            TblXuongChuyenIn_ChiTietGrid.prototype.getDialogType = function () { return SpringPrintingConnection.TblXuongChuyenIn_ChiTietDialog; };
            TblXuongChuyenIn_ChiTietGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.TblXuongChuyenIn_ChiTietRow.idProperty; };
            TblXuongChuyenIn_ChiTietGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.TblXuongChuyenIn_ChiTietRow.localTextPrefix; };
            TblXuongChuyenIn_ChiTietGrid.prototype.getService = function () { return SpringPrintingConnection.TblXuongChuyenIn_ChiTietService.baseUrl; };
            TblXuongChuyenIn_ChiTietGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], TblXuongChuyenIn_ChiTietGrid);
            return TblXuongChuyenIn_ChiTietGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.TblXuongChuyenIn_ChiTietGrid = TblXuongChuyenIn_ChiTietGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VChiTietBtpDialog = /** @class */ (function (_super) {
            __extends(VChiTietBtpDialog, _super);
            function VChiTietBtpDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.VChiTietBtpForm(_this.idPrefix);
                return _this;
            }
            VChiTietBtpDialog.prototype.getFormKey = function () { return SpringPrintingConnection.VChiTietBtpForm.formKey; };
            VChiTietBtpDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.VChiTietBtpRow.idProperty; };
            VChiTietBtpDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.VChiTietBtpRow.localTextPrefix; };
            VChiTietBtpDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.VChiTietBtpRow.nameProperty; };
            VChiTietBtpDialog.prototype.getService = function () { return SpringPrintingConnection.VChiTietBtpService.baseUrl; };
            VChiTietBtpDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                this.deleteButton.hide();
                this.saveAndCloseButton.hide();
                this.applyChangesButton.hide();
            };
            VChiTietBtpDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], VChiTietBtpDialog);
            return VChiTietBtpDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.VChiTietBtpDialog = VChiTietBtpDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VChiTietBtpGrid = /** @class */ (function (_super) {
            __extends(VChiTietBtpGrid, _super);
            function VChiTietBtpGrid(container) {
                return _super.call(this, container) || this;
            }
            VChiTietBtpGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.VChiTietBtp'; };
            VChiTietBtpGrid.prototype.getDialogType = function () { return SpringPrintingConnection.VChiTietBtpDialog; };
            VChiTietBtpGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.VChiTietBtpRow.idProperty; };
            VChiTietBtpGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.VChiTietBtpRow.localTextPrefix; };
            VChiTietBtpGrid.prototype.getService = function () { return SpringPrintingConnection.VChiTietBtpService.baseUrl; };
            VChiTietBtpGrid.prototype.getButtons = function () {
                var buttons = _super.prototype.getButtons.call(this);
                buttons.splice(Q.indexOf(buttons, function (x) { return x.cssClass == "add-button"; }), 1);
                return buttons;
            };
            VChiTietBtpGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], VChiTietBtpGrid);
            return VChiTietBtpGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.VChiTietBtpGrid = VChiTietBtpGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VChiTietBtp_SizeDialog = /** @class */ (function (_super) {
            __extends(VChiTietBtp_SizeDialog, _super);
            function VChiTietBtp_SizeDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.VChiTietBtp_SizeForm(_this.idPrefix);
                return _this;
            }
            VChiTietBtp_SizeDialog.prototype.getFormKey = function () { return SpringPrintingConnection.VChiTietBtp_SizeForm.formKey; };
            VChiTietBtp_SizeDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.VChiTietBtp_SizeRow.idProperty; };
            VChiTietBtp_SizeDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.VChiTietBtp_SizeRow.localTextPrefix; };
            VChiTietBtp_SizeDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.VChiTietBtp_SizeRow.nameProperty; };
            VChiTietBtp_SizeDialog.prototype.getService = function () { return SpringPrintingConnection.VChiTietBtp_SizeService.baseUrl; };
            VChiTietBtp_SizeDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], VChiTietBtp_SizeDialog);
            return VChiTietBtp_SizeDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.VChiTietBtp_SizeDialog = VChiTietBtp_SizeDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VChiTietBtp_SizeGrid = /** @class */ (function (_super) {
            __extends(VChiTietBtp_SizeGrid, _super);
            function VChiTietBtp_SizeGrid(container) {
                return _super.call(this, container) || this;
            }
            VChiTietBtp_SizeGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.VChiTietBtp_Size'; };
            VChiTietBtp_SizeGrid.prototype.getDialogType = function () { return SpringPrintingConnection.VChiTietBtp_SizeDialog; };
            VChiTietBtp_SizeGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.VChiTietBtp_SizeRow.idProperty; };
            VChiTietBtp_SizeGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.VChiTietBtp_SizeRow.localTextPrefix; };
            VChiTietBtp_SizeGrid.prototype.getService = function () { return SpringPrintingConnection.VChiTietBtp_SizeService.baseUrl; };
            VChiTietBtp_SizeGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], VChiTietBtp_SizeGrid);
            return VChiTietBtp_SizeGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.VChiTietBtp_SizeGrid = VChiTietBtp_SizeGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VChiTietBtp_StyleDialog = /** @class */ (function (_super) {
            __extends(VChiTietBtp_StyleDialog, _super);
            function VChiTietBtp_StyleDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.VChiTietBtp_StyleForm(_this.idPrefix);
                return _this;
            }
            VChiTietBtp_StyleDialog.prototype.getFormKey = function () { return SpringPrintingConnection.VChiTietBtp_StyleForm.formKey; };
            VChiTietBtp_StyleDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.VChiTietBtp_StyleRow.idProperty; };
            VChiTietBtp_StyleDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.VChiTietBtp_StyleRow.localTextPrefix; };
            VChiTietBtp_StyleDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.VChiTietBtp_StyleRow.nameProperty; };
            VChiTietBtp_StyleDialog.prototype.getService = function () { return SpringPrintingConnection.VChiTietBtp_StyleService.baseUrl; };
            VChiTietBtp_StyleDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], VChiTietBtp_StyleDialog);
            return VChiTietBtp_StyleDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.VChiTietBtp_StyleDialog = VChiTietBtp_StyleDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VChiTietBtp_StyleGrid = /** @class */ (function (_super) {
            __extends(VChiTietBtp_StyleGrid, _super);
            function VChiTietBtp_StyleGrid(container) {
                return _super.call(this, container) || this;
            }
            VChiTietBtp_StyleGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.VChiTietBtp_Style'; };
            VChiTietBtp_StyleGrid.prototype.getDialogType = function () { return SpringPrintingConnection.VChiTietBtp_StyleDialog; };
            VChiTietBtp_StyleGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.VChiTietBtp_StyleRow.idProperty; };
            VChiTietBtp_StyleGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.VChiTietBtp_StyleRow.localTextPrefix; };
            VChiTietBtp_StyleGrid.prototype.getService = function () { return SpringPrintingConnection.VChiTietBtp_StyleService.baseUrl; };
            VChiTietBtp_StyleGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], VChiTietBtp_StyleGrid);
            return VChiTietBtp_StyleGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.VChiTietBtp_StyleGrid = VChiTietBtp_StyleGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VChiTietBtp_Style_ColorDialog = /** @class */ (function (_super) {
            __extends(VChiTietBtp_Style_ColorDialog, _super);
            function VChiTietBtp_Style_ColorDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.VChiTietBtp_Style_ColorForm(_this.idPrefix);
                return _this;
            }
            VChiTietBtp_Style_ColorDialog.prototype.getFormKey = function () { return SpringPrintingConnection.VChiTietBtp_Style_ColorForm.formKey; };
            VChiTietBtp_Style_ColorDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.VChiTietBtp_Style_ColorRow.idProperty; };
            VChiTietBtp_Style_ColorDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.VChiTietBtp_Style_ColorRow.localTextPrefix; };
            VChiTietBtp_Style_ColorDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.VChiTietBtp_Style_ColorRow.nameProperty; };
            VChiTietBtp_Style_ColorDialog.prototype.getService = function () { return SpringPrintingConnection.VChiTietBtp_Style_ColorService.baseUrl; };
            VChiTietBtp_Style_ColorDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], VChiTietBtp_Style_ColorDialog);
            return VChiTietBtp_Style_ColorDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.VChiTietBtp_Style_ColorDialog = VChiTietBtp_Style_ColorDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VChiTietBtp_Style_ColorGrid = /** @class */ (function (_super) {
            __extends(VChiTietBtp_Style_ColorGrid, _super);
            function VChiTietBtp_Style_ColorGrid(container) {
                return _super.call(this, container) || this;
            }
            VChiTietBtp_Style_ColorGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.VChiTietBtp_Style_Color'; };
            VChiTietBtp_Style_ColorGrid.prototype.getDialogType = function () { return SpringPrintingConnection.VChiTietBtp_Style_ColorDialog; };
            VChiTietBtp_Style_ColorGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.VChiTietBtp_Style_ColorRow.idProperty; };
            VChiTietBtp_Style_ColorGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.VChiTietBtp_Style_ColorRow.localTextPrefix; };
            VChiTietBtp_Style_ColorGrid.prototype.getService = function () { return SpringPrintingConnection.VChiTietBtp_Style_ColorService.baseUrl; };
            VChiTietBtp_Style_ColorGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], VChiTietBtp_Style_ColorGrid);
            return VChiTietBtp_Style_ColorGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.VChiTietBtp_Style_ColorGrid = VChiTietBtp_Style_ColorGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VHopDongChiTietDialog = /** @class */ (function (_super) {
            __extends(VHopDongChiTietDialog, _super);
            function VHopDongChiTietDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.VHopDongChiTietForm(_this.idPrefix);
                return _this;
            }
            VHopDongChiTietDialog.prototype.getFormKey = function () { return SpringPrintingConnection.VHopDongChiTietForm.formKey; };
            VHopDongChiTietDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.VHopDongChiTietRow.idProperty; };
            VHopDongChiTietDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.VHopDongChiTietRow.localTextPrefix; };
            VHopDongChiTietDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.VHopDongChiTietRow.nameProperty; };
            VHopDongChiTietDialog.prototype.getService = function () { return SpringPrintingConnection.VHopDongChiTietService.baseUrl; };
            VHopDongChiTietDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], VHopDongChiTietDialog);
            return VHopDongChiTietDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.VHopDongChiTietDialog = VHopDongChiTietDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VHopDongChiTietGrid = /** @class */ (function (_super) {
            __extends(VHopDongChiTietGrid, _super);
            function VHopDongChiTietGrid(container) {
                return _super.call(this, container) || this;
            }
            VHopDongChiTietGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.VHopDongChiTiet'; };
            VHopDongChiTietGrid.prototype.getDialogType = function () { return SpringPrintingConnection.VHopDongChiTietDialog; };
            VHopDongChiTietGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.VHopDongChiTietRow.idProperty; };
            VHopDongChiTietGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.VHopDongChiTietRow.localTextPrefix; };
            VHopDongChiTietGrid.prototype.getService = function () { return SpringPrintingConnection.VHopDongChiTietService.baseUrl; };
            VHopDongChiTietGrid.prototype.getSlickOptions = function () {
                var opt = _super.prototype.getSlickOptions.call(this);
                opt.showFooterRow = true;
                return opt;
            };
            VHopDongChiTietGrid.prototype.usePager = function () {
                return false;
            };
            VHopDongChiTietGrid.prototype.getButtons = function () {
                var _this = this;
                return [{
                        title: 'Group By HD',
                        cssClass: 'expand-all-button',
                        onClick: function () { return _this.view.setGrouping([{
                                getter: 'MaHd'
                            }]); }
                    },
                    {
                        title: 'No Grouping',
                        cssClass: 'collapse-all-button',
                        onClick: function () { return _this.view.setGrouping([]); }
                    }];
            };
            VHopDongChiTietGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], VHopDongChiTietGrid);
            return VHopDongChiTietGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.VHopDongChiTietGrid = VHopDongChiTietGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VHopDongTrangThaiDialog = /** @class */ (function (_super) {
            __extends(VHopDongTrangThaiDialog, _super);
            function VHopDongTrangThaiDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.VHopDongTrangThaiForm(_this.idPrefix);
                return _this;
            }
            VHopDongTrangThaiDialog.prototype.getFormKey = function () { return SpringPrintingConnection.VHopDongTrangThaiForm.formKey; };
            VHopDongTrangThaiDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.VHopDongTrangThaiRow.idProperty; };
            VHopDongTrangThaiDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.VHopDongTrangThaiRow.localTextPrefix; };
            VHopDongTrangThaiDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.VHopDongTrangThaiRow.nameProperty; };
            VHopDongTrangThaiDialog.prototype.getService = function () { return SpringPrintingConnection.VHopDongTrangThaiService.baseUrl; };
            VHopDongTrangThaiDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                this.deleteButton.hide();
                this.saveAndCloseButton.hide();
                this.applyChangesButton.hide();
            };
            VHopDongTrangThaiDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], VHopDongTrangThaiDialog);
            return VHopDongTrangThaiDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.VHopDongTrangThaiDialog = VHopDongTrangThaiDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VHopDongTrangThaiGrid = /** @class */ (function (_super) {
            __extends(VHopDongTrangThaiGrid, _super);
            function VHopDongTrangThaiGrid(container) {
                return _super.call(this, container) || this;
            }
            VHopDongTrangThaiGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.VHopDongTrangThai'; };
            VHopDongTrangThaiGrid.prototype.getDialogType = function () { return SpringPrintingConnection.VHopDongTrangThaiDialog; };
            VHopDongTrangThaiGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.VHopDongTrangThaiRow.idProperty; };
            VHopDongTrangThaiGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.VHopDongTrangThaiRow.localTextPrefix; };
            VHopDongTrangThaiGrid.prototype.getService = function () { return SpringPrintingConnection.VHopDongTrangThaiService.baseUrl; };
            VHopDongTrangThaiGrid.prototype.createSlickGrid = function () {
                var grid = _super.prototype.createSlickGrid.call(this);
                // need to register this plugin for grouping or you'll have errors
                grid.registerPlugin(new Slick.Data.GroupItemMetadataProvider());
                this.view.setSummaryOptions({
                    aggregators: []
                });
                return grid;
            };
            VHopDongTrangThaiGrid.prototype.getSlickOptions = function () {
                var opt = _super.prototype.getSlickOptions.call(this);
                opt.showFooterRow = true;
                return opt;
            };
            VHopDongTrangThaiGrid.prototype.usePager = function () {
                return false;
            };
            VHopDongTrangThaiGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    service: SpringPrintingConnection.VHopDongTrangThaiService.baseUrl + '/ListExcel',
                    separator: true
                }));
                buttons.push({
                    title: 'Group By SoHd',
                    cssClass: 'expand-all-button',
                    onClick: function () { return _this.view.setGrouping([{
                            getter: 'SoHd'
                        }]); },
                    separator: true
                });
                buttons.push({
                    title: 'Group By SoHd and product',
                    cssClass: 'expand-all-button',
                    onClick: function () { return _this.view.setGrouping([{
                            formatter: function (x) { return 'Contract: ' + x.value + ' (' + x.count + ' items)'; },
                            getter: 'SoHd'
                        }, {
                            formatter: function (x) { return ': ' + x.value + ' (' + x.count + ' items)'; },
                            getter: 'MotaBtp'
                        }]); }
                });
                buttons.push({
                    title: 'No Grouping',
                    cssClass: 'collapse-all-button',
                    onClick: function () { return _this.view.setGrouping([]); }
                });
                buttons.splice(Q.indexOf(buttons, function (x) { return x.cssClass == "add-button"; }), 1);
                return buttons;
                /*
                return [
    
                    {
                        title: 'Excel',
                        onViewSubmit: () => this.onViewSubmit(), service: VHopDongTrangThaiService.baseUrl + '/ListExcel',
                        separator: true
                    },
                    {
                        title: 'Group By SoHd',
                        cssClass: 'expand-all-button',
                        onClick: () => this.view.setGrouping(
                            [{
                                getter: 'SoHd'
                            }])
                    },
                    {
                        title: 'Group By SoHd and product',
                        cssClass: 'expand-all-button',
                        onClick: () => this.view.setGrouping(
                            [{
                                formatter: x => 'Contract: ' + x.value + ' (' + x.count + ' items)',
                                getter: 'SoHd'
                            }, {
                                    formatter: x => ': ' + x.value + ' (' + x.count + ' items)',
                                    getter: 'MotaBtp'
                                }])
                    },
                    {
                        title: 'No Grouping',
                        cssClass: 'collapse-all-button',
                        onClick: () => this.view.setGrouping([])
                    }];
                */
            };
            VHopDongTrangThaiGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], VHopDongTrangThaiGrid);
            return VHopDongTrangThaiGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.VHopDongTrangThaiGrid = VHopDongTrangThaiGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VLenChuyenChiTietDialog = /** @class */ (function (_super) {
            __extends(VLenChuyenChiTietDialog, _super);
            function VLenChuyenChiTietDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.VLenChuyenChiTietForm(_this.idPrefix);
                return _this;
            }
            VLenChuyenChiTietDialog.prototype.getFormKey = function () { return SpringPrintingConnection.VLenChuyenChiTietForm.formKey; };
            VLenChuyenChiTietDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.VLenChuyenChiTietRow.idProperty; };
            VLenChuyenChiTietDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.VLenChuyenChiTietRow.localTextPrefix; };
            VLenChuyenChiTietDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.VLenChuyenChiTietRow.nameProperty; };
            VLenChuyenChiTietDialog.prototype.getService = function () { return SpringPrintingConnection.VLenChuyenChiTietService.baseUrl; };
            VLenChuyenChiTietDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], VLenChuyenChiTietDialog);
            return VLenChuyenChiTietDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.VLenChuyenChiTietDialog = VLenChuyenChiTietDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VLenChuyenChiTietGrid = /** @class */ (function (_super) {
            __extends(VLenChuyenChiTietGrid, _super);
            function VLenChuyenChiTietGrid(container) {
                return _super.call(this, container) || this;
            }
            VLenChuyenChiTietGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.VLenChuyenChiTiet'; };
            VLenChuyenChiTietGrid.prototype.getDialogType = function () { return SpringPrintingConnection.VLenChuyenChiTietDialog; };
            VLenChuyenChiTietGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.VLenChuyenChiTietRow.idProperty; };
            VLenChuyenChiTietGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.VLenChuyenChiTietRow.localTextPrefix; };
            VLenChuyenChiTietGrid.prototype.getService = function () { return SpringPrintingConnection.VLenChuyenChiTietService.baseUrl; };
            VLenChuyenChiTietGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], VLenChuyenChiTietGrid);
            return VLenChuyenChiTietGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.VLenChuyenChiTietGrid = VLenChuyenChiTietGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VLoSpKhDialog = /** @class */ (function (_super) {
            __extends(VLoSpKhDialog, _super);
            function VLoSpKhDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.VLoSpKhForm(_this.idPrefix);
                return _this;
            }
            VLoSpKhDialog.prototype.getFormKey = function () { return SpringPrintingConnection.VLoSpKhForm.formKey; };
            VLoSpKhDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.VLoSpKhRow.idProperty; };
            VLoSpKhDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.VLoSpKhRow.localTextPrefix; };
            VLoSpKhDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.VLoSpKhRow.nameProperty; };
            VLoSpKhDialog.prototype.getService = function () { return SpringPrintingConnection.VLoSpKhService.baseUrl; };
            VLoSpKhDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], VLoSpKhDialog);
            return VLoSpKhDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.VLoSpKhDialog = VLoSpKhDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VLoSpKhGrid = /** @class */ (function (_super) {
            __extends(VLoSpKhGrid, _super);
            function VLoSpKhGrid(container) {
                return _super.call(this, container) || this;
            }
            VLoSpKhGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.VLoSpKh'; };
            VLoSpKhGrid.prototype.getDialogType = function () { return SpringPrintingConnection.VLoSpKhDialog; };
            VLoSpKhGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.VLoSpKhRow.idProperty; };
            VLoSpKhGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.VLoSpKhRow.localTextPrefix; };
            VLoSpKhGrid.prototype.getService = function () { return SpringPrintingConnection.VLoSpKhService.baseUrl; };
            VLoSpKhGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], VLoSpKhGrid);
            return VLoSpKhGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.VLoSpKhGrid = VLoSpKhGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VNhapKhoSpDialog = /** @class */ (function (_super) {
            __extends(VNhapKhoSpDialog, _super);
            function VNhapKhoSpDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.VNhapKhoSpForm(_this.idPrefix);
                return _this;
            }
            VNhapKhoSpDialog.prototype.getFormKey = function () { return SpringPrintingConnection.VNhapKhoSpForm.formKey; };
            VNhapKhoSpDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.VNhapKhoSpRow.idProperty; };
            VNhapKhoSpDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.VNhapKhoSpRow.localTextPrefix; };
            VNhapKhoSpDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.VNhapKhoSpRow.nameProperty; };
            VNhapKhoSpDialog.prototype.getService = function () { return SpringPrintingConnection.VNhapKhoSpService.baseUrl; };
            VNhapKhoSpDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], VNhapKhoSpDialog);
            return VNhapKhoSpDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.VNhapKhoSpDialog = VNhapKhoSpDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VNhapKhoSpGrid = /** @class */ (function (_super) {
            __extends(VNhapKhoSpGrid, _super);
            function VNhapKhoSpGrid(container) {
                return _super.call(this, container) || this;
            }
            VNhapKhoSpGrid.prototype.getColumnsKey = function () { return 'SpringPrintingConnection.VNhapKhoSp'; };
            VNhapKhoSpGrid.prototype.getDialogType = function () { return SpringPrintingConnection.VNhapKhoSpDialog; };
            VNhapKhoSpGrid.prototype.getIdProperty = function () { return SpringPrintingConnection.VNhapKhoSpRow.idProperty; };
            VNhapKhoSpGrid.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.VNhapKhoSpRow.localTextPrefix; };
            VNhapKhoSpGrid.prototype.getService = function () { return SpringPrintingConnection.VNhapKhoSpService.baseUrl; };
            VNhapKhoSpGrid = __decorate([
                Serenity.Decorators.filterable(),
                Serenity.Decorators.registerClass()
            ], VNhapKhoSpGrid);
            return VNhapKhoSpGrid;
        }(Serenity.EntityGrid));
        SpringPrintingConnection.VNhapKhoSpGrid = VNhapKhoSpGrid;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SpringPrintingConnection;
    (function (SpringPrintingConnection) {
        var VTrangThaiBoBtpDialog = /** @class */ (function (_super) {
            __extends(VTrangThaiBoBtpDialog, _super);
            function VTrangThaiBoBtpDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new SpringPrintingConnection.VTrangThaiBoBtpForm(_this.idPrefix);
                return _this;
            }
            VTrangThaiBoBtpDialog.prototype.getFormKey = function () { return SpringPrintingConnection.VTrangThaiBoBtpForm.formKey; };
            VTrangThaiBoBtpDialog.prototype.getIdProperty = function () { return SpringPrintingConnection.VTrangThaiBoBtpRow.idProperty; };
            VTrangThaiBoBtpDialog.prototype.getLocalTextPrefix = function () { return SpringPrintingConnection.VTrangThaiBoBtpRow.localTextPrefix; };
            VTrangThaiBoBtpDialog.prototype.getNameProperty = function () { return SpringPrintingConnection.VTrangThaiBoBtpRow.nameProperty; };
            VTrangThaiBoBtpDialog.prototype.getService = function () { return SpringPrintingConnection.VTrangThaiBoBtpService.baseUrl; };
            VTrangThaiBoBtpDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], VTrangThaiBoBtpDialog);
            return VTrangThaiBoBtpDialog;
        }(Serenity.EntityDialog));
        SpringPrintingConnection.VTrangThaiBoBtpDialog = VTrangThaiBoBtpDialog;
    })(SpringPrintingConnection = Serene3.SpringPrintingConnection || (Serene3.SpringPrintingConnection = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Authorization;
    (function (Authorization) {
        Object.defineProperty(Authorization, 'userDefinition', {
            get: function () {
                return Q.getRemoteData('UserData');
            }
        });
        function hasPermission(permissionKey) {
            var ud = Authorization.userDefinition;
            return ud.Username === 'admin' || !!ud.Permissions[permissionKey];
        }
        Authorization.hasPermission = hasPermission;
    })(Authorization = Serene3.Authorization || (Serene3.Authorization = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var ChartInDialog = /** @class */ (function (_super) {
            __extends(ChartInDialog, _super);
            function ChartInDialog() {
                return _super !== null && _super.apply(this, arguments) || this;
            }
            ChartInDialog_1 = ChartInDialog;
            ChartInDialog.initializePage = function () {
                $(function () {
                    $('#LaunchDialogButton').click(function (e) {
                        (new ChartInDialog_1()).dialogOpen();
                    });
                });
            };
            ChartInDialog.prototype.onDialogOpen = function () {
                var _this = this;
                _super.prototype.onDialogOpen.call(this);
                BasicSamples.BasicSamplesService.OrdersByShipper({}, function (response) {
                    _this.areaChart = new Morris.Area({
                        element: _this.idPrefix + 'Chart',
                        resize: true, parseTime: false,
                        data: response.Values,
                        xkey: 'Month',
                        ykeys: response.ShipperKeys, labels: response.ShipperLabels, hideHover: 'auto'
                    });
                });
            };
            ChartInDialog.prototype.arrange = function () {
                _super.prototype.arrange.call(this);
                this.areaChart && this.areaChart.redraw();
            };
            ChartInDialog.prototype.getTemplate = function () {
                // you could also put this in a ChartInDialog.Template.html file. it's here for simplicity.
                return "<div id='~_Chart'></div>";
            };
            ChartInDialog.prototype.getDialogOptions = function () {
                var opt = _super.prototype.getDialogOptions.call(this);
                opt.title = 'Orders by Shipper';
                return opt;
            };
            ChartInDialog = ChartInDialog_1 = __decorate([
                Serenity.Decorators.registerClass(),
                Serenity.Decorators.resizable(),
                Serenity.Decorators.maximizable()
            ], ChartInDialog);
            return ChartInDialog;
            var ChartInDialog_1;
        }(Serenity.TemplatedDialog));
        BasicSamples.ChartInDialog = ChartInDialog;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Product/ProductDialog.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var CloneableEntityDialog = /** @class */ (function (_super) {
            __extends(CloneableEntityDialog, _super);
            function CloneableEntityDialog() {
                return _super !== null && _super.apply(this, arguments) || this;
            }
            CloneableEntityDialog.prototype.updateInterface = function () {
                // by default cloneButton is hidden in base UpdateInterface method
                _super.prototype.updateInterface.call(this);
                // here we show it if it is edit mode (not new)
                this.cloneButton.toggle(this.isEditMode());
            };
            /**
             * Overriding this method is optional to customize cloned entity
             */
            CloneableEntityDialog.prototype.getCloningEntity = function () {
                var clone = _super.prototype.getCloningEntity.call(this);
                // add (Clone) suffix if it's not already added
                var suffix = ' (Clone)';
                if (!Q.endsWith(clone.ProductName || '', suffix)) {
                    clone.ProductName = (clone.ProductName || '') + suffix;
                }
                // it's better to clear image for this sample
                // otherwise we would have to create a temporary copy of it
                // and upload
                clone.ProductImage = null;
                // let's clear fields not logical to be cloned
                clone.UnitsInStock = 0;
                clone.UnitsOnOrder = 0;
                return clone;
            };
            CloneableEntityDialog = __decorate([
                Serenity.Decorators.registerClass(),
                Serenity.Decorators.maximizable()
            ], CloneableEntityDialog);
            return CloneableEntityDialog;
        }(Serene3.Northwind.ProductDialog));
        BasicSamples.CloneableEntityDialog = CloneableEntityDialog;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Product/ProductGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        /**
         * Subclass of ProductGrid to override dialog type to CloneableEntityDialog
         */
        var CloneableEntityGrid = /** @class */ (function (_super) {
            __extends(CloneableEntityGrid, _super);
            function CloneableEntityGrid(container) {
                return _super.call(this, container) || this;
            }
            CloneableEntityGrid.prototype.getDialogType = function () { return BasicSamples.CloneableEntityDialog; };
            CloneableEntityGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], CloneableEntityGrid);
            return CloneableEntityGrid;
        }(Serene3.Northwind.ProductGrid));
        BasicSamples.CloneableEntityGrid = CloneableEntityGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Order/OrderGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var DefaultValuesInNewGrid = /** @class */ (function (_super) {
            __extends(DefaultValuesInNewGrid, _super);
            function DefaultValuesInNewGrid(container) {
                return _super.call(this, container) || this;
            }
            /**
             * This method is called when New Item button is clicked.
             * By default, it calls EditItem with an empty entity.
             * This is a good place to fill in default values for New Item button.
             */
            DefaultValuesInNewGrid.prototype.addButtonClick = function () {
                this.editItem({
                    CustomerID: 'ANTON',
                    RequiredDate: Q.formatDate(new Date(), 'yyyy-MM-dd'),
                    EmployeeID: Serene3.Northwind.EmployeeRow.getLookup().items
                        .filter(function (x) { return x.FullName === 'Robert King'; })[0].EmployeeID,
                    ShipVia: Serene3.Northwind.ShipperRow.getLookup().items
                        .filter(function (x) { return x.CompanyName === 'Speedy Express'; })[0].ShipperID
                });
            };
            DefaultValuesInNewGrid.prototype.getButtons = function () {
                var _this = this;
                // preserving default New Item button
                var buttons = _super.prototype.getButtons.call(this);
                buttons.push({
                    title: 'Add Order from the Queen',
                    cssClass: 'add-button',
                    onClick: function () {
                        // using EditItem method as a shortcut to create a new Order dialog,
                        // bind to its events, load our order row, and open dialog
                        _this.editItem({
                            CustomerID: 'QUEEN',
                            EmployeeID: Serene3.Northwind.EmployeeRow.getLookup().items
                                .filter(function (x) { return x.FullName === 'Nancy Davolio'; })[0].EmployeeID,
                            ShipVia: Serene3.Northwind.ShipperRow.getLookup().items
                                .filter(function (x) { return x.CompanyName === 'United Package'; })[0].ShipperID
                        });
                    }
                });
                buttons.push({
                    title: 'Add Order with 5 Chai by Laura', cssClass: 'add-note-button',
                    onClick: function () {
                        // we could use EditItem here too, but for demonstration
                        // purposes we are manually creating dialog this time
                        var dlg = new Serene3.Northwind.OrderDialog();
                        // let grid watch for changes to manually created dialog, 
                        // so when a new item is saved, grid can refresh itself
                        _this.initDialog(dlg);
                        // get a reference to product Chai
                        var chai = Serene3.Northwind.ProductRow.getLookup().items
                            .filter(function (x) { return x.ProductName === 'Chai'; })[0];
                        // LoadEntityAndOpenDialog, loads an OrderRow 
                        // to dialog and opens it
                        var lauraCallahanID = Serene3.Northwind.EmployeeRow.getLookup().items
                            .filter(function (x) { return x.FullName === 'Laura Callahan'; })[0].EmployeeID;
                        dlg.loadEntityAndOpenDialog({
                            CustomerID: 'GOURL',
                            EmployeeID: lauraCallahanID,
                            DetailList: [{
                                    ProductID: chai.ProductID,
                                    ProductName: chai.ProductName,
                                    UnitPrice: chai.UnitPrice,
                                    Quantity: 5,
                                    LineTotal: chai.UnitPrice * 5
                                }]
                        });
                    }
                });
                return buttons;
            };
            DefaultValuesInNewGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], DefaultValuesInNewGrid);
            return DefaultValuesInNewGrid;
        }(Serene3.Northwind.OrderGrid));
        BasicSamples.DefaultValuesInNewGrid = DefaultValuesInNewGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var DialogBoxes;
        (function (DialogBoxes) {
            function initializePage() {
                confirmDialogButtons();
                confirmWithCustomTitle();
                information();
                warning();
                alert();
                alertWithHtmlContent();
            }
            DialogBoxes.initializePage = initializePage;
            function confirmDialogButtons() {
                // here we demonstrate how you can detect which button user has clicked
                // second parameter is Yes handler and it is called only when user clicks Yes.
                // third parameter has some additional options, that you should only use when needed
                $('#ConfirmDialogButtons').click(function () {
                    Q.confirm("Click one of buttons, or close dialog with [x] on top right, i'll tell you what you did!", function () {
                        Q.notifySuccess("You clicked YES. Great!");
                    }, {
                        onNo: function () {
                            Q.notifyInfo("You clicked NO. Why?");
                        },
                        onCancel: function () {
                            Q.notifyError("You clicked X. Operation is cancelled. Will try again?");
                        }
                    });
                });
            }
            function confirmWithCustomTitle() {
                $('#ConfirmWithCustomTitle').click(function () {
                    Q.confirm("This confirmation has a custom title", function () {
                        Q.notifySuccess("Allright!");
                    }, {
                        title: 'Some Custom Confirmation Title'
                    });
                });
            }
            function information() {
                $('#Information').click(function () {
                    Q.information("What a nice day", function () {
                        Q.notifySuccess("No problem!");
                    });
                });
            }
            function warning() {
                $('#Warning').click(function () {
                    Q.warning("Hey, be careful!");
                });
            }
            function alert() {
                $('#Alert').click(function () {
                    Q.alert("Houston, we got a problem!");
                });
            }
            function alertWithHtmlContent() {
                $('#AlertWithHtmlContent').click(function () {
                    Q.alert("<h4>Here is some HTML content!</h4>" +
                        "<ul><li>Item 1</li><li>Item 2</li >" +
                        "<li>Visit <a href='http://serenity.is/' target='_blank' style='color: #ddf'>http://serenity.is/</a>!</li></ul>", {
                        htmlEncode: false
                    });
                });
            }
        })(DialogBoxes = BasicSamples.DialogBoxes || (BasicSamples.DialogBoxes = {}));
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Order/OrderDialog.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        /**
         * A version of order dialog converted to a panel by adding Serenity.Decorators.panel decorator.
         */
        var EntityDialogAsPanel = /** @class */ (function (_super) {
            __extends(EntityDialogAsPanel, _super);
            function EntityDialogAsPanel() {
                return _super.call(this) || this;
            }
            EntityDialogAsPanel.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                this.deleteButton.hide();
                this.applyChangesButton.hide();
            };
            EntityDialogAsPanel.prototype.onSaveSuccess = function (response) {
                this.showSaveSuccessMessage(response);
            };
            EntityDialogAsPanel = __decorate([
                Serenity.Decorators.panel()
            ], EntityDialogAsPanel);
            return EntityDialogAsPanel;
        }(Serene3.Northwind.OrderDialog));
        BasicSamples.EntityDialogAsPanel = EntityDialogAsPanel;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Category/CategoryDialog.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var GetInsertedRecordIdDialog = /** @class */ (function (_super) {
            __extends(GetInsertedRecordIdDialog, _super);
            function GetInsertedRecordIdDialog() {
                return _super !== null && _super.apply(this, arguments) || this;
            }
            /**
             * This method is called after the save request to service
             * is completed succesfully. This can be an insert or update.
             *
             * @param response Response that is returned from server
             */
            GetInsertedRecordIdDialog.prototype.onSaveSuccess = function (response) {
                // check that this is an insert
                if (this.isNew()) {
                    Q.notifySuccess("Just inserted a category with ID: " + response.EntityId);
                    // you could also open a new dialog
                    // new Northwind.CategoryDialog().loadByIdAndOpenDialog(response.EntityId);
                    // but let's better load inserted record using Retrieve service
                    Serene3.Northwind.CategoryService.Retrieve({
                        EntityId: response.EntityId
                    }, function (resp) {
                        Q.notifyInfo("Looks like the category you added has name: " + resp.Entity.CategoryName);
                    });
                }
            };
            GetInsertedRecordIdDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], GetInsertedRecordIdDialog);
            return GetInsertedRecordIdDialog;
        }(Serene3.Northwind.CategoryDialog));
        BasicSamples.GetInsertedRecordIdDialog = GetInsertedRecordIdDialog;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Category/CategoryGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        /**
         * Subclass of CategoryGrid to override dialog type to GetInsertedRecordIdDialog
         */
        var GetInsertedRecordIdGrid = /** @class */ (function (_super) {
            __extends(GetInsertedRecordIdGrid, _super);
            function GetInsertedRecordIdGrid(container) {
                return _super.call(this, container) || this;
            }
            GetInsertedRecordIdGrid.prototype.getDialogType = function () { return BasicSamples.GetInsertedRecordIdDialog; };
            GetInsertedRecordIdGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], GetInsertedRecordIdGrid);
            return GetInsertedRecordIdGrid;
        }(Serene3.Northwind.CategoryGrid));
        BasicSamples.GetInsertedRecordIdGrid = GetInsertedRecordIdGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Order/OrderDialog.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        /**
         * Our custom order dialog subclass that will have a tab to display and edit selected customer details.
         */
        var OtherFormInTabDialog = /** @class */ (function (_super) {
            __extends(OtherFormInTabDialog, _super);
            function OtherFormInTabDialog() {
                var _this = _super.call(this) || this;
                // entity dialogs by default creates a property grid on element with ID "PropertyGrid".
                // here we explicitly create another, the customer property grid (vertical form) on element with ID "CustomerPropertyGrid".
                _this.customerPropertyGrid = new Serenity.PropertyGrid(_this.byId("CustomerPropertyGrid"), {
                    idPrefix: _this.idPrefix + "_Customer_",
                    items: Q.getForm(Serene3.Northwind.CustomerForm.formKey).filter(function (x) { return x.name != 'CustomerID'; }),
                    useCategories: true
                });
                // this is just a helper to access editors if needed
                _this.customerForm = new Serene3.Northwind.CustomerForm(_this.customerPropertyGrid.idPrefix);
                // initialize validator for customer form
                _this.customerValidator = _this.byId("CustomerForm").validate(Q.validateOptions({}));
                var selfChange = 0;
                // creating another toolbar for customer tab that will only save Customer
                new Serenity.Toolbar(_this.byId("CustomerToolbar"), {
                    buttons: [{
                            cssClass: "apply-changes-button",
                            title: Q.text("Controls.EntityDialog.SaveButton"),
                            onClick: function () {
                                var id = _this.getCustomerID();
                                if (!id)
                                    return;
                                if (!_this.customerValidator.form())
                                    return;
                                // prepare an empty entity to serialize customer details into
                                var c = {};
                                _this.customerPropertyGrid.save(c);
                                Serene3.Northwind.CustomerService.Update({
                                    EntityId: id,
                                    Entity: c
                                }, function (response) {
                                    // reload customer list just in case
                                    Q.reloadLookup(Serene3.Northwind.CustomerRow.lookupKey);
                                    // set flag that we are triggering customer select change event
                                    // otherwise active tab will change to first one
                                    selfChange++;
                                    try {
                                        // trigger change so that customer select updates its text
                                        // in case if Company Name is changed
                                        _this.form.CustomerID.element.change();
                                    }
                                    finally {
                                        selfChange--;
                                    }
                                    Q.notifySuccess("Saved customer details");
                                });
                            }
                        }]
                });
                _this.form.CustomerID.change(function (e) {
                    if (selfChange)
                        return;
                    var customerID = _this.getCustomerID();
                    Serenity.TabsExtensions.setDisabled(_this.tabs, 'Customer', !customerID);
                    if (!customerID) {
                        // no customer is selected, just load an empty entity
                        _this.customerPropertyGrid.load({});
                        return;
                    }
                    // load selected customer into customer form by calling CustomerService
                    Serene3.Northwind.CustomerService.Retrieve({
                        EntityId: customerID
                    }, function (response) {
                        _this.customerPropertyGrid.load(response.Entity);
                    });
                });
                return _this;
            }
            OtherFormInTabDialog.prototype.getCustomerID = function () {
                var customerID = this.form.CustomerID.value;
                if (Q.isEmptyOrNull(customerID))
                    return null;
                // unfortunately, CustomerID (a string) used in this form and 
                // the ID (auto increment ID) are different, so we need to 
                // find numeric ID from customer lookups. 
                // you'll probably won't need this step.
                return Q.first(Serene3.Northwind.CustomerRow.getLookup().items, function (x) { return x.CustomerID == customerID; }).ID;
            };
            OtherFormInTabDialog.prototype.loadEntity = function (entity) {
                _super.prototype.loadEntity.call(this, entity);
                Serenity.TabsExtensions.setDisabled(this.tabs, 'Customer', !this.getCustomerID());
            };
            OtherFormInTabDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], OtherFormInTabDialog);
            return OtherFormInTabDialog;
        }(Serene3.Northwind.OrderDialog));
        BasicSamples.OtherFormInTabDialog = OtherFormInTabDialog;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Order/OrderGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        /**
         * Subclass of OrderGrid to override dialog type to OtherFormInTabDialog
         */
        var OtherFormInTabGrid = /** @class */ (function (_super) {
            __extends(OtherFormInTabGrid, _super);
            function OtherFormInTabGrid(container) {
                return _super.call(this, container) || this;
            }
            OtherFormInTabGrid.prototype.getDialogType = function () { return BasicSamples.OtherFormInTabDialog; };
            OtherFormInTabGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], OtherFormInTabGrid);
            return OtherFormInTabGrid;
        }(Serene3.Northwind.OrderGrid));
        BasicSamples.OtherFormInTabGrid = OtherFormInTabGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Order/OrderDialog.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        /**
         * Our custom order dialog subclass that will have a tab to display and edit selected customer details.
         * With single toolbar for all forms
         */
        var OtherFormOneBarDialog = /** @class */ (function (_super) {
            __extends(OtherFormOneBarDialog, _super);
            function OtherFormOneBarDialog() {
                var _this = _super.call(this) || this;
                _this.selfChange = 0;
                // entity dialogs by default creates a property grid on element with ID "PropertyGrid".
                // here we explicitly create another, the customer property grid (vertical form) on element with ID "CustomerPropertyGrid".
                _this.customerPropertyGrid = new Serenity.PropertyGrid(_this.byId("CustomerPropertyGrid"), {
                    items: Q.getForm(Serene3.Northwind.CustomerForm.formKey).filter(function (x) { return x.name != 'CustomerID'; }),
                    idPrefix: _this.idPrefix + "_Customer_",
                    useCategories: true
                });
                // this is just a helper to access editors if needed
                _this.customerForm = new Serene3.Northwind.CustomerForm(_this.customerPropertyGrid.idPrefix);
                // initialize validator for customer form
                _this.customerValidator = _this.byId("CustomerForm").validate(Q.validateOptions({}));
                _this.form.CustomerID.change(function (e) {
                    if (_this.selfChange)
                        return;
                    var customerID = _this.getCustomerID();
                    Serenity.TabsExtensions.setDisabled(_this.tabs, 'Customer', !customerID);
                    if (!customerID) {
                        // no customer is selected, just load an empty entity
                        _this.customerPropertyGrid.load({});
                        return;
                    }
                    // load selected customer into customer form by calling CustomerService
                    Serene3.Northwind.CustomerService.Retrieve({
                        EntityId: customerID
                    }, function (response) {
                        _this.customerPropertyGrid.load(response.Entity);
                    });
                });
                return _this;
            }
            OtherFormOneBarDialog.prototype.getCustomerID = function () {
                var customerID = this.form.CustomerID.value;
                if (Q.isEmptyOrNull(customerID))
                    return null;
                // unfortunately, CustomerID (a string) used in this form and 
                // the ID (auto increment ID) are different, so we need to 
                // find numeric ID from customer lookups. 
                // you'll probably won't need this step.
                return Q.first(Serene3.Northwind.CustomerRow.getLookup().items, function (x) { return x.CustomerID == customerID; }).ID;
            };
            OtherFormOneBarDialog.prototype.loadEntity = function (entity) {
                _super.prototype.loadEntity.call(this, entity);
                Serenity.TabsExtensions.setDisabled(this.tabs, 'Customer', !this.getCustomerID());
            };
            // Save the customer and the order 
            OtherFormOneBarDialog.prototype.saveCustomer = function (callback, onSuccess) {
                var _this = this;
                var id = this.getCustomerID();
                if (!id) {
                    // If id of Customer isn't present, we save only Order entity
                    onSuccess(null);
                }
                else {
                    // Get current tab
                    var currTab = Serenity.TabsExtensions.activeTabKey(this.tabs);
                    // Select the correct tab and validate to see the error message in tab
                    Serenity.TabsExtensions.selectTab(this.tabs, "Customer");
                    if (!this.customerValidator.form()) {
                        return false;
                    }
                    // Re-select initial tab
                    Serenity.TabsExtensions.selectTab(this.tabs, currTab);
                    // prepare an empty entity to serialize customer details into
                    var c = {};
                    this.customerPropertyGrid.save(c);
                    Serene3.Northwind.CustomerService.Update({
                        EntityId: id,
                        Entity: c
                    }, function (response) {
                        // reload customer list just in case
                        Q.reloadLookup(Serene3.Northwind.CustomerRow.lookupKey);
                        // set flag that we are triggering customer select change event
                        // otherwise active tab will change to first one
                        _this.selfChange++;
                        try {
                            // trigger change so that customer select updates its text
                            // in case if Company Name is changed
                            _this.form.CustomerID.element.change();
                        }
                        finally {
                            _this.selfChange--;
                        }
                        onSuccess(response);
                    });
                }
                return true;
            };
            // Call super.save to save Order entity
            OtherFormOneBarDialog.prototype.saveOrder = function (callback) {
                _super.prototype.save.call(this, callback);
            };
            OtherFormOneBarDialog.prototype.saveAll = function (callback) {
                var _this = this;
                this.saveCustomer(callback, 
                // If customer successa, save Order entity
                function (resp) { return _this.saveOrder(callback); });
            };
            // This is called when save/update button is pressed
            OtherFormOneBarDialog.prototype.save = function (callback) {
                this.saveAll(callback);
            };
            OtherFormOneBarDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], OtherFormOneBarDialog);
            return OtherFormOneBarDialog;
        }(Serene3.Northwind.OrderDialog));
        BasicSamples.OtherFormOneBarDialog = OtherFormOneBarDialog;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Order/OrderGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        /**
         * Subclass of OrderGrid to override dialog type to OtherFormInTabOneBarDialog
         */
        var OtherFormInTabOneBarGrid = /** @class */ (function (_super) {
            __extends(OtherFormInTabOneBarGrid, _super);
            function OtherFormInTabOneBarGrid(container) {
                return _super.call(this, container) || this;
            }
            OtherFormInTabOneBarGrid.prototype.getDialogType = function () { return BasicSamples.OtherFormOneBarDialog; };
            OtherFormInTabOneBarGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], OtherFormInTabOneBarGrid);
            return OtherFormInTabOneBarGrid;
        }(Serene3.Northwind.OrderGrid));
        BasicSamples.OtherFormInTabOneBarGrid = OtherFormInTabOneBarGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var PopulateLinkedDataDialog = /** @class */ (function (_super) {
            __extends(PopulateLinkedDataDialog, _super);
            function PopulateLinkedDataDialog() {
                var _this = _super.call(this) || this;
                _this.form = new BasicSamples.PopulateLinkedDataForm(_this.idPrefix);
                // "changeSelect2" is only fired when user changes the selection
                // but "change" is fired when dialog sets customer on load too
                // so we prefer "changeSelect2", as initial customer details 
                // will get populated by initial load, we don't want extra call
                _this.form.CustomerID.changeSelect2(function (e) {
                    var customerID = _this.form.CustomerID.value;
                    if (Q.isEmptyOrNull(customerID)) {
                        _this.setCustomerDetails({});
                        return;
                    }
                    // in northwind CustomerID is a string like "ALFKI", 
                    // while its actual integer ID value is 1.
                    // so we need to convert customer ID to ID.
                    // you won't have to do this conversion with your tables
                    var id = Q.first(Serene3.Northwind.CustomerRow.getLookup().items, function (x) { return x.CustomerID == customerID; }).ID;
                    Serene3.Northwind.CustomerService.Retrieve({
                        EntityId: id
                    }, function (response) {
                        _this.setCustomerDetails(response.Entity);
                    });
                });
                return _this;
            }
            PopulateLinkedDataDialog.prototype.getFormKey = function () { return BasicSamples.PopulateLinkedDataForm.formKey; };
            PopulateLinkedDataDialog.prototype.getIdProperty = function () { return Serene3.Northwind.OrderRow.idProperty; };
            PopulateLinkedDataDialog.prototype.getLocalTextPrefix = function () { return Serene3.Northwind.OrderRow.localTextPrefix; };
            PopulateLinkedDataDialog.prototype.getNameProperty = function () { return Serene3.Northwind.OrderRow.nameProperty; };
            PopulateLinkedDataDialog.prototype.getService = function () { return Serene3.Northwind.OrderService.baseUrl; };
            PopulateLinkedDataDialog.prototype.setCustomerDetails = function (details) {
                this.form.CustomerCity.value = details.City;
                this.form.CustomerContactName.value = details.ContactName;
                this.form.CustomerContactTitle.value = details.ContactTitle;
                this.form.CustomerCountry.value = details.Country;
                this.form.CustomerFax.value = details.Fax;
                this.form.CustomerPhone.value = details.Phone;
                this.form.CustomerRegion.value = details.Region;
            };
            /**
             * This dialog will have CSS class "s-PopulateLinkedDataDialog"
             * We are changing it here to "s-OrderDialog", to make it use default OrderDialog styles
             * This has no effect other than looks on populate linked data demonstration
             */
            PopulateLinkedDataDialog.prototype.getCssClass = function () {
                return _super.prototype.getCssClass.call(this) + " s-OrderDialog s-Northwind-OrderDialog";
            };
            PopulateLinkedDataDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], PopulateLinkedDataDialog);
            return PopulateLinkedDataDialog;
        }(Serenity.EntityDialog));
        BasicSamples.PopulateLinkedDataDialog = PopulateLinkedDataDialog;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Order/OrderGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        /**
         * A subclass of OrderGrid that launches PopulateLinkedDataDialog
         */
        var PopulateLinkedDataGrid = /** @class */ (function (_super) {
            __extends(PopulateLinkedDataGrid, _super);
            function PopulateLinkedDataGrid(container) {
                return _super.call(this, container) || this;
            }
            PopulateLinkedDataGrid.prototype.getDialogType = function () { return BasicSamples.PopulateLinkedDataDialog; };
            PopulateLinkedDataGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], PopulateLinkedDataGrid);
            return PopulateLinkedDataGrid;
        }(Serene3.Northwind.OrderGrid));
        BasicSamples.PopulateLinkedDataGrid = PopulateLinkedDataGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Supplier/SupplierDialog.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var ReadOnlyDialog = /** @class */ (function (_super) {
            __extends(ReadOnlyDialog, _super);
            function ReadOnlyDialog() {
                return _super !== null && _super.apply(this, arguments) || this;
            }
            /**
             * This is the method that gets list of tool
             * buttons to be created in a dialog.
             *
             * Here we'll remove save and close button, and
             * apply changes buttons.
             */
            ReadOnlyDialog.prototype.getToolbarButtons = function () {
                var buttons = _super.prototype.getToolbarButtons.call(this);
                buttons.splice(Q.indexOf(buttons, function (x) { return x.cssClass == "save-and-close-button"; }), 1);
                buttons.splice(Q.indexOf(buttons, function (x) { return x.cssClass == "apply-changes-button"; }), 1);
                // We could also remove delete button here, but for demonstration 
                // purposes we'll hide it in another method (updateInterface)
                // buttons.splice(Q.indexOf(buttons, x => x.cssClass == "delete-button"), 1);
                return buttons;
            };
            /**
             * This method is a good place to update states of
             * interface elements. It is called after dialog
             * is initialized and an entity is loaded into dialog.
             * This is also called in new item mode.
             */
            ReadOnlyDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                // finding all editor elements and setting their readonly attribute
                // note that this helper method only works with basic inputs, 
                // some editors require widget based set readonly overload (setReadOnly)
                Serenity.EditorUtils.setReadonly(this.element.find('.editor'), true);
                // remove required asterisk (*)
                this.element.find('sup').hide();
                // here is a way to locate a button by its css class
                // note that this method is not available in 
                // getToolbarButtons() because buttons are not 
                // created there yet!
                // 
                // this.toolbar.findButton('delete-button').hide();
                // entity dialog also has reference variables to
                // its default buttons, lets use them to hide delete button
                this.deleteButton.hide();
                // we could also hide save buttons just like delete button,
                // but they are null now as we removed them in getToolbarButtons()
                // if we didn't we could write like this:
                // 
                // this.applyChangesButton.hide();
                // this.saveAndCloseButton.hide();
                // instead of hiding, we could disable a button
                // 
                // this.deleteButton.toggleClass('disabled', true);
            };
            /**
             * This method is called when dialog title needs to be updated.
             * Base class returns something like 'Edit xyz' for edit mode,
             * and 'New xyz' for new record mode.
             *
             * But our dialog is readonly, so we should change it to 'View xyz'
             */
            ReadOnlyDialog.prototype.getEntityTitle = function () {
                if (!this.isEditMode()) {
                    // we shouldn't hit here, but anyway for demo...
                    return "How did you manage to open this dialog in new record mode?";
                }
                else {
                    // entitySingular is type of record this dialog edits. something like 'Supplier'.
                    // you could hardcode it, but this is for demonstration
                    var entityType = _super.prototype.getEntitySingular.call(this);
                    // get name field value of record this dialog edits
                    var name_1 = this.getEntityNameFieldValue() || "";
                    // you could use Q.format with a local text, but again demo...
                    return 'View ' + entityType + " (" + name_1 + ")";
                }
            };
            /**
             * This method is actually the one that calls getEntityTitle()
             * and updates the dialog title. We could do it here too...
             */
            ReadOnlyDialog.prototype.updateTitle = function () {
                _super.prototype.updateTitle.call(this);
                // remove super.updateTitle() call above and uncomment 
                // below line if you'd like to use this version
                // 
                // this.dialogTitle = 'View Supplier (' + this.getEntityNameFieldValue() + ')';
            };
            ReadOnlyDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], ReadOnlyDialog);
            return ReadOnlyDialog;
        }(Serene3.Northwind.SupplierDialog));
        BasicSamples.ReadOnlyDialog = ReadOnlyDialog;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Supplier/SupplierGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        /**
         * A readonly grid that launches ReadOnlyDialog
         */
        var ReadOnlyGrid = /** @class */ (function (_super) {
            __extends(ReadOnlyGrid, _super);
            function ReadOnlyGrid(container) {
                return _super.call(this, container) || this;
            }
            ReadOnlyGrid.prototype.getDialogType = function () { return BasicSamples.ReadOnlyDialog; };
            /**
             * Removing add button from grid using its css class
             */
            ReadOnlyGrid.prototype.getButtons = function () {
                var buttons = _super.prototype.getButtons.call(this);
                buttons.splice(Q.indexOf(buttons, function (x) { return x.cssClass == "add-button"; }), 1);
                return buttons;
            };
            ReadOnlyGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], ReadOnlyGrid);
            return ReadOnlyGrid;
        }(Serene3.Northwind.SupplierGrid));
        BasicSamples.ReadOnlyGrid = ReadOnlyGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Customer/CustomerDialog.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var SerialAutoNumberDialog = /** @class */ (function (_super) {
            __extends(SerialAutoNumberDialog, _super);
            function SerialAutoNumberDialog() {
                var _this = _super.call(this) || this;
                _this.form.CustomerID.element.on('keyup', function (e) {
                    // only auto number when a key between 'A' and 'Z' is pressed
                    if (e.which >= 65 && e.which <= 90)
                        _this.getNextNumber();
                });
                return _this;
            }
            SerialAutoNumberDialog.prototype.afterLoadEntity = function () {
                _super.prototype.afterLoadEntity.call(this);
                // fill next number in new record mode
                if (this.isNew())
                    this.getNextNumber();
            };
            SerialAutoNumberDialog.prototype.getNextNumber = function () {
                var _this = this;
                var val = Q.trimToNull(this.form.CustomerID.value);
                // we will only get next number when customer ID is empty or 1 character in length
                if (!val || val.length <= 1) {
                    // if no customer ID yet (new record mode probably) use 'C' as a prefix
                    var prefix = (val || 'C').toUpperCase();
                    // call our service, see CustomerEndpoint.cs and CustomerRepository.cs
                    Serene3.Northwind.CustomerService.GetNextNumber({
                        Prefix: prefix,
                        Length: 5 // we want service to search for and return serials of 5 in length
                    }, function (response) {
                        _this.form.CustomerID.value = response.Serial;
                        // this is to mark numerical part after prefix
                        _this.form.CustomerID.element[0].setSelectionRange(prefix.length, response.Serial.length);
                    });
                }
            };
            SerialAutoNumberDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], SerialAutoNumberDialog);
            return SerialAutoNumberDialog;
        }(Serene3.Northwind.CustomerDialog));
        BasicSamples.SerialAutoNumberDialog = SerialAutoNumberDialog;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Customer/CustomerGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        /**
         * Subclass of CustomerGrid to override dialog type to SerialAutoNumberDialog
         */
        var SerialAutoNumberGrid = /** @class */ (function (_super) {
            __extends(SerialAutoNumberGrid, _super);
            function SerialAutoNumberGrid(container) {
                return _super.call(this, container) || this;
            }
            SerialAutoNumberGrid.prototype.getDialogType = function () { return BasicSamples.SerialAutoNumberDialog; };
            SerialAutoNumberGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], SerialAutoNumberGrid);
            return SerialAutoNumberGrid;
        }(Serene3.Northwind.CustomerGrid));
        BasicSamples.SerialAutoNumberGrid = SerialAutoNumberGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Common/Helpers/GridEditorDialog.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var ChangingLookupTextDialog = /** @class */ (function (_super) {
            __extends(ChangingLookupTextDialog, _super);
            function ChangingLookupTextDialog() {
                var _this = _super.call(this) || this;
                _this.form = new BasicSamples.ChangingLookupTextForm(_this.idPrefix);
                _this.form.ProductID.changeSelect2(function (e) {
                    var productID = Q.toId(_this.form.ProductID.value);
                    if (productID != null) {
                        _this.form.UnitPrice.value = Serene3.Northwind.ProductRow.getLookup().itemById[productID].UnitPrice;
                    }
                });
                _this.form.Discount.addValidationRule(_this.uniqueName, function (e) {
                    var price = _this.form.UnitPrice.value;
                    var quantity = _this.form.Quantity.value;
                    var discount = _this.form.Discount.value;
                    if (price != null && quantity != null && discount != null &&
                        discount > 0 && discount >= price * quantity) {
                        return "Discount can't be higher than total price!";
                    }
                });
                return _this;
            }
            ChangingLookupTextDialog.prototype.getFormKey = function () { return BasicSamples.ChangingLookupTextForm.formKey; };
            ChangingLookupTextDialog.prototype.getLocalTextPrefix = function () { return Serene3.Northwind.OrderDetailRow.localTextPrefix; };
            ChangingLookupTextDialog.prototype.updateInterface = function () {
                _super.prototype.updateInterface.call(this);
                this.toolbar.findButton('apply-changes-button').hide();
                this.toolbar.findButton('save-and-close-button').hide();
            };
            ChangingLookupTextDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], ChangingLookupTextDialog);
            return ChangingLookupTextDialog;
        }(Serene3.Common.GridEditorDialog));
        BasicSamples.ChangingLookupTextDialog = ChangingLookupTextDialog;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        /**
         * Our custom product editor type
         */
        var ChangingLookupTextEditor = /** @class */ (function (_super) {
            __extends(ChangingLookupTextEditor, _super);
            function ChangingLookupTextEditor(container, options) {
                return _super.call(this, container, options) || this;
            }
            ChangingLookupTextEditor.prototype.getLookupKey = function () {
                return Serene3.Northwind.ProductRow.lookupKey;
            };
            ChangingLookupTextEditor.prototype.getItemText = function (item, lookup) {
                return _super.prototype.getItemText.call(this, item, lookup) +
                    ' (' +
                    '$' + Q.formatNumber(item.UnitPrice, '#,##0.00') +
                    ', ' + (item.UnitsInStock > 0 ? (item.UnitsInStock + ' in stock') : 'out of stock') +
                    ', ' + (item.SupplierCompanyName || 'Unknown') +
                    ')';
            };
            ChangingLookupTextEditor = __decorate([
                Serenity.Decorators.registerEditor()
            ], ChangingLookupTextEditor);
            return ChangingLookupTextEditor;
        }(Serenity.LookupEditorBase));
        BasicSamples.ChangingLookupTextEditor = ChangingLookupTextEditor;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/OrderDetail/OrderDetailDialog.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        /**
         * Our subclass of order detail dialog with a CategoryID property
         * that will be used to set CascadeValue of product editor
         */
        var FilteredLookupOrderDetailDialog = /** @class */ (function (_super) {
            __extends(FilteredLookupOrderDetailDialog, _super);
            function FilteredLookupOrderDetailDialog() {
                var _this = _super.call(this) || this;
                _this.form = new Serene3.Northwind.OrderDetailForm(_this.idPrefix);
                // we can set cascade field in constructor
                // we could also use FilterField but in this case, when CategoryID is null
                // lookup editor would show all products in any category
                _this.form.ProductID.cascadeField = "CategoryID" /* CategoryID */;
                return _this;
                // but CategoryID value is not yet available here as detail editor will set it 
                // after calling constructor (creating a detail dialog) so we'll use BeforeLoadEntity
            }
            /**
             * This method is called just before an entity is loaded to dialog
             * This is also called for new record mode with an empty entity
             */
            FilteredLookupOrderDetailDialog.prototype.beforeLoadEntity = function (entity) {
                _super.prototype.beforeLoadEntity.call(this, entity);
                // setting cascade value here
                // make sure you have [LookupInclude] on CategoryID property of ProductRow
                // otherwise this field won't be available in lookup script (will always be null),
                // so can't be filtered and you'll end up with an empty product list.
                this.form.ProductID.cascadeValue = this.categoryID;
            };
            FilteredLookupOrderDetailDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], FilteredLookupOrderDetailDialog);
            return FilteredLookupOrderDetailDialog;
        }(Serene3.Northwind.OrderDetailDialog));
        BasicSamples.FilteredLookupOrderDetailDialog = FilteredLookupOrderDetailDialog;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/OrderDetail/OrderDetailsEditor.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        /**
         * Our subclass of Order Details editor with a CategoryID property
         */
        var FilteredLookupDetailEditor = /** @class */ (function (_super) {
            __extends(FilteredLookupDetailEditor, _super);
            function FilteredLookupDetailEditor(container) {
                return _super.call(this, container) || this;
            }
            FilteredLookupDetailEditor.prototype.getDialogType = function () { return BasicSamples.FilteredLookupOrderDetailDialog; };
            /**
             * This method is called to initialize an edit dialog created by
             * grid editor when Add button or an edit link is clicked
             * We have an opportunity here to pass CategoryID to edit dialog
             */
            FilteredLookupDetailEditor.prototype.initEntityDialog = function (itemType, dialog) {
                _super.prototype.initEntityDialog.call(this, itemType, dialog);
                // passing category ID from grid editor to detail dialog
                dialog.categoryID = this.categoryID;
            };
            FilteredLookupDetailEditor = __decorate([
                Serenity.Decorators.registerEditor()
            ], FilteredLookupDetailEditor);
            return FilteredLookupDetailEditor;
        }(Serene3.Northwind.OrderDetailsEditor));
        BasicSamples.FilteredLookupDetailEditor = FilteredLookupDetailEditor;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        /**
         * Basic order dialog with a category selection
         */
        var FilteredLookupInDetailDialog = /** @class */ (function (_super) {
            __extends(FilteredLookupInDetailDialog, _super);
            function FilteredLookupInDetailDialog() {
                var _this = _super.call(this) || this;
                _this.form = new BasicSamples.FilteredLookupInDetailForm(_this.idPrefix);
                _this.form.CategoryID.change(function (e) {
                    _this.form.DetailList.categoryID = Q.toId(_this.form.CategoryID.value);
                });
                return _this;
            }
            FilteredLookupInDetailDialog.prototype.getFormKey = function () { return BasicSamples.FilteredLookupInDetailForm.formKey; };
            FilteredLookupInDetailDialog.prototype.getIdProperty = function () { return Serene3.Northwind.OrderRow.idProperty; };
            FilteredLookupInDetailDialog.prototype.getLocalTextPrefix = function () { return Serene3.Northwind.OrderRow.localTextPrefix; };
            FilteredLookupInDetailDialog.prototype.getNameProperty = function () { return Serene3.Northwind.OrderRow.nameProperty; };
            FilteredLookupInDetailDialog.prototype.getService = function () { return Serene3.Northwind.OrderService.baseUrl; };
            FilteredLookupInDetailDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], FilteredLookupInDetailDialog);
            return FilteredLookupInDetailDialog;
        }(Serenity.EntityDialog));
        BasicSamples.FilteredLookupInDetailDialog = FilteredLookupInDetailDialog;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Order/OrderGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        /**
         * Subclass of OrderGrid to override dialog type to FilteredLookupInDetailDialog
         */
        var FilteredLookupInDetailGrid = /** @class */ (function (_super) {
            __extends(FilteredLookupInDetailGrid, _super);
            function FilteredLookupInDetailGrid(container) {
                return _super.call(this, container) || this;
            }
            FilteredLookupInDetailGrid.prototype.getDialogType = function () { return BasicSamples.FilteredLookupInDetailDialog; };
            FilteredLookupInDetailGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], FilteredLookupInDetailGrid);
            return FilteredLookupInDetailGrid;
        }(Serene3.Northwind.OrderGrid));
        BasicSamples.FilteredLookupInDetailGrid = FilteredLookupInDetailGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Product/ProductDialog.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        /**
         * This is our custom product dialog that uses a different product form
         * (LookupFilterByMultipleForm) with our special category editor.
         */
        var LookupFilterByMultipleDialog = /** @class */ (function (_super) {
            __extends(LookupFilterByMultipleDialog, _super);
            function LookupFilterByMultipleDialog() {
                return _super !== null && _super.apply(this, arguments) || this;
            }
            LookupFilterByMultipleDialog.prototype.getFormKey = function () { return BasicSamples.LookupFilterByMultipleForm.formKey; };
            LookupFilterByMultipleDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], LookupFilterByMultipleDialog);
            return LookupFilterByMultipleDialog;
        }(Serene3.Northwind.ProductDialog));
        BasicSamples.LookupFilterByMultipleDialog = LookupFilterByMultipleDialog;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Product/ProductGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        /**
         * Subclass of ProductGrid to override dialog type to CloneableEntityDialog
         */
        var LookupFilterByMultipleGrid = /** @class */ (function (_super) {
            __extends(LookupFilterByMultipleGrid, _super);
            function LookupFilterByMultipleGrid(container) {
                return _super.call(this, container) || this;
            }
            LookupFilterByMultipleGrid.prototype.getDialogType = function () { return BasicSamples.LookupFilterByMultipleDialog; };
            /**
             * This method is called just before List request is sent to service.
             * You have an opportunity here to cancel request or modify it.
             * Here we'll add a custom criteria to list request.
             */
            LookupFilterByMultipleGrid.prototype.onViewSubmit = function () {
                if (!_super.prototype.onViewSubmit.call(this)) {
                    return false;
                }
                // this has no relation to our lookup editor but as we'll allow picking only 
                // categories of Produce and Seafood in product dialog, it's better to show
                // only products from these categories in grid too
                var request = this.view.params;
                request.Criteria = Serenity.Criteria.and(request.Criteria, [['CategoryName'], 'in', [['Produce', 'Seafood']]]);
                // brackets used are important above, NOT ['CategoryName', 'in', ['Produce', 'Seafood']]
                return true;
            };
            LookupFilterByMultipleGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], LookupFilterByMultipleGrid);
            return LookupFilterByMultipleGrid;
        }(Serene3.Northwind.ProductGrid));
        BasicSamples.LookupFilterByMultipleGrid = LookupFilterByMultipleGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        /**
         * This is our category editor that will show only categories of Produce and
         * Seafood. We are subclassing LookupEditorBase which also LookupEditor
         * derives from.
         *
         * After compiling and transforming templates, this editor type will be
         * available in server side to use in our LookupFilterByMultipleForm,
         * which is a version of ProductForm that uses our custom editor.
         */
        var ProduceSeafoodCategoryEditor = /** @class */ (function (_super) {
            __extends(ProduceSeafoodCategoryEditor, _super);
            function ProduceSeafoodCategoryEditor(container, opt) {
                return _super.call(this, container, opt) || this;
            }
            /**
             * Normally LookupEditor requires a lookup key to determine which set of
             * lookup data to show in editor. As our editor will only show category
             * data, we lock it to category lookup key.
             */
            ProduceSeafoodCategoryEditor.prototype.getLookupKey = function () {
                return Serene3.Northwind.CategoryRow.lookupKey;
            };
            /**
             * Here we are filtering by category name but you could filter by any field.
             * Just make sure the fields you filter on has [LookupInclude] attribute on them,
             * otherwise their value will be null in client side as they are not sent back
             * from server in lookup script.
             */
            ProduceSeafoodCategoryEditor.prototype.getItems = function (lookup) {
                return _super.prototype.getItems.call(this, lookup).filter(function (x) {
                    return x.CategoryName === 'Produce' || x.CategoryName === 'Seafood';
                });
            };
            ProduceSeafoodCategoryEditor = __decorate([
                Serenity.Decorators.registerEditor()
            ], ProduceSeafoodCategoryEditor);
            return ProduceSeafoodCategoryEditor;
        }(Serenity.LookupEditorBase));
        BasicSamples.ProduceSeafoodCategoryEditor = ProduceSeafoodCategoryEditor;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var HardcodedValuesDialog = /** @class */ (function (_super) {
            __extends(HardcodedValuesDialog, _super);
            function HardcodedValuesDialog() {
                var _this = _super.call(this) || this;
                _this.form = new BasicSamples.HardcodedValuesForm(_this.idPrefix);
                _this.dialogTitle = "Please select some value";
                _this.form.SomeValue.changeSelect2(function (e) {
                    Q.notifySuccess("You selected item with key: " + _this.form.SomeValue.value);
                });
                return _this;
            }
            HardcodedValuesDialog.prototype.getFormKey = function () { return BasicSamples.HardcodedValuesForm.formKey; };
            HardcodedValuesDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], HardcodedValuesDialog);
            return HardcodedValuesDialog;
        }(Serenity.PropertyDialog));
        BasicSamples.HardcodedValuesDialog = HardcodedValuesDialog;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        /**
         * Our select editor with hardcoded values.
         *
         * When you define a new editor type, make sure you build
         * and transform templates for it to be available
         * in server side forms, e.g. [HardCodedValuesEditor]
         */
        var HardcodedValuesEditor = /** @class */ (function (_super) {
            __extends(HardcodedValuesEditor, _super);
            function HardcodedValuesEditor(container) {
                var _this = _super.call(this, container, null) || this;
                // add option accepts a key (id) value and display text value
                _this.addOption("key1", "Text 1");
                _this.addOption("key2", "Text 2");
                // you may also use addItem which accepts a Select2Item parameter
                _this.addItem({
                    id: "key3",
                    text: "Text 3"
                });
                // don't let selecting this one (disabled)
                _this.addItem({
                    id: "key4",
                    text: "Text 4",
                    disabled: true
                });
                return _this;
            }
            HardcodedValuesEditor = __decorate([
                Serenity.Decorators.registerEditor()
            ], HardcodedValuesEditor);
            return HardcodedValuesEditor;
        }(Serenity.Select2Editor));
        BasicSamples.HardcodedValuesEditor = HardcodedValuesEditor;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var StaticTextBlockDialog = /** @class */ (function (_super) {
            __extends(StaticTextBlockDialog, _super);
            function StaticTextBlockDialog() {
                var _this = _super.call(this) || this;
                _this.form = new BasicSamples.StaticTextBlockForm(_this.idPrefix);
                _this.dialogTitle = "A form with static text blocks";
                return _this;
            }
            StaticTextBlockDialog.prototype.getFormKey = function () { return BasicSamples.StaticTextBlockForm.formKey; };
            /**
             * Here we override loadInitialEntity method to set value for "DisplayFieldValue" field.
             * If this was an EntityDialog, your field value would be originating from server side entity.
             */
            StaticTextBlockDialog.prototype.loadInitialEntity = function () {
                this.propertyGrid.load({
                    DisplayFieldValue: 'This content comes from <b>the value</b> of <em>DisplayFieldValue</em> field.'
                });
            };
            StaticTextBlockDialog.prototype.getDialogOptions = function () {
                var opt = _super.prototype.getDialogOptions.call(this);
                opt.width = 650;
                return opt;
            };
            StaticTextBlockDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], StaticTextBlockDialog);
            return StaticTextBlockDialog;
        }(Serenity.PropertyDialog));
        BasicSamples.StaticTextBlockDialog = StaticTextBlockDialog;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Common/Helpers/BulkServiceAction.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var OrderBulkAction = /** @class */ (function (_super) {
            __extends(OrderBulkAction, _super);
            function OrderBulkAction() {
                return _super !== null && _super.apply(this, arguments) || this;
            }
            /**
             * This controls how many service requests will be used in parallel.
             * Determine this number based on how many requests your server
             * might be able to handle, and amount of wait on external resources.
             */
            OrderBulkAction.prototype.getParallelRequests = function () {
                return 10;
            };
            /**
             * These number of records IDs will be sent to your service in one
             * service call. If your service is designed to handle one record only,
             * set it to 1. But note that, if you have 5000 records, this will
             * result in 5000 service calls / requests.
             */
            OrderBulkAction.prototype.getBatchSize = function () {
                return 5;
            };
            /**
             * This is where you should call your service.
             * Batch parameter contains the selected order IDs
             * that should be processed in this service call.
             */
            OrderBulkAction.prototype.executeForBatch = function (batch) {
                var _this = this;
                BasicSamples.BasicSamplesService.OrderBulkAction({
                    OrderIDs: batch.map(function (x) { return Q.parseInteger(x); })
                }, function (response) { return _this.set_successCount(_this.get_successCount() + batch.length); }, {
                    blockUI: false,
                    onError: function (response) { return _this.set_errorCount(_this.get_errorCount() + batch.length); },
                    onCleanup: function () { return _this.serviceCallCleanup(); }
                });
            };
            return OrderBulkAction;
        }(Serene3.Common.BulkServiceAction));
        BasicSamples.OrderBulkAction = OrderBulkAction;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Order/OrderGrid.ts" />
/// <reference path="OrderBulkAction.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var CancellableBulkActionGrid = /** @class */ (function (_super) {
            __extends(CancellableBulkActionGrid, _super);
            function CancellableBulkActionGrid(container) {
                return _super.call(this, container) || this;
            }
            CancellableBulkActionGrid.prototype.createToolbarExtensions = function () {
                _super.prototype.createToolbarExtensions.call(this);
                this.rowSelection = new Serenity.GridRowSelectionMixin(this);
            };
            CancellableBulkActionGrid.prototype.getButtons = function () {
                var _this = this;
                return [{
                        title: 'Perform Bulk Action on Selected Orders',
                        cssClass: 'send-button',
                        onClick: function () {
                            if (!_this.onViewSubmit()) {
                                return;
                            }
                            var action = new BasicSamples.OrderBulkAction();
                            action.done = function () { return _this.rowSelection.resetCheckedAndRefresh(); };
                            action.execute(_this.rowSelection.getSelectedKeys());
                        }
                    }];
            };
            CancellableBulkActionGrid.prototype.getColumns = function () {
                var _this = this;
                var columns = _super.prototype.getColumns.call(this);
                columns.splice(0, 0, Serenity.GridRowSelectionMixin.createSelectColumn(function () { return _this.rowSelection; }));
                return columns;
            };
            CancellableBulkActionGrid.prototype.getViewOptions = function () {
                var opt = _super.prototype.getViewOptions.call(this);
                opt.rowsPerPage = 2500;
                return opt;
            };
            CancellableBulkActionGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], CancellableBulkActionGrid);
            return CancellableBulkActionGrid;
        }(Serene3.Northwind.OrderGrid));
        BasicSamples.CancellableBulkActionGrid = CancellableBulkActionGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var ConditionalFormattingGrid = /** @class */ (function (_super) {
            __extends(ConditionalFormattingGrid, _super);
            function ConditionalFormattingGrid(container) {
                return _super.call(this, container) || this;
            }
            ConditionalFormattingGrid.prototype.getColumnsKey = function () { return "Northwind.Product"; };
            ConditionalFormattingGrid.prototype.getDialogType = function () { return Serene3.Northwind.ProductDialog; };
            ConditionalFormattingGrid.prototype.getIdProperty = function () { return Serene3.Northwind.ProductRow.idProperty; };
            ConditionalFormattingGrid.prototype.getLocalTextPrefix = function () { return Serene3.Northwind.ProductRow.localTextPrefix; };
            ConditionalFormattingGrid.prototype.getService = function () { return Serene3.Northwind.ProductService.baseUrl; };
            /**
             * We override getColumns() to be able to add a custom CSS class to UnitPrice
             * We could also add this class in ProductColumns.cs but didn't want to modify
             * it solely for this sample.
             */
            ConditionalFormattingGrid.prototype.getColumns = function () {
                var columns = _super.prototype.getColumns.call(this);
                // adding a specific css class to UnitPrice column, 
                // to be able to format cell with a different background
                Q.first(columns, function (x) { return x.field == "UnitPrice" /* UnitPrice */; }).cssClass += " col-unit-price";
                return columns;
            };
            /**
             * This method is called for all rows
             * @param item Data item for current row
             * @param index Index of the row in grid
             */
            ConditionalFormattingGrid.prototype.getItemCssClass = function (item, index) {
                var klass = "";
                if (item.Discontinued == true)
                    klass += " discontinued";
                else if (item.UnitsInStock <= 0)
                    klass += " out-of-stock";
                else if (item.UnitsInStock < 20)
                    klass += " critical-stock";
                else if (item.UnitsInStock > 50)
                    klass += " needs-reorder";
                if (item.UnitPrice >= 50)
                    klass += " high-price";
                else if (item.UnitPrice >= 20)
                    klass += " medium-price";
                else
                    klass += " low-price";
                return Q.trimToNull(klass);
            };
            ConditionalFormattingGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], ConditionalFormattingGrid);
            return ConditionalFormattingGrid;
        }(Serenity.EntityGrid));
        BasicSamples.ConditionalFormattingGrid = ConditionalFormattingGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Order/OrderGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var CustomLinksInGrid = /** @class */ (function (_super) {
            __extends(CustomLinksInGrid, _super);
            function CustomLinksInGrid(container) {
                return _super.call(this, container) || this;
            }
            /**
             * We override getColumns() to change format functions for some columns.
             * You could also write them as formatter classes, and use them at server side
             */
            CustomLinksInGrid.prototype.getColumns = function () {
                var columns = _super.prototype.getColumns.call(this);
                Q.first(columns, function (x) { return x.field == "CustomerCompanyName" /* CustomerCompanyName */; }).format =
                    function (ctx) { return "<a href=\"javascript:;\" class=\"customer-link\">" + Q.htmlEncode(ctx.value) + "</a>"; };
                Q.first(columns, function (x) { return x.field == "OrderDate" /* OrderDate */; }).format =
                    function (ctx) { return "<a href=\"javascript:;\" class=\"date-link\">" + Q.formatDate(ctx.value) + "</a>"; };
                Q.first(columns, function (x) { return x.field == "EmployeeFullName" /* EmployeeFullName */; }).format =
                    function (ctx) { return "<a href=\"javascript:;\" class=\"employee-link\">" + Q.htmlEncode(ctx.value) + "</a>"; };
                Q.first(columns, function (x) { return x.field == "ShipCountry" /* ShipCountry */; }).format =
                    function (ctx) { return "<a href=\"javascript:;\" class=\"ship-country-link\">" + Q.htmlEncode(ctx.value) + "</a>"; };
                return columns;
            };
            CustomLinksInGrid.prototype.onClick = function (e, row, cell) {
                // let base grid handle clicks for its edit links
                _super.prototype.onClick.call(this, e, row, cell);
                // if base grid already handled, we shouldn"t handle it again
                if (e.isDefaultPrevented()) {
                    return;
                }
                // get reference to current item
                var item = this.itemAt(row);
                // get reference to clicked element
                var target = $(e.target);
                if (target.hasClass("customer-link")) {
                    e.preventDefault();
                    var message = Q.format("<p>You have clicked an order from customer: {0}.</p>" +
                        "<p>If you click Yes, i'll open Customer dialog.</p>" +
                        "<p>If you click No, i'll open Order dialog.</p>", Q.htmlEncode(item.CustomerCompanyName));
                    Q.confirm(message, function () {
                        // CustomerDialog doesn't use CustomerID but ID (identity)
                        // so need to find customer to get its actual ID
                        var customer = Q.first(Serene3.Northwind.CustomerRow.getLookup().items, function (x) { return x.CustomerID == item.CustomerID; });
                        new Serene3.Northwind.CustomerDialog().loadByIdAndOpenDialog(customer.ID);
                    }, {
                        htmlEncode: false,
                        onNo: function () {
                            new Serene3.Northwind.OrderDialog().loadByIdAndOpenDialog(item.OrderID);
                        }
                    });
                }
                else if (target.hasClass("date-link")) {
                    e.preventDefault();
                    var ordersInSameDate = Q.count(this.view.getItems(), function (x) { return x.OrderDate == item.OrderDate; });
                    Q.notifyInfo("You clicked an order from date " +
                        Q.formatDate(item.OrderDate) + ". There are " +
                        ordersInSameDate + " orders from the same date that is loaded in grid at the moment");
                }
                else if (target.hasClass("employee-link")) {
                    e.preventDefault();
                    Q.notifySuccess("You clicked an employee name, " +
                        "so i've opened a new Order Dialog from same customer " +
                        "with that employee prepopulated!");
                    new Serene3.Northwind.OrderDialog().loadEntityAndOpenDialog({
                        CustomerID: item.CustomerID,
                        EmployeeID: item.EmployeeID
                    });
                }
                else if (target.hasClass("ship-country-link")) {
                    e.preventDefault();
                    Q.notifySuccess("Let's filter the grid to orders from " + item.ShipCountry);
                    var countryFilter = this.findQuickFilter(Serenity.LookupEditor, "ShipCountry" /* ShipCountry */);
                    countryFilter.value = item.ShipCountry;
                    this.refresh();
                }
            };
            /**
             * This method is called for columns with [EditLink] attribute,
             * but only for edit links of this grid's own item type.
             * It is also called by Add Product button with a NULL entityOrId
             * parameter so we should check that entityOrId is a string
             * to be sure it is originating from a link.
             *
             * As we changed format for other columns, this will only be called
             * for links in remaining OrderID column
             */
            CustomLinksInGrid.prototype.editItem = function (entityOrId) {
                // check that this is an edit link click, not add button, ID is always a string
                if (typeof entityOrId == "string") {
                    // convert ID to an integer, and find order with that ID
                    var item = this.view.getItemById(Q.toId(entityOrId));
                    // date is a ISO string, so need to parse it first
                    var date = Q.formatDate(item.OrderDate);
                    // ask for confirmation
                    Q.confirm(Q.format("You clicked edit link for order with ID: {0} and Date: {1}. Should i open that order?", item.OrderID, date), function () {
                        new Serene3.Northwind.OrderDialog().loadByIdAndOpenDialog(item.OrderID);
                    });
                }
                else {
                    _super.prototype.editItem.call(this, entityOrId);
                }
            };
            CustomLinksInGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], CustomLinksInGrid);
            return CustomLinksInGrid;
        }(Serene3.Northwind.OrderGrid));
        BasicSamples.CustomLinksInGrid = CustomLinksInGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var DragDropSampleDialog = /** @class */ (function (_super) {
            __extends(DragDropSampleDialog, _super);
            function DragDropSampleDialog() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.form = new BasicSamples.DragDropSampleForm(_this.idPrefix);
                return _this;
            }
            DragDropSampleDialog.prototype.getFormKey = function () { return BasicSamples.DragDropSampleForm.formKey; };
            DragDropSampleDialog.prototype.getIdProperty = function () { return BasicSamples.DragDropSampleRow.idProperty; };
            DragDropSampleDialog.prototype.getLocalTextPrefix = function () { return BasicSamples.DragDropSampleRow.localTextPrefix; };
            DragDropSampleDialog.prototype.getNameProperty = function () { return BasicSamples.DragDropSampleRow.nameProperty; };
            DragDropSampleDialog.prototype.getService = function () { return BasicSamples.DragDropSampleService.baseUrl; };
            DragDropSampleDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], DragDropSampleDialog);
            return DragDropSampleDialog;
        }(Serenity.EntityDialog));
        BasicSamples.DragDropSampleDialog = DragDropSampleDialog;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var DragDropSampleGrid = /** @class */ (function (_super) {
            __extends(DragDropSampleGrid, _super);
            function DragDropSampleGrid(container) {
                var _this = _super.call(this, container) || this;
                new Serenity.TreeGridMixin({
                    grid: _this,
                    toggleField: "Title" /* Title */,
                    getParentId: function (x) { return x.ParentId; },
                    initialCollapse: function () { return false; },
                });
                // save prior drag target to restore its color during drag
                var priorDragTarget;
                // prevent the grid from cancelling drag'n'drop by default
                _this.slickGrid.onDragInit.subscribe(function (e, dd) {
                    e.stopImmediatePropagation();
                });
                // this method is called when an item is about to be dragged
                _this.slickGrid.onDragStart.subscribe(function (e, dd) {
                    // only allow edit links to be dragged
                    if (!$(e.target).hasClass('s-EditLink'))
                        return;
                    // make sure there is a cell in source location
                    var cell = _this.slickGrid.getCellFromEvent(e);
                    if (!cell) {
                        return;
                    }
                    // notify that we'll handle drag
                    e.stopImmediatePropagation();
                    // save details about dragged item
                    dd.row = cell.row;
                    var item = _this.itemAt(cell.row);
                    dd.item = item;
                    // a unique name for our operation
                    dd.mode = "move";
                    // create an absolute position helper shown during dragging
                    var helper = $("<span></span>")
                        .addClass('drag-helper')
                        .text("Moving " + item.Title)
                        .appendTo(document.body);
                    dd.helper = helper;
                });
                // this method is periodically called during drag
                _this.slickGrid.onDrag.subscribe(function (e, dd) {
                    // only handle our operation
                    if (dd.mode != "move") {
                        return;
                    }
                    // if we changed color of some target before, reset it
                    if (priorDragTarget && priorDragTarget != e.target) {
                        $(priorDragTarget).css('background-color', '');
                        priorDragTarget = null;
                    }
                    // find target, the source will drag into
                    var cell = _this.slickGrid.getCellFromEvent(e);
                    var target = !cell ? null : _this.itemAt(cell.row);
                    // accept only edit links and valid items as drag target
                    var reject = !$(e.target).hasClass('s-EditLink') || !_this.canMoveUnder(dd.item, target);
                    if (reject) {
                        dd.helper.text("Can't move " + dd.item.Title + " here");
                    }
                    else {
                        dd.helper.text("Move " + dd.item.Title + " under " + $(e.target).text());
                        // change color of current drag target
                        $(e.target).css('background-color', '#ddeeee');
                        priorDragTarget = e.target;
                    }
                    // toggle class of helper to show relevant accept / reject icon
                    dd.helper.toggleClass('reject', reject);
                    // position helper next to current mouse position
                    dd.helper.css({ top: e.pageY + 5, left: e.pageX + 4 });
                });
                // this is called when drag is completed
                _this.slickGrid.onDragEnd.subscribe(function (e, dd) {
                    if (dd.mode != "move") {
                        return;
                    }
                    // prevent browser from changing url
                    e.preventDefault();
                    // clear indicator color and drag helper
                    priorDragTarget && $(priorDragTarget).css('background-color', '');
                    dd.helper.remove();
                    // determine target row
                    var cell = _this.slickGrid.getCellFromEvent(e);
                    var item = dd.item;
                    var target = !cell ? null : _this.itemAt(cell.row);
                    // check again that this is valid drag target
                    if ($(e.target).hasClass('s-EditLink') && _this.canMoveUnder(item, target)) {
                        // this will move our primary drag source under new parent
                        var moveItem = function (onSuccess) {
                            BasicSamples.DragDropSampleService.Update({
                                EntityId: item.Id,
                                Entity: {
                                    ParentId: target.Id
                                }
                            }, onSuccess);
                        };
                        // if drag source has some children, need some confirmation
                        var children = _this.getChildren(dd.item);
                        if (children.length > 0) {
                            Q.confirm('Move its children alongside the item?', function () {
                                // if responded yes, moving item under new parent should be enough
                                moveItem(function () { return _this.refresh(); });
                            }, {
                                onNo: function () {
                                    // if responded no, children should move under old parent of item
                                    var oldParentId = item.ParentId == null ? null : item.ParentId;
                                    var moveNextChild = function (onSuccess) {
                                        var _this = this;
                                        if (children.length) {
                                            var x = children.shift();
                                            BasicSamples.DragDropSampleService.Update({
                                                EntityId: x.Id,
                                                Entity: {
                                                    ParentId: oldParentId || null
                                                }
                                            }, function () { return moveNextChild(onSuccess); }, {
                                                onError: function () { return _this.refresh(); }
                                            });
                                        }
                                        else
                                            onSuccess();
                                    };
                                    // first move item itself under new parent, 
                                    // then move its children under old parent one by one
                                    moveItem(function () { return moveNextChild(function () { return _this.refresh(); }); });
                                }
                            });
                        }
                        else {
                            // item has no children, just move it under new parent
                            moveItem(function () { return _this.refresh(); });
                        }
                    }
                    return false;
                });
                return _this;
            }
            DragDropSampleGrid.prototype.getColumnsKey = function () { return 'BasicSamples.DragDropSample'; };
            DragDropSampleGrid.prototype.getDialogType = function () { return BasicSamples.DragDropSampleDialog; };
            DragDropSampleGrid.prototype.getIdProperty = function () { return BasicSamples.DragDropSampleRow.idProperty; };
            DragDropSampleGrid.prototype.getLocalTextPrefix = function () { return BasicSamples.DragDropSampleRow.localTextPrefix; };
            DragDropSampleGrid.prototype.getService = function () { return BasicSamples.DragDropSampleService.baseUrl; };
            /**
             * This method will determine if item can be moved under a given target
             * An item can't be moved under itself, under one of its children
             */
            DragDropSampleGrid.prototype.canMoveUnder = function (item, target) {
                if (!item || !target || item.Id == target.Id || item.ParentId == target.Id)
                    return false;
                if (Q.any(this.getParents(target), function (x) { return x.Id == item.Id; }))
                    return false;
                return true;
            };
            /**
             * Gets children list of an item
             */
            DragDropSampleGrid.prototype.getChildren = function (item) {
                return this.getItems().filter(function (x) { return x.ParentId == item.Id; });
            };
            /**
             * Gets all parents of an item
             */
            DragDropSampleGrid.prototype.getParents = function (item) {
                // use this to prevent infinite recursion
                var visited = {};
                var result = [];
                // while item has a parent and not visited yet
                while (item.ParentId && !visited[item.ParentId]) {
                    // find parent by its ID
                    item = this.view.getItemById(item.ParentId);
                    if (!item)
                        break;
                    result.push(item);
                    visited[item.Id] = true;
                }
                return result;
            };
            DragDropSampleGrid.prototype.getButtons = function () {
                return [];
            };
            DragDropSampleGrid.prototype.usePager = function () {
                return false;
            };
            DragDropSampleGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], DragDropSampleGrid);
            return DragDropSampleGrid;
        }(Serenity.EntityGrid));
        BasicSamples.DragDropSampleGrid = DragDropSampleGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var SelectableEntityGrid = /** @class */ (function (_super) {
        __extends(SelectableEntityGrid, _super);
        function SelectableEntityGrid() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        SelectableEntityGrid.prototype.getSlickOptions = function () {
            var opt = _super.prototype.getSlickOptions.call(this);
            opt.enableTextSelectionOnCells = true;
            opt.selectedCellCssClass = "slick-row-selected";
            opt.enableCellNavigation = true;
            return opt;
        };
        SelectableEntityGrid.prototype.createSlickGrid = function () {
            var grid = _super.prototype.createSlickGrid.call(this);
            grid.setSelectionModel(new Slick.RowSelectionModel());
            return grid;
        };
        SelectableEntityGrid = __decorate([
            Serenity.Decorators.registerClass()
        ], SelectableEntityGrid);
        return SelectableEntityGrid;
    }(Serenity.EntityGrid));
    Serene3.SelectableEntityGrid = SelectableEntityGrid;
})(Serene3 || (Serene3 = {}));
/// <reference path="SelectableEntityGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var RowSelectionGrid = /** @class */ (function (_super) {
            __extends(RowSelectionGrid, _super);
            function RowSelectionGrid(container) {
                return _super.call(this, container) || this;
            }
            RowSelectionGrid.prototype.getColumnsKey = function () { return "Northwind.Supplier"; };
            RowSelectionGrid.prototype.getDialogType = function () { return Serene3.Northwind.SupplierDialog; };
            RowSelectionGrid.prototype.getIdProperty = function () { return Serene3.Northwind.SupplierRow.idProperty; };
            RowSelectionGrid.prototype.getLocalTextPrefix = function () { return Serene3.Northwind.SupplierRow.localTextPrefix; };
            RowSelectionGrid.prototype.getService = function () { return Serene3.Northwind.SupplierService.baseUrl; };
            RowSelectionGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], RowSelectionGrid);
            return RowSelectionGrid;
        }(Serene3.SelectableEntityGrid));
        BasicSamples.RowSelectionGrid = RowSelectionGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Product/ProductGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var GridFilteredByCriteria = /** @class */ (function (_super) {
            __extends(GridFilteredByCriteria, _super);
            function GridFilteredByCriteria(container) {
                return _super.call(this, container) || this;
            }
            GridFilteredByCriteria.prototype.onViewSubmit = function () {
                // only continue if base class returns true (didn't cancel request)
                if (!_super.prototype.onViewSubmit.call(this)) {
                    return false;
                }
                // view object is the data source for grid (SlickRemoteView)
                // this is an EntityGrid so its Params object is a ListRequest
                var request = this.view.params;
                // list request has a Criteria parameter
                // we AND criteria here to existing one because 
                // otherwise we might clear filter set by 
                // an edit filter dialog if any.
                request.Criteria = Serenity.Criteria.and(request.Criteria, [['UnitsInStock'], '>', 10], [['CategoryName'], '!=', 'Condiments'], [['Discontinued'], '=', 0]);
                // TypeScript doesn't support operator overloading
                // so we had to use array syntax above to build criteria.
                // Make sure you write
                // [['Field'], '>', 10] (which means field A is greater than 10)
                // not 
                // ['A', '>', 10] (which means string 'A' is greater than 10
                return true;
            };
            GridFilteredByCriteria = __decorate([
                Serenity.Decorators.registerClass()
            ], GridFilteredByCriteria);
            return GridFilteredByCriteria;
        }(Serene3.Northwind.ProductGrid));
        BasicSamples.GridFilteredByCriteria = GridFilteredByCriteria;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Product/ProductGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var GroupingAndSummariesInGrid = /** @class */ (function (_super) {
            __extends(GroupingAndSummariesInGrid, _super);
            function GroupingAndSummariesInGrid(container) {
                return _super.call(this, container) || this;
            }
            GroupingAndSummariesInGrid.prototype.createSlickGrid = function () {
                var grid = _super.prototype.createSlickGrid.call(this);
                // need to register this plugin for grouping or you'll have errors
                grid.registerPlugin(new Slick.Data.GroupItemMetadataProvider());
                this.view.setSummaryOptions({
                    aggregators: [
                        new Slick.Aggregators.Avg('UnitPrice'),
                        new Slick.Aggregators.Sum('UnitsInStock'),
                        new Slick.Aggregators.Max('UnitsOnOrder'),
                        new Slick.Aggregators.Avg('ReorderLevel')
                    ]
                });
                return grid;
            };
            GroupingAndSummariesInGrid.prototype.getColumns = function () {
                var columns = _super.prototype.getColumns.call(this);
                Q.first(columns, function (x) { return x.field === 'UnitsOnOrder'; })
                    .groupTotalsFormatter = function (totals, col) {
                    return (totals.max ? ('max: ' + Q.coalesce(totals.max[col.field], '')) : '');
                };
                Q.first(columns, function (x) { return x.field === 'ReorderLevel'; })
                    .groupTotalsFormatter = function (totals, col) {
                    return (totals.avg ? ('avg: ' + Q.coalesce(Q.formatNumber(totals.avg[col.field], '0.'), '')) : '');
                };
                return columns;
            };
            GroupingAndSummariesInGrid.prototype.getSlickOptions = function () {
                var opt = _super.prototype.getSlickOptions.call(this);
                opt.showFooterRow = true;
                return opt;
            };
            GroupingAndSummariesInGrid.prototype.usePager = function () {
                return false;
            };
            GroupingAndSummariesInGrid.prototype.getButtons = function () {
                var _this = this;
                return [{
                        title: 'Group By Category',
                        cssClass: 'expand-all-button',
                        onClick: function () { return _this.view.setGrouping([{
                                getter: 'CategoryName'
                            }]); }
                    },
                    {
                        title: 'Group By Category and Supplier',
                        cssClass: 'expand-all-button',
                        onClick: function () { return _this.view.setGrouping([{
                                formatter: function (x) { return 'Category: ' + x.value + ' (' + x.count + ' items)'; },
                                getter: 'CategoryName'
                            }, {
                                formatter: function (x) { return 'Supplier: ' + x.value + ' (' + x.count + ' items)'; },
                                getter: 'SupplierCompanyName'
                            }]); }
                    }, {
                        title: 'No Grouping',
                        cssClass: 'collapse-all-button',
                        onClick: function () { return _this.view.setGrouping([]); }
                    }];
            };
            GroupingAndSummariesInGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], GroupingAndSummariesInGrid);
            return GroupingAndSummariesInGrid;
        }(Serene3.Northwind.ProductGrid));
        BasicSamples.GroupingAndSummariesInGrid = GroupingAndSummariesInGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Order/OrderGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var InitialValuesForQuickFilters = /** @class */ (function (_super) {
            __extends(InitialValuesForQuickFilters, _super);
            function InitialValuesForQuickFilters(container) {
                return _super.call(this, container) || this;
            }
            /**
             * This method is called to get list of quick filters to be created for this grid.
             * By default, it returns quick filter objects corresponding to properties that
             * have a [QuickFilter] attribute at server side OrderColumns.cs
             */
            InitialValuesForQuickFilters.prototype.getQuickFilters = function () {
                // get quick filter list from base class
                var filters = _super.prototype.getQuickFilters.call(this);
                // quick filter init method is a good place to set initial
                // value for a quick filter editor, just after it is created
                Q.first(filters, function (x) { return x.field == "OrderDate" /* OrderDate */; }).init = function (w) {
                    // w is a reference to the editor for this quick filter widget
                    // here we cast it to DateEditor, and set its value as date.
                    // note that in Javascript, months are 0 based, so date below
                    // is actually 2016-05-01
                    w.valueAsDate = new Date(2016, 4, 1);
                    // setting start date was simple. but this quick filter is actually
                    // a combination of two date editors. to get reference to second one,
                    // need to find its next sibling element by its class
                    var endDate = w.element.nextAll(".s-DateEditor").getWidget(Serenity.DateEditor);
                    endDate.valueAsDate = new Date(2016, 6, 1);
                };
                Q.first(filters, function (x) { return x.field == "ShippingState" /* ShippingState */; }).init = function (w) {
                    // enum editor has a string value, so need to call toString()
                    w.value = Serene3.Northwind.OrderShippingState.NotShipped.toString();
                };
                return filters;
            };
            /**
             * This method is another possible place to modify quick filter widgets.
             * It is where the quick filter widgets are actually created.
             *
             * By default, it calls getQuickFilters() then renders UI for these
             * quick filters.
             *
             * We could use getQuickFilters() method for ShipVia too,
             * but this is for demonstration purposes
             */
            InitialValuesForQuickFilters.prototype.createQuickFilters = function () {
                // let base class to create quick filters first
                _super.prototype.createQuickFilters.call(this);
                // find a quick filter widget by its field name
                this.findQuickFilter(Serenity.LookupEditor, "ShipVia" /* ShipVia */).values = ["1", "2"];
            };
            InitialValuesForQuickFilters = __decorate([
                Serenity.Decorators.registerClass()
            ], InitialValuesForQuickFilters);
            return InitialValuesForQuickFilters;
        }(Serene3.Northwind.OrderGrid));
        BasicSamples.InitialValuesForQuickFilters = InitialValuesForQuickFilters;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Customer/CustomerGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var InlineActionGrid = /** @class */ (function (_super) {
            __extends(InlineActionGrid, _super);
            function InlineActionGrid(container) {
                return _super.call(this, container) || this;
            }
            InlineActionGrid.prototype.getColumns = function () {
                var columns = _super.prototype.getColumns.call(this);
                columns.unshift({
                    field: 'Delete Row',
                    name: '',
                    format: function (ctx) { return '<a class="inline-action delete-row" title="delete">' +
                        '<i class="fa fa-trash-o text-red"></i></a>'; },
                    width: 24,
                    minWidth: 24,
                    maxWidth: 24
                });
                columns.splice(1, 0, {
                    field: 'View Details',
                    name: '',
                    format: function (ctx) { return '<a class="inline-action view-details" title="view details"></a>'; },
                    width: 24,
                    minWidth: 24,
                    maxWidth: 24
                });
                columns.splice(2, 0, {
                    field: 'New Order',
                    name: '',
                    format: function (ctx) { return '<a class="inline-action new-order" title="new order"></a>'; },
                    width: 24,
                    minWidth: 24,
                    maxWidth: 24
                });
                return columns;
            };
            InlineActionGrid.prototype.onClick = function (e, row, cell) {
                var _this = this;
                _super.prototype.onClick.call(this, e, row, cell);
                if (e.isDefaultPrevented())
                    return;
                var item = this.itemAt(row);
                var target = $(e.target);
                // if user clicks "i" element, e.g. icon
                if (target.parent().hasClass('inline-action'))
                    target = target.parent();
                if (target.hasClass('inline-action')) {
                    e.preventDefault();
                    if (target.hasClass('delete-row')) {
                        Q.confirm('Delete record?', function () {
                            Serene3.Northwind.CustomerService.Delete({
                                EntityId: item.ID,
                            }, function (response) {
                                _this.refresh();
                            });
                        });
                    }
                    else if (target.hasClass('view-details')) {
                        this.editItem(item.ID);
                    }
                    else if (target.hasClass('new-order')) {
                        var dlg = new Serene3.Northwind.OrderDialog();
                        this.initDialog(dlg);
                        dlg.loadEntityAndOpenDialog({
                            CustomerID: item.CustomerID
                        });
                    }
                }
            };
            InlineActionGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], InlineActionGrid);
            return InlineActionGrid;
        }(Serene3.Northwind.CustomerGrid));
        BasicSamples.InlineActionGrid = InlineActionGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var InlineImageFormatter = /** @class */ (function () {
            function InlineImageFormatter() {
            }
            InlineImageFormatter.prototype.format = function (ctx) {
                var file = (this.fileProperty ? ctx.item[this.fileProperty] : ctx.value);
                if (!file || !file.length)
                    return "";
                var href = Q.resolveUrl("~/upload/" + file);
                if (this.thumb) {
                    var parts = file.split('.');
                    file = parts.slice(0, parts.length - 1).join('.') + '_t.jpg';
                }
                var src = Q.resolveUrl('~/upload/' + file);
                return "<a class=\"inline-image\" target='_blank' href=\"" + href + "\">" +
                    ("<img src=\"" + src + "\" style='max-height: 145px; max-width: 100%;' /></a>");
            };
            InlineImageFormatter.prototype.initializeColumn = function (column) {
                if (this.fileProperty) {
                    column.referencedFields = column.referencedFields || [];
                    column.referencedFields.push(this.fileProperty);
                }
            };
            __decorate([
                Serenity.Decorators.option()
            ], InlineImageFormatter.prototype, "fileProperty", void 0);
            __decorate([
                Serenity.Decorators.option()
            ], InlineImageFormatter.prototype, "thumb", void 0);
            InlineImageFormatter = __decorate([
                Serenity.Decorators.registerFormatter()
            ], InlineImageFormatter);
            return InlineImageFormatter;
        }());
        BasicSamples.InlineImageFormatter = InlineImageFormatter;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Order/OrderGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var InlineImageInGrid = /** @class */ (function (_super) {
            __extends(InlineImageInGrid, _super);
            function InlineImageInGrid(container) {
                return _super.call(this, container) || this;
            }
            InlineImageInGrid.prototype.getColumnsKey = function () { return "BasicSamples.InlineImageInGrid"; };
            InlineImageInGrid.prototype.getDialogType = function () { return Serene3.Northwind.ProductDialog; };
            InlineImageInGrid.prototype.getIdProperty = function () { return Serene3.Northwind.ProductRow.idProperty; };
            InlineImageInGrid.prototype.getLocalTextPrefix = function () { return Serene3.Northwind.ProductRow.localTextPrefix; };
            InlineImageInGrid.prototype.getService = function () { return Serene3.Northwind.ProductService.baseUrl; };
            InlineImageInGrid.prototype.getSlickOptions = function () {
                var opt = _super.prototype.getSlickOptions.call(this);
                opt.rowHeight = 150;
                return opt;
            };
            InlineImageInGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], InlineImageInGrid);
            return InlineImageInGrid;
        }(Serenity.EntityGrid));
        BasicSamples.InlineImageInGrid = InlineImageInGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var ProductExcelImportDialog = /** @class */ (function (_super) {
            __extends(ProductExcelImportDialog, _super);
            function ProductExcelImportDialog() {
                var _this = _super.call(this) || this;
                _this.form = new BasicSamples.ProductExcelImportForm(_this.idPrefix);
                return _this;
            }
            ProductExcelImportDialog.prototype.getDialogTitle = function () {
                return "Excel Import";
            };
            ProductExcelImportDialog.prototype.getDialogButtons = function () {
                var _this = this;
                return [
                    {
                        text: 'Import',
                        click: function () {
                            if (!_this.validateBeforeSave())
                                return;
                            if (_this.form.FileName.value == null ||
                                Q.isEmptyOrNull(_this.form.FileName.value.Filename)) {
                                Q.notifyError("Please select a file!");
                                return;
                            }
                            BasicSamples.ProductExcelImportService.ExcelImport({
                                FileName: _this.form.FileName.value.Filename
                            }, function (response) {
                                Q.notifyInfo('Inserted: ' + (response.Inserted || 0) +
                                    ', Updated: ' + (response.Updated || 0));
                                if (response.ErrorList != null && response.ErrorList.length > 0) {
                                    Q.notifyError(response.ErrorList.join(',\r\n '));
                                }
                                _this.dialogClose();
                            });
                        },
                    },
                    {
                        text: 'Cancel',
                        click: function () { return _this.dialogClose(); }
                    }
                ];
            };
            ProductExcelImportDialog = __decorate([
                Serenity.Decorators.registerClass()
            ], ProductExcelImportDialog);
            return ProductExcelImportDialog;
        }(Serenity.PropertyDialog));
        BasicSamples.ProductExcelImportDialog = ProductExcelImportDialog;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Product/ProductGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var ProductExcelImportGrid = /** @class */ (function (_super) {
            __extends(ProductExcelImportGrid, _super);
            function ProductExcelImportGrid(container) {
                return _super.call(this, container) || this;
            }
            /**
             * This method is called to get list of buttons to be created.
             */
            ProductExcelImportGrid.prototype.getButtons = function () {
                var _this = this;
                // call base method to get list of buttons
                var buttons = _super.prototype.getButtons.call(this);
                // add our import button
                buttons.push({
                    title: 'Import From Excel',
                    cssClass: 'export-xlsx-button',
                    onClick: function () {
                        // open import dialog, let it handle rest
                        var dialog = new BasicSamples.ProductExcelImportDialog();
                        dialog.element.on('dialogclose', function () {
                            _this.refresh();
                            dialog = null;
                        });
                        dialog.dialogOpen();
                    }
                });
                return buttons;
            };
            ProductExcelImportGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], ProductExcelImportGrid);
            return ProductExcelImportGrid;
        }(Serene3.Northwind.ProductGrid));
        BasicSamples.ProductExcelImportGrid = ProductExcelImportGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Order/OrderGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var QuickFilterCustomization = /** @class */ (function (_super) {
            __extends(QuickFilterCustomization, _super);
            function QuickFilterCustomization(container) {
                return _super.call(this, container) || this;
            }
            QuickFilterCustomization.prototype.getColumnsKey = function () { return "Northwind.Order"; };
            QuickFilterCustomization.prototype.getDialogType = function () { return Serene3.Northwind.OrderDialog; };
            QuickFilterCustomization.prototype.getIdProperty = function () { return Serene3.Northwind.OrderRow.idProperty; };
            QuickFilterCustomization.prototype.getLocalTextPrefix = function () { return Serene3.Northwind.OrderRow.localTextPrefix; };
            QuickFilterCustomization.prototype.getService = function () { return Serene3.Northwind.OrderService.baseUrl; };
            /**
             * This method is called to get list of quick filters to be created for this grid.
             * By default, it returns quick filter objects corresponding to properties that
             * have a [QuickFilter] attribute at server side OrderColumns.cs
             */
            QuickFilterCustomization.prototype.getQuickFilters = function () {
                // get quick filter list from base class, e.g. columns
                var filters = _super.prototype.getQuickFilters.call(this);
                // we start by turning CustomerID filter to a Not Equal one
                var filter = Q.first(filters, function (x) { return x.field == "CustomerID" /* CustomerID */; });
                filter.title = "Customer Not Equal To";
                filter.handler = function (h) {
                    // if filter is active, e.g. editor has some value
                    if (h.active) {
                        h.request.Criteria = Serenity.Criteria.and(h.request.Criteria, [["CustomerID" /* CustomerID */], '!=', h.value]);
                    }
                };
                // turn order date filter to exact match, not a range
                filter = Q.first(filters, function (x) { return x.field == "OrderDate" /* OrderDate */; });
                filter.title = "Order Date Is Exactly";
                // element method in DataGrid turns this into a range editor, clear it to prevent
                filter.element = function (e) { };
                // need to override handler too, otherwise default handler will try to handle a date range
                filter.handler = function (h) {
                    if (h.active) {
                        h.request.EqualityFilter["OrderDate" /* OrderDate */] = h.value;
                    }
                    else {
                        h.request.EqualityFilter["OrderDate" /* OrderDate */] = null;
                    }
                };
                // reset these as they also expect range editors
                filter.loadState = null;
                filter.saveState = null;
                filter.displayText = null;
                // make employee filter a textbox, instead of lookup, and search by starts with
                filter = Q.first(filters, function (x) { return x.field == "EmployeeID" /* EmployeeID */; });
                filter.title = "Employee Name Starts With";
                filter.type = Serenity.StringEditor;
                filter.handler = function (h) {
                    if (h.active) {
                        h.request.Criteria = Serenity.Criteria.and(h.request.Criteria, [["EmployeeFullName" /* EmployeeFullName */], 'like', h.value + '%']);
                    }
                };
                // turn shipping state into a boolean filter
                filter = Q.first(filters, function (x) { return x.field == "ShippingState" /* ShippingState */; });
                filter.title = "Show Only Shipped";
                filter.type = Serenity.BooleanEditor;
                filter.handler = function (h) {
                    h.active = !!h.value;
                    if (h.active) {
                        h.request.Criteria = Serenity.Criteria.and(h.request.Criteria, ['is not null', ["ShippedDate" /* ShippedDate */]]);
                    }
                };
                // ship via filters by NOT IN
                filter = Q.first(filters, function (x) { return x.field == "ShipVia" /* ShipVia */; });
                filter.title = "Ship Via Not IN";
                filter.handler = function (h) {
                    if (h.active) {
                        h.request.Criteria = Serenity.Criteria.and(h.request.Criteria, [["ShipVia" /* ShipVia */], 'not in', [h.value]]);
                    }
                };
                // ship country filters by NOT contains
                filter = Q.first(filters, function (x) { return x.field == "ShipCountry" /* ShipCountry */; });
                filter.title = "Ship Country NOT Contains";
                filter.type = Serenity.StringEditor;
                filter.handler = function (h) {
                    if (h.active) {
                        h.request.Criteria = Serenity.Criteria.and(h.request.Criteria, [["ShipCountry" /* ShipCountry */], 'not like', '%' + h.value + '%']);
                    }
                };
                // ship city filters by GREATER THAN (>)
                filter = Q.first(filters, function (x) { return x.field == "ShipCity" /* ShipCity */; });
                filter.title = "Ship City Greater Than";
                filter.type = Serenity.StringEditor;
                filter.handler = function (h) {
                    if (h.active) {
                        h.request.Criteria = Serenity.Criteria.and(h.request.Criteria, [["ShipCity" /* ShipCity */], '>', h.value]);
                    }
                };
                // create a range editor for freight
                var endFreight = null;
                filters.push({
                    field: "Freight" /* Freight */,
                    type: Serenity.DecimalEditor,
                    title: 'Freight Between',
                    element: function (e1) {
                        e1.css("width", "80px");
                        endFreight = Serenity.Widget.create({
                            type: Serenity.DecimalEditor,
                            element: function (e2) { return e2.insertAfter(e1).css("width", "80px"); }
                        });
                        endFreight.element.change(function (x) { return e1.triggerHandler("change"); });
                        $("<span/>").addClass("range-separator").text("-").insertAfter(e1);
                    },
                    handler: function (h) {
                        var active1 = h.value != null && !isNaN(h.value);
                        var active2 = endFreight.value != null && !isNaN(endFreight.value);
                        h.active = active1 || active2;
                        if (active1)
                            h.request.Criteria = Serenity.Criteria.and(h.request.Criteria, [["Freight" /* Freight */], '>=', h.value]);
                        if (active2)
                            h.request.Criteria = Serenity.Criteria.and(h.request.Criteria, [["Freight" /* Freight */], '<=', endFreight.value]);
                    }
                });
                return filters;
            };
            QuickFilterCustomization = __decorate([
                Serenity.Decorators.registerClass()
            ], QuickFilterCustomization);
            return QuickFilterCustomization;
        }(Serenity.EntityGrid));
        BasicSamples.QuickFilterCustomization = QuickFilterCustomization;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Supplier/SupplierGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var RemovingAddButton = /** @class */ (function (_super) {
            __extends(RemovingAddButton, _super);
            function RemovingAddButton(container) {
                return _super.call(this, container) || this;
            }
            /**
             * This method is called to get list of buttons to be created.
             */
            RemovingAddButton.prototype.getButtons = function () {
                // call base method to get list of buttons
                // by default, base entity grid adds a few buttons, 
                // add, refresh, column selection in order.
                var buttons = _super.prototype.getButtons.call(this);
                // here is several methods to remove add button
                // only one is enabled, others are commented
                // METHOD 1
                // we would be able to simply return an empty button list,
                // but this would also remove all other buttons
                // return [];
                // METHOD 2
                // remove by splicing (something like delete by index)
                // here we hard code add button index (not nice!)
                // buttons.splice(0, 1);
                // METHOD 3 - recommended
                // remove by splicing, but this time find button index
                // by its css class. it is the best and safer method
                buttons.splice(Q.indexOf(buttons, function (x) { return x.cssClass == "add-button"; }), 1);
                return buttons;
            };
            RemovingAddButton = __decorate([
                Serenity.Decorators.registerClass()
            ], RemovingAddButton);
            return RemovingAddButton;
        }(Serene3.Northwind.SupplierGrid));
        BasicSamples.RemovingAddButton = RemovingAddButton;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var CustomerGrossSalesGrid = /** @class */ (function (_super) {
            __extends(CustomerGrossSalesGrid, _super);
            function CustomerGrossSalesGrid(container) {
                var _this = _super.call(this, container) || this;
                _this.nextId = 1;
                return _this;
            }
            CustomerGrossSalesGrid.prototype.getColumnsKey = function () { return "BasicSamples.CustomerGrossSales"; };
            CustomerGrossSalesGrid.prototype.getIdProperty = function () { return "__id"; };
            CustomerGrossSalesGrid.prototype.getNameProperty = function () { return Serene3.Northwind.CustomerGrossSalesRow.nameProperty; };
            CustomerGrossSalesGrid.prototype.getLocalTextPrefix = function () { return Serene3.Northwind.CustomerGrossSalesRow.localTextPrefix; };
            CustomerGrossSalesGrid.prototype.getService = function () { return BasicSamples.CustomerGrossSalesService.baseUrl; };
            /**
             * This method is called to preprocess data returned from the list service
             */
            CustomerGrossSalesGrid.prototype.onViewProcessData = function (response) {
                response = _super.prototype.onViewProcessData.call(this, response);
                // there is no __id property in CustomerGrossSalesRow but 
                // this is javascript and we can set any property of an object
                for (var _i = 0, _a = response.Entities; _i < _a.length; _i++) {
                    var x = _a[_i];
                    x.__id = this.nextId++;
                }
                return response;
            };
            CustomerGrossSalesGrid.prototype.getButtons = function () {
                var _this = this;
                var buttons = [];
                buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                    grid: this,
                    service: BasicSamples.CustomerGrossSalesService.baseUrl + '/ListExcel',
                    onViewSubmit: function () { return _this.onViewSubmit(); },
                    separator: true
                }));
                buttons.push(Serene3.Common.PdfExportHelper.createToolButton({
                    grid: this,
                    onViewSubmit: function () { return _this.onViewSubmit(); }
                }));
                return buttons;
            };
            CustomerGrossSalesGrid.prototype.createSlickGrid = function () {
                var grid = _super.prototype.createSlickGrid.call(this);
                // need to register this plugin for grouping or you'll have errors
                grid.registerPlugin(new Slick.Data.GroupItemMetadataProvider());
                this.view.setSummaryOptions({
                    aggregators: [
                        new Slick.Aggregators.Sum('GrossAmount')
                    ]
                });
                this.view.setGrouping([{
                        getter: 'ContactName'
                    }]);
                return grid;
            };
            CustomerGrossSalesGrid.prototype.getSlickOptions = function () {
                var opt = _super.prototype.getSlickOptions.call(this);
                opt.showFooterRow = true;
                return opt;
            };
            CustomerGrossSalesGrid.prototype.usePager = function () {
                return false;
            };
            CustomerGrossSalesGrid.prototype.getQuickFilters = function () {
                var filters = _super.prototype.getQuickFilters.call(this);
                // we create a date-range quick filter, which is a composite
                // filter with two date time editors
                var orderDate = this.dateRangeQuickFilter('OrderDate', 'Order Date');
                // need to override its handler, as default date-range filter will set Criteria parameter of list request.
                // we need to set StartDate and EndDate custom parameters of our CustomerGrossSalesListRequest
                orderDate.handler = function (args) {
                    // args.widget here is the start date editor. value of a date editor is a ISO date string
                    var start = args.widget.value;
                    // to find end date editor, need to search it by its css class among siblings
                    var end = args.widget.element.nextAll('.s-DateEditor')
                        .getWidget(Serenity.DateEditor).value;
                    args.request.StartDate = start;
                    args.request.EndDate = end;
                    // active option controls when a filter editor looks active, e.g. its label is blueish
                    args.active = !Q.isEmptyOrNull(start) || !Q.isEmptyOrNull(end);
                };
                filters.push(orderDate);
                return filters;
            };
            CustomerGrossSalesGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], CustomerGrossSalesGrid);
            return CustomerGrossSalesGrid;
        }(Serenity.EntityGrid));
        BasicSamples.CustomerGrossSalesGrid = CustomerGrossSalesGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Order/OrderGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var TreeGrid = /** @class */ (function (_super) {
            __extends(TreeGrid, _super);
            function TreeGrid(container) {
                var _this = _super.call(this, container) || this;
                _this.treeMixin = new Serenity.TreeGridMixin({
                    grid: _this,
                    // bring tree items initially collapsed
                    initialCollapse: function () { return true; },
                    // which column to place tree toggle / expand/collapse button
                    toggleField: "CustomerCompanyName" /* CustomerCompanyName */,
                    getParentId: function (x) {
                        // as we don't have parentId column here, we are cheating by using modulus 10 and 50
                        // e.g. order with ID 1605 will have parent 1600, order with ID 1613 will have parent 1610
                        var parentId = Math.floor(x.OrderID / 10) * 10;
                        if (parentId == x.OrderID) {
                            parentId = Math.floor(x.OrderID / 50) * 50;
                            // orders with ID 16050 and 17000 should have NULL parent
                            if (parentId == x.OrderID)
                                return null;
                        }
                        // if you had a ParentID column, you'd just return x.ParentID
                        return parentId;
                    }
                });
                return _this;
            }
            TreeGrid.prototype.usePager = function () {
                return false;
            };
            TreeGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], TreeGrid);
            return TreeGrid;
        }(Serene3.Northwind.OrderGrid));
        BasicSamples.TreeGrid = TreeGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var ViewWithoutIDGrid = /** @class */ (function (_super) {
            __extends(ViewWithoutIDGrid, _super);
            function ViewWithoutIDGrid(container) {
                var _this = _super.call(this, container) || this;
                // this is our autoincrementing counter
                _this.nextId = 1;
                return _this;
            }
            ViewWithoutIDGrid.prototype.getColumnsKey = function () { return "Northwind.SalesByCategory"; };
            ViewWithoutIDGrid.prototype.getIdProperty = function () { return "__id"; };
            ViewWithoutIDGrid.prototype.getNameProperty = function () { return Serene3.Northwind.SalesByCategoryRow.nameProperty; };
            ViewWithoutIDGrid.prototype.getLocalTextPrefix = function () { return Serene3.Northwind.SalesByCategoryRow.localTextPrefix; };
            ViewWithoutIDGrid.prototype.getService = function () { return Serene3.Northwind.SalesByCategoryService.baseUrl; };
            /**
             * This method is called to preprocess data returned from the list service
             */
            ViewWithoutIDGrid.prototype.onViewProcessData = function (response) {
                response = _super.prototype.onViewProcessData.call(this, response);
                // there is no __id property in SalesByCategoryRow but 
                // this is javascript and we can set any property of an object
                for (var _i = 0, _a = response.Entities; _i < _a.length; _i++) {
                    var x = _a[_i];
                    x.__id = this.nextId++;
                }
                return response;
            };
            ViewWithoutIDGrid.prototype.getButtons = function () {
                return [];
            };
            ViewWithoutIDGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], ViewWithoutIDGrid);
            return ViewWithoutIDGrid;
        }(Serenity.EntityGrid));
        BasicSamples.ViewWithoutIDGrid = ViewWithoutIDGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var VSGalleryQAGrid = /** @class */ (function (_super) {
            __extends(VSGalleryQAGrid, _super);
            function VSGalleryQAGrid(container) {
                return _super.call(this, container) || this;
            }
            VSGalleryQAGrid.prototype.getColumnsKey = function () { return "BasicSamples.VSGalleryQA"; };
            VSGalleryQAGrid.prototype.getIdProperty = function () { return "ThreadId"; };
            VSGalleryQAGrid.prototype.getService = function () { return BasicSamples.VSGalleryQAService.baseUrl; };
            VSGalleryQAGrid.prototype.getButtons = function () {
                return [];
            };
            VSGalleryQAGrid.prototype.getSlickOptions = function () {
                var opt = _super.prototype.getSlickOptions.call(this);
                opt.rowHeight = 250;
                return opt;
            };
            VSGalleryQAGrid.prototype.getColumns = function () {
                var columns = _super.prototype.getColumns.call(this);
                Q.first(columns, function (x) { return x.field == 'Posts'; }).format = function (ctx) {
                    var posts = ctx.value;
                    if (!posts || !posts.length)
                        return "";
                    var i = 0;
                    var text = "<ul class='posts'>";
                    for (var _i = 0, posts_1 = posts; _i < posts_1.length; _i++) {
                        var post = posts_1[_i];
                        text += "<li class='" + (i++ % 2 == 0 ? 'even' : 'odd') + "'><h4>";
                        text += post.PostedByName + " - ";
                        text += Q.formatDate(post.PostedOn, 'g');
                        text += "</h4><pre>";
                        text += Q.htmlEncode(post.Message);
                        text += "</pre></li>";
                    }
                    text += "</ul>";
                    return text;
                };
                return columns;
            };
            VSGalleryQAGrid.prototype.getInitialTitle = function () {
                return null;
            };
            VSGalleryQAGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], VSGalleryQAGrid);
            return VSGalleryQAGrid;
        }(Serenity.EntityGrid));
        BasicSamples.VSGalleryQAGrid = VSGalleryQAGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
/// <reference path="../../../Northwind/Order/OrderGrid.ts" />
var Serene3;
(function (Serene3) {
    var BasicSamples;
    (function (BasicSamples) {
        var WrappedHeadersGrid = /** @class */ (function (_super) {
            __extends(WrappedHeadersGrid, _super);
            function WrappedHeadersGrid(container) {
                return _super.call(this, container) || this;
            }
            WrappedHeadersGrid = __decorate([
                Serenity.Decorators.registerClass()
            ], WrappedHeadersGrid);
            return WrappedHeadersGrid;
        }(Serene3.Northwind.OrderGrid));
        BasicSamples.WrappedHeadersGrid = WrappedHeadersGrid;
    })(BasicSamples = Serene3.BasicSamples || (Serene3.BasicSamples = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Membership;
    (function (Membership) {
        var ChangePasswordPanel = /** @class */ (function (_super) {
            __extends(ChangePasswordPanel, _super);
            function ChangePasswordPanel(container) {
                var _this = _super.call(this, container) || this;
                _this.form = new Membership.ChangePasswordForm(_this.idPrefix);
                _this.form.NewPassword.addValidationRule(_this.uniqueName, function (e) {
                    if (_this.form.w('ConfirmPassword', Serenity.PasswordEditor).value.length < 7) {
                        return Q.format(Q.text('Validation.MinRequiredPasswordLength'), 7);
                    }
                });
                _this.form.ConfirmPassword.addValidationRule(_this.uniqueName, function (e) {
                    if (_this.form.ConfirmPassword.value !== _this.form.NewPassword.value) {
                        return Q.text('Validation.PasswordConfirm');
                    }
                });
                _this.byId('SubmitButton').click(function (e) {
                    e.preventDefault();
                    if (!_this.validateForm()) {
                        return;
                    }
                    var request = _this.getSaveEntity();
                    Q.serviceCall({
                        url: Q.resolveUrl('~/Account/ChangePassword'),
                        request: request,
                        onSuccess: function (response) {
                            Q.information(Q.text('Forms.Membership.ChangePassword.Success'), function () {
                                window.location.href = Q.resolveUrl('~/');
                            });
                        }
                    });
                });
                return _this;
            }
            ChangePasswordPanel.prototype.getFormKey = function () { return Membership.ChangePasswordForm.formKey; };
            ChangePasswordPanel = __decorate([
                Serenity.Decorators.registerClass()
            ], ChangePasswordPanel);
            return ChangePasswordPanel;
        }(Serenity.PropertyPanel));
        Membership.ChangePasswordPanel = ChangePasswordPanel;
    })(Membership = Serene3.Membership || (Serene3.Membership = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Membership;
    (function (Membership) {
        var ForgotPasswordPanel = /** @class */ (function (_super) {
            __extends(ForgotPasswordPanel, _super);
            function ForgotPasswordPanel(container) {
                var _this = _super.call(this, container) || this;
                _this.form = new Membership.ForgotPasswordForm(_this.idPrefix);
                _this.byId('SubmitButton').click(function (e) {
                    e.preventDefault();
                    if (!_this.validateForm()) {
                        return;
                    }
                    var request = _this.getSaveEntity();
                    Q.serviceCall({
                        url: Q.resolveUrl('~/Account/ForgotPassword'),
                        request: request,
                        onSuccess: function (response) {
                            Q.information(Q.text('Forms.Membership.ForgotPassword.Success'), function () {
                                window.location.href = Q.resolveUrl('~/');
                            });
                        }
                    });
                });
                return _this;
            }
            ForgotPasswordPanel.prototype.getFormKey = function () { return Membership.ForgotPasswordForm.formKey; };
            ForgotPasswordPanel = __decorate([
                Serenity.Decorators.registerClass()
            ], ForgotPasswordPanel);
            return ForgotPasswordPanel;
        }(Serenity.PropertyPanel));
        Membership.ForgotPasswordPanel = ForgotPasswordPanel;
    })(Membership = Serene3.Membership || (Serene3.Membership = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Membership;
    (function (Membership) {
        var ResetPasswordPanel = /** @class */ (function (_super) {
            __extends(ResetPasswordPanel, _super);
            function ResetPasswordPanel(container) {
                var _this = _super.call(this, container) || this;
                _this.form = new Membership.ResetPasswordForm(_this.idPrefix);
                _this.form.NewPassword.addValidationRule(_this.uniqueName, function (e) {
                    if (_this.form.ConfirmPassword.value.length < 7) {
                        return Q.format(Q.text('Validation.MinRequiredPasswordLength'), 7);
                    }
                });
                _this.form.ConfirmPassword.addValidationRule(_this.uniqueName, function (e) {
                    if (_this.form.ConfirmPassword.value !== _this.form.NewPassword.value) {
                        return Q.text('Validation.PasswordConfirm');
                    }
                });
                _this.byId('SubmitButton').click(function (e) {
                    e.preventDefault();
                    if (!_this.validateForm()) {
                        return;
                    }
                    var request = _this.getSaveEntity();
                    request.Token = _this.byId('Token').val();
                    Q.serviceCall({
                        url: Q.resolveUrl('~/Account/ResetPassword'),
                        request: request,
                        onSuccess: function (response) {
                            Q.information(Q.text('Forms.Membership.ResetPassword.Success'), function () {
                                window.location.href = Q.resolveUrl('~/Account/Login');
                            });
                        }
                    });
                });
                return _this;
            }
            ResetPasswordPanel.prototype.getFormKey = function () { return Membership.ResetPasswordForm.formKey; };
            ResetPasswordPanel = __decorate([
                Serenity.Decorators.registerClass()
            ], ResetPasswordPanel);
            return ResetPasswordPanel;
        }(Serenity.PropertyPanel));
        Membership.ResetPasswordPanel = ResetPasswordPanel;
    })(Membership = Serene3.Membership || (Serene3.Membership = {}));
})(Serene3 || (Serene3 = {}));
var Serene3;
(function (Serene3) {
    var Membership;
    (function (Membership) {
        var SignUpPanel = /** @class */ (function (_super) {
            __extends(SignUpPanel, _super);
            function SignUpPanel(container) {
                var _this = _super.call(this, container) || this;
                _this.form = new Membership.SignUpForm(_this.idPrefix);
                _this.form.ConfirmEmail.addValidationRule(_this.uniqueName, function (e) {
                    if (_this.form.ConfirmEmail.value !== _this.form.Email.value) {
                        return Q.text('Validation.EmailConfirm');
                    }
                });
                _this.form.ConfirmPassword.addValidationRule(_this.uniqueName, function (e) {
                    if (_this.form.ConfirmPassword.value !== _this.form.Password.value) {
                        return Q.text('Validation.PasswordConfirm');
                    }
                });
                _this.byId('SubmitButton').click(function (e) {
                    e.preventDefault();
                    if (!_this.validateForm()) {
                        return;
                    }
                    Q.serviceCall({
                        url: Q.resolveUrl('~/Account/SignUp'),
                        request: {
                            DisplayName: _this.form.DisplayName.value,
                            Email: _this.form.Email.value,
                            Password: _this.form.Password.value
                        },
                        onSuccess: function (response) {
                            Q.information(Q.text('Forms.Membership.SignUp.Success'), function () {
                                window.location.href = Q.resolveUrl('~/');
                            });
                        }
                    });
                });
                return _this;
            }
            SignUpPanel.prototype.getFormKey = function () { return Membership.SignUpForm.formKey; };
            SignUpPanel = __decorate([
                Serenity.Decorators.registerClass()
            ], SignUpPanel);
            return SignUpPanel;
        }(Serenity.PropertyPanel));
        Membership.SignUpPanel = SignUpPanel;
    })(Membership = Serene3.Membership || (Serene3.Membership = {}));
})(Serene3 || (Serene3 = {}));
//# sourceMappingURL=Serene3.Web.js.map