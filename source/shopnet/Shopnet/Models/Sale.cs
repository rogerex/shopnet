//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace Shopnet.Models
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Customer))]
    [KnownType(typeof(Payment))]
    [KnownType(typeof(TypePayment))]
    [KnownType(typeof(User))]
    [KnownType(typeof(DetailSale))]
    public partial class Sale: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int SaleID
        {
            get { return _saleID; }
            set
            {
                if (_saleID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'SaleID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _saleID = value;
                    OnPropertyChanged("SaleID");
                }
            }
        }
        private int _saleID;
    
        [DataMember]
        public int CustomerID
        {
            get { return _customerID; }
            set
            {
                if (_customerID != value)
                {
                    ChangeTracker.RecordOriginalValue("CustomerID", _customerID);
                    if (!IsDeserializing)
                    {
                        if (Customer != null && Customer.CustomerID != value)
                        {
                            Customer = null;
                        }
                    }
                    _customerID = value;
                    OnPropertyChanged("CustomerID");
                }
            }
        }
        private int _customerID;
    
        [DataMember]
        public int TypePaymentID
        {
            get { return _typePaymentID; }
            set
            {
                if (_typePaymentID != value)
                {
                    ChangeTracker.RecordOriginalValue("TypePaymentID", _typePaymentID);
                    if (!IsDeserializing)
                    {
                        if (TypePayment != null && TypePayment.TypePaymentID != value)
                        {
                            TypePayment = null;
                        }
                    }
                    _typePaymentID = value;
                    OnPropertyChanged("TypePaymentID");
                }
            }
        }
        private int _typePaymentID;
    
        [DataMember]
        public int UserID
        {
            get { return _userID; }
            set
            {
                if (_userID != value)
                {
                    ChangeTracker.RecordOriginalValue("UserID", _userID);
                    if (!IsDeserializing)
                    {
                        if (User != null && User.UserID != value)
                        {
                            User = null;
                        }
                    }
                    _userID = value;
                    OnPropertyChanged("UserID");
                }
            }
        }
        private int _userID;
    
        [DataMember]
        public System.DateTime Creation
        {
            get { return _creation; }
            set
            {
                if (_creation != value)
                {
                    _creation = value;
                    OnPropertyChanged("Creation");
                }
            }
        }
        private System.DateTime _creation;
    
        [DataMember]
        public decimal Total
        {
            get { return _total; }
            set
            {
                if (_total != value)
                {
                    _total = value;
                    OnPropertyChanged("Total");
                }
            }
        }
        private decimal _total;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public Customer Customer
        {
            get { return _customer; }
            set
            {
                if (!ReferenceEquals(_customer, value))
                {
                    var previousValue = _customer;
                    _customer = value;
                    FixupCustomer(previousValue);
                    OnNavigationPropertyChanged("Customer");
                }
            }
        }
        private Customer _customer;
    
        [DataMember]
        public TrackableCollection<Payment> Payments
        {
            get
            {
                if (_payments == null)
                {
                    _payments = new TrackableCollection<Payment>();
                    _payments.CollectionChanged += FixupPayments;
                }
                return _payments;
            }
            set
            {
                if (!ReferenceEquals(_payments, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_payments != null)
                    {
                        _payments.CollectionChanged -= FixupPayments;
                        // This is the principal end in an association that performs cascade deletes.
                        // Remove the cascade delete event handler for any entities in the current collection.
                        foreach (Payment item in _payments)
                        {
                            ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                        }
                    }
                    _payments = value;
                    if (_payments != null)
                    {
                        _payments.CollectionChanged += FixupPayments;
                        // This is the principal end in an association that performs cascade deletes.
                        // Add the cascade delete event handler for any entities that are already in the new collection.
                        foreach (Payment item in _payments)
                        {
                            ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                        }
                    }
                    OnNavigationPropertyChanged("Payments");
                }
            }
        }
        private TrackableCollection<Payment> _payments;
    
        [DataMember]
        public TypePayment TypePayment
        {
            get { return _typePayment; }
            set
            {
                if (!ReferenceEquals(_typePayment, value))
                {
                    var previousValue = _typePayment;
                    _typePayment = value;
                    FixupTypePayment(previousValue);
                    OnNavigationPropertyChanged("TypePayment");
                }
            }
        }
        private TypePayment _typePayment;
    
        [DataMember]
        public User User
        {
            get { return _user; }
            set
            {
                if (!ReferenceEquals(_user, value))
                {
                    var previousValue = _user;
                    _user = value;
                    FixupUser(previousValue);
                    OnNavigationPropertyChanged("User");
                }
            }
        }
        private User _user;
    
        [DataMember]
        public TrackableCollection<DetailSale> Details
        {
            get
            {
                if (_details == null)
                {
                    _details = new TrackableCollection<DetailSale>();
                    _details.CollectionChanged += FixupDetails;
                }
                return _details;
            }
            set
            {
                if (!ReferenceEquals(_details, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_details != null)
                    {
                        _details.CollectionChanged -= FixupDetails;
                        // This is the principal end in an association that performs cascade deletes.
                        // Remove the cascade delete event handler for any entities in the current collection.
                        foreach (DetailSale item in _details)
                        {
                            ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                        }
                    }
                    _details = value;
                    if (_details != null)
                    {
                        _details.CollectionChanged += FixupDetails;
                        // This is the principal end in an association that performs cascade deletes.
                        // Add the cascade delete event handler for any entities that are already in the new collection.
                        foreach (DetailSale item in _details)
                        {
                            ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                        }
                    }
                    OnNavigationPropertyChanged("Details");
                }
            }
        }
        private TrackableCollection<DetailSale> _details;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            Customer = null;
            Payments.Clear();
            TypePayment = null;
            User = null;
            Details.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupCustomer(Customer previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Sales.Contains(this))
            {
                previousValue.Sales.Remove(this);
            }
    
            if (Customer != null)
            {
                if (!Customer.Sales.Contains(this))
                {
                    Customer.Sales.Add(this);
                }
    
                CustomerID = Customer.CustomerID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Customer")
                    && (ChangeTracker.OriginalValues["Customer"] == Customer))
                {
                    ChangeTracker.OriginalValues.Remove("Customer");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Customer", previousValue);
                }
                if (Customer != null && !Customer.ChangeTracker.ChangeTrackingEnabled)
                {
                    Customer.StartTracking();
                }
            }
        }
    
        private void FixupTypePayment(TypePayment previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Sales.Contains(this))
            {
                previousValue.Sales.Remove(this);
            }
    
            if (TypePayment != null)
            {
                if (!TypePayment.Sales.Contains(this))
                {
                    TypePayment.Sales.Add(this);
                }
    
                TypePaymentID = TypePayment.TypePaymentID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("TypePayment")
                    && (ChangeTracker.OriginalValues["TypePayment"] == TypePayment))
                {
                    ChangeTracker.OriginalValues.Remove("TypePayment");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("TypePayment", previousValue);
                }
                if (TypePayment != null && !TypePayment.ChangeTracker.ChangeTrackingEnabled)
                {
                    TypePayment.StartTracking();
                }
            }
        }
    
        private void FixupUser(User previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Sales.Contains(this))
            {
                previousValue.Sales.Remove(this);
            }
    
            if (User != null)
            {
                if (!User.Sales.Contains(this))
                {
                    User.Sales.Add(this);
                }
    
                UserID = User.UserID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("User")
                    && (ChangeTracker.OriginalValues["User"] == User))
                {
                    ChangeTracker.OriginalValues.Remove("User");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("User", previousValue);
                }
                if (User != null && !User.ChangeTracker.ChangeTrackingEnabled)
                {
                    User.StartTracking();
                }
            }
        }
    
        private void FixupPayments(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Payment item in e.NewItems)
                {
                    item.Sale = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Payments", item);
                    }
                    // This is the principal end in an association that performs cascade deletes.
                    // Update the event listener to refer to the new dependent.
                    ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Payment item in e.OldItems)
                {
                    if (ReferenceEquals(item.Sale, this))
                    {
                        item.Sale = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Payments", item);
                    }
                    // This is the principal end in an association that performs cascade deletes.
                    // Remove the previous dependent from the event listener.
                    ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                }
            }
        }
    
        private void FixupDetails(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (DetailSale item in e.NewItems)
                {
                    item.Sale = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Details", item);
                    }
                    // This is the principal end in an association that performs cascade deletes.
                    // Update the event listener to refer to the new dependent.
                    ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (DetailSale item in e.OldItems)
                {
                    if (ReferenceEquals(item.Sale, this))
                    {
                        item.Sale = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Details", item);
                        // Delete the dependent end of this identifying association. If the current state is Added,
                        // allow the relationship to be changed without causing the dependent to be deleted.
                        if (item.ChangeTracker.State != ObjectState.Added)
                        {
                            item.MarkAsDeleted();
                        }
                    }
                    // This is the principal end in an association that performs cascade deletes.
                    // Remove the previous dependent from the event listener.
                    ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                }
            }
        }

        #endregion
    }
}
