import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Testimonial',
  templateUrl: './Testimonial.component.html',
  styleUrls: ['./Testimonial.component.css']
})
export class TestimonialComponent implements OnInit {

  
  testimonials:object[] = []
  testimonial:string=  `خدمة العملاء هو نشاط ارادي الذي يشرح الرغبة الواضحة لرضاء، ان لم يكن لاسعاد، عميل.” استيف كورتين – متخصص العملاء، موظف في ماريوت انترناشونالأن تكون على قدم المساواة من حيث السعر والجودةفوظيفتك ستكون خدمة`
  userImage:string= "https://images.unsplash.com/photo-1494790108377-be9c29b29330?ixlib=rb-0.3.5&q=80&fm=jpg&crop=entropy&cs=tinysrgb&w=200&fit=max&s=707b9c33066bf8808c934c8ab394dff6" 
  username:string=  "هدي محمد"
  rate:any = 4
  idx:number = 1
  info:any = {}
  stars:any  
  updateTestimonial() {
      this.info = this.testimonials[this.idx]
      this.testimonial = this.info.text
      this.userImage = this.info.photo
      this.username = this.info.name
      this.rate = this.info.rating
    
      this.idx++
    
      if (this.idx > this.testimonials.length - 1) {
        this.idx = 0
      }
    }
  
  setIntervalConst: ReturnType<typeof setInterval> = setInterval(() => {
    this.updateTestimonial()
    
  }, 5000)

  constructor(){
    this.stars = Array(5).fill(0).map((x,i)=>i);
  }
  ngOnInit() {

    // Testimonials Data
    this.testimonials = [
      {
        name: 'مي عماد',
        rating: 4,
        photo: 'https://randomuser.me/api/portraits/women/44.jpg',
        text:
          'ليس صاحب العمل هو من يدفع المرتبات. صاحب العمل يدير فقط الأموال. العميل هو من يدفع المرتبات.” هنري العميل هو من يدفع المرتبات. فورد – مؤسس شركة فورد موتورز',
      },
      {
        name: 'سامية عوف',
        rating: 3,
        photo: 'https://randomuser.me/api/portraits/women/68.jpg',
        text:
          "ناك مدير واحد فقط: العميل. ويمكنه طرد كل شخص في الشركة بداية من المدير ومن تحته، ببساطة عن طريق انفاق امواله في مكان اخر.” سام والتون – مؤسس والمارت وسامس كلوبناك مدير واحد فقط: العميل. ويمكنه طرد كل شخص في الشركة بداية " ,
      },
      {
        name: 'سعاد محمود',
        rating: 4,
        photo: 'https://randomuser.me/api/portraits/women/65.jpg',
        text:
          "لأصل الأعظم لكل شركة هو عملائها لأنه بدون عملاء لا يوجد شركة.” مايكل لوبوف – مؤلف أعمال وأستاذ إدارة سابق في جامعة نيو أورلينز.” مايكل لوبوف – مؤلف أعمال وأستاذ إدارة ",
      },
      {
        name: 'عمر أحمد',
        rating: 3,
        photo: 'https://randomuser.me/api/portraits/men/43.jpg',
        text:
          "العملاء الراضين والمهتم بهم بشكل جيد يمكن ان يكونوا أفضل سفراء للعلامة التجارية. من الناحية الاخرى، العملاء المهملين يمكنهم بسهولة تدمير سمعة العلامة التجارية والتسبب في خسائر مالية. اقتباسات خدمة العملاء المذكورة ادناه تشرح بوضوح لماذا من الضروري ان نهتم بالعملاء ونعاملهم بشكل صحيح.",
      },
      {
        name: 'سوسو سامي',
        rating: 3,
        photo:
          'https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?h=350&auto=compress&cs=tinysrgb',
        text:
          'اي عميل يرحل، غير محترم ومهزوم، يمثل عشرات الالاف من الدولارات خارج الباب، بالاضافة الى فشل الوعد الذي قدمته العلامة التجارية في البداية. لا يمكنك مشاهدة ذلك ولكنه يحدث بشكل يومي.” سيث جودين – مؤلف ومدير تنفيذي سابق في شركة دوت كوم',
      },
      {
        name: 'شوقي عبدالرحمن',
        rating: 4,
        photo: 'https://randomuser.me/api/portraits/men/97.jpg',
        text:
          'ستجعل المعاملة اللطيفة من العميل إعلانًا متحركًا “. جيمس كاش – أكاديمي في مجال الأعمال وعضو في مجلس إدارة العديد من الشركات ، بما في ذلك جنرال إلكتريك ومايكروسوفت وشركة تشاب وشركة فيز فوروارد وشركة وول مارت وفيراكود',
      },
    ]
    this.setIntervalConst

  }
 

}
