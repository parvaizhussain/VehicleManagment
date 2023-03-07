/**
 *  Modal Example Create App
 */

'use strict';

$(function () {
  // Modal id
  const appModal = document.getElementById('createApp');

  // Credit Card
  const creditCardMask1 = document.querySelector('.app-credit-card-mask'),
    expiryDateMask1 = document.querySelector('.app-expiry-date-mask'),
    cvvMask1 = document.querySelector('.app-cvv-code-mask');
  let cleave;

  // Cleave JS card Mask
  function initCleave() {
    if (creditCardMask1) {
      cleave = new Cleave(creditCardMask1, {
        creditCard: true,
        onCreditCardTypeChanged: function (type) {
          if (type != '' && type != 'unknown') {
            document.querySelector('.app-card-type').innerHTML =
              '<img src="' + assetsPath + 'img/icons/payments/' + type + '-cc.png" class="cc-icon-image" height="28"/>';
          } else {
            document.querySelector('.app-card-type').innerHTML = '';
          }
        }
      });
    }
  }

  // Expiry Date Mask
  if (expiryDateMask1) {
    new Cleave(expiryDateMask1, {
      date: true,
      delimiter: '/',
      datePattern: ['m', 'y']
    });
  }

  // CVV
  if (cvvMask1) {
    new Cleave(cvvMask1, {
      numeral: true,
      numeralPositiveOnly: true
    });
    }
   
  appModal.addEventListener('show.bs.modal', function (event) {
    const wizardCreateApp = document.querySelector('#wizard-create-app');
      if (typeof wizardCreateApp !== undefined && wizardCreateApp !== null) {
      const wizardValidationForm = wizardCreateApp.querySelector('#wizard-form-val');
      const wizardValidationFormStep1 = wizardValidationForm.querySelector('#details');
      const wizardValidationFormStep2 = wizardValidationForm.querySelector('#frameworks');
      const wizardValidationFormStep3 = wizardValidationForm.querySelector('#database');
      // Wizard next prev button
      const wizardCreateAppNextList = [].slice.call(wizardCreateApp.querySelectorAll('.btn-next'));
      const wizardCreateAppPrevList = [].slice.call(wizardCreateApp.querySelectorAll('.btn-prev'));
      const wizardCreateAppBtnSubmit = wizardCreateApp.querySelector('.btn-submit');

      const createAppStepper = new Stepper(wizardCreateApp, {
        linear: true
      });


          // Select Plan
          const FormValidation1 = FormValidation.formValidation(wizardValidationFormStep1, {
              fields: {
                  formValidationPlan: {
                      validators: {
                          notEmpty: {
                              message: 'Please select your preferred plan'
                          }
                      }
                  },
                 
              },
              plugins: {
                  trigger: new FormValidation.plugins.Trigger(),
                  bootstrap5: new FormValidation.plugins.Bootstrap5({
                      // Use this for enabling/changing valid/invalid class
                      // eleInvalidClass: '',
                      eleValidClass: '',
                      rowSelector: '.col-md-6'

                  }),
                  autoFocus: new FormValidation.plugins.AutoFocus(),
                  submitButton: new FormValidation.plugins.SubmitButton()
              },
              init: instance => {
                  instance.on('plugins.message.placed', function (e) {
                      //* Move the error message out of the `input-group` element
                      if (e.element.parentElement.classList.contains('input-group')) {
                          e.element.parentElement.insertAdjacentElement('afterend', e.messageElement);
                      }
                  });
              }
          }).on('core.form.valid', function () {
              // Jump to the next step when all fields in the current step are valid
              createAppStepper.next();
              initCleave();
          });


          // Purpose Details
          const FormValidation2 = FormValidation.formValidation(wizardValidationFormStep2, {
              fields: {
                  purposeReq: {
                      validators: {
                          notEmpty: {
                              message: 'Please Enter purpose of plan'
                          }
                      }
                  },
                  DateRequest: {
                      validators: {
                          notEmpty: {
                              message: 'Please enter date'
                          }
                      }
                  },
                  TimeRequest: {
                      validators: {
                          notEmpty: {
                              message: 'Please select time'
                          }
                      }
                  },
                  travelFromReq: {
                      validators: {
                          notEmpty: {
                              message: 'Please enter travel from'
                          }
                      }
                  },
                  travelToReq: {
                      validators: {
                          notEmpty: {
                              message: 'Please enter travel to'
                          }
                      }
                  },

              },
              plugins: {
                  trigger: new FormValidation.plugins.Trigger(),
                  bootstrap5: new FormValidation.plugins.Bootstrap5({
                      // Use this for enabling/changing valid/invalid class
                      // eleInvalidClass: '',
                      eleValidClass: '',
                      rowSelector: function (field, ele) {
                          switch (field) {
                              case 'DateRequest':
                              case 'TimeRequest':
                                  '.col-md-6'
                              case 'purposeReq':
                              case 'travelFromReq':
                              case 'travelToReq':
                                  '.col-md-12'
                                  
                              default:
                                  return '.row';
                          }
                      }
                  }),
                  autoFocus: new FormValidation.plugins.AutoFocus(),
                  submitButton: new FormValidation.plugins.SubmitButton()
              },
              init: instance => {
                  instance.on('plugins.message.placed', function (e) {
                      //* Move the error message out of the `input-group` element
                      if (e.element.parentElement.classList.contains('input-group')) {
                          e.element.parentElement.insertAdjacentElement('afterend', e.messageElement);
                      }
                  });
              }
          }).on('core.form.valid', function () {
              // Jump to the next step when all fields in the current step are valid
              let checked = $('#basicPlanMain3').is(":checked");
              if (checked) {
                  createAppStepper.to(2);
              }
              createAppStepper.next();
              initCleave();
          });

          // Purpose Details
          const FormValidation3 = FormValidation.formValidation(wizardValidationFormStep3, {
              fields: {
                  travelFromReq: {
                      validators: {
                          notEmpty: {
                              message: 'Please enter travel from'
                          }
                      }
                  },
                  travelToReq: {
                      validators: {
                          notEmpty: {
                              message: 'Please enter travel to'
                          }
                      }
                  },

              },
              plugins: {
                  trigger: new FormValidation.plugins.Trigger(),
                  bootstrap5: new FormValidation.plugins.Bootstrap5({
                      // Use this for enabling/changing valid/invalid class
                      // eleInvalidClass: '',
                      eleValidClass: '',
                      rowSelector: function (field, ele) {
                          switch (field) {
                              case 'travelFromReq':
                              case 'travelToReq':
                                  '.col-md-12'

                              default:
                                  return '.row';
                          }
                      }
                  }),
                  autoFocus: new FormValidation.plugins.AutoFocus(),
                  submitButton: new FormValidation.plugins.SubmitButton()
              },
              init: instance => {
                  instance.on('plugins.message.placed', function (e) {
                      //* Move the error message out of the `input-group` element
                      if (e.element.parentElement.classList.contains('input-group')) {
                          e.element.parentElement.insertAdjacentElement('afterend', e.messageElement);
                      }
                  });
              }
          }).on('core.form.valid', function () {
              // Jump to the next step when all fields in the current step are valid
              let checked = $('#basicPlanMain3').is(":checked");
              if (checked) {
                  createAppStepper.to(4);
              }
              createAppStepper.next();
              initCleave();
          });
   

          if (wizardCreateAppNextList) {
              wizardCreateAppNextList.forEach(item => {
                  item.addEventListener('click', event => {
                      // When click the Next button, we will validate the current step
                      switch (createAppStepper._currentIndex) {
                          case 0:
                             FormValidation1.validate();
                              break;
                          case 1:
                              FormValidation2.validate();
                              break;
                          case 2:
                              FormValidation3.validate();
                              break;
                          default:
                              break;
                      }
                  });
              });
          }
          if (wizardCreateAppPrevList) {
              wizardCreateAppPrevList.forEach(item => {
                  item.addEventListener('click', event => {
                      let checked = $('#basicPlanMain3').is(":checked");
                      switch (createAppStepper._currentIndex) {
                          case 4:
                             
                              if (checked) {
                                  createAppStepper.previous();
                                  createAppStepper.previous();
                              }
                              createAppStepper.previous();
                              break;

                          case 3:
                             
                              if (checked) {
                                  createAppStepper.previous();
                              }
                              createAppStepper.previous();
                              break;
                          case 2:
                              createAppStepper.previous();
                              break;

                          case 1:
                              createAppStepper.previous();
                              break;

                          case 0:

                          default:
                              break;
                      }
                  });
              });
          }

          if (wizardCreateAppBtnSubmit) {
              wizardCreateAppBtnSubmit.addEventListener('click', event => {
                  let checked = $('#basicPlanMain3').is(":checked");
                  let chkLuggage = $('#chkLuggage').is(":checked");
                  if (checked) {
                      var VRObj = {
                          EmployeeID: 0,
                          EmployeeContact: "0212122",
                          RegionID: 3,
                          Purpose: $('#purposeReq').val(),
                          RequestDate: moment($('#DateRequest').val(), "DD-MMM-YYYY").format("YYYY-MM-DD"), //flatpickr.formatDate(new Date($('#DateRequest').val(), "Y-m-d")), 
                          RequestTime: $('#TimeRequest').val(),
                          RequestEndTime: $('#TimeRequestEnd').val(),
                          Status: 0,
                          //Remarks: "string",
                          HodApproval: false,
                          IsAirport: "No",
                          RequestType: "Professional",
                          //FlightNo: "string",
                          //TicketNo: "string",
                          //TicketPDF: "string",
                          NoOfPassanger: $('#NoofPassenger').val(), 
                          IsLuggage: chkLuggage,
                          PickFrom: $('#travelFromReq').val(),
                          PickTo: $('#travelToReq').val(),
                          //DropFrom: "string",
                          //DropTo : "string"

                      }
                      console.log(VRObj);

                      $.ajax({

                          type: 'POST',
                          async: false,
                          data: { Obj: VRObj },
                          url: '/VehicleUserRequest/Upsert',

                          success: function (result) {
                              if (result.datasuccess == true) {


                                  Command: toastr["success"]("Vehicle Request has been Successfully sent to HOD. Please wait for approval!");
                                  var mydata = result.json;// $('#UserDataJson').val();
                                  var newdata = JSON.parse(mydata);

                                  LoadTable(newdata);
                                  $('.companylist').val(0).trigger('change');;
                                  $('#btnCancelSave').click();
                              }
                          },
                          complete: function (result) {

                          },
                          error: function (err) {

                              console.log("error" + JSON.stringify(err));
                          }
                      });
                  }
              });
          }
    }
  });
});
