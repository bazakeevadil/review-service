import React from 'react'
import { useParams } from 'react-router'
import { useDispatch, useSelector } from 'react-redux'
import { addPost } from '../redux/action'

const Reviews = () => {
    const { id } = useParams()
    const dispatch = useDispatch()
    const courses = useSelector(state => state.courses)
    const handleKeyDown = (e) => {
        if(e.key === "Enter"){
            e.target.value = ''
        //        dispatch(addPost(e.target.value)) 
        }
    }
    const img = ['https://i.pinimg.com/564x/ec/87/b6/ec87b60354654716445332f85ae73796.jpg','https://i.pinimg.com/564x/86/ad/01/86ad01aac334ed269e9d33dab95a2217.jpg','https://i.pinimg.com/564x/af/1f/b4/af1fb4e8700c6aa2c5b8d3e915eb6e99.jpg','https://i.pinimg.com/564x/0e/4f/dc/0e4fdce8ac22e09688c580e5bc4dcd7d.jpg','https://i.pinimg.com/564x/34/01/ee/3401ee2dbb27776d850e77c6a2bee3d2.jpg']
console.log(id);
    return (
        <div>
            <div className="comments">
                <div className="container">
                    <div className='comments__box'>
                        <div className='comments__leftSide'>
                        <p className="comments__title">
                            {/* {courses[id].name} */}
                        </p>
                        <div className="comments__img">
                            <img src={img[id-1]} alt="" />
                        </div>
                        </div>
                        <div className="addition">

                            <div className="addition__wrapper">
                                <p className="addition__title">
                                    Добавить новый отзыв
                                </p>

                                <textarea className="addition__form" name="" id="" rows="10" onKeyDown={handleKeyDown}></textarea>
                                <button className="addition__btn"> Опубликовать</button>
                            </div>

                        </div>
                    </div>
                    <div className="comments__wrapper">
                     
                        <div className="comments__card">
                            <div className="comments__text">
                                Lorem, ipsum dolor sit amet consectetur adipisicing elit. Consectetur repellat eos recusandae beatae cumque laudantium, distinctio sunt? Sed eligendi asperiores sint mollitia, necessitatibus aliquam nulla possimus commodi, eaque non voluptas?
                            </div>
                            <p className="comments__user">
                                kikiki lololo
                            </p>
                            <p className="comments__date">12.12.1212</p>
                            <p className="comments__rating">
                                ✭✭✭
                            </p>
                        </div>
                        <div className="comments__card">
                            <div className="comments__text">
                                Lorem, ipsum dolor sit amet consectetur adipisicing elit. Consectetur repellat eos recusandae beatae cumque laudantium, distinctio sunt? Sed eligendi asperiores sint mollitia, necessitatibus aliquam nulla possimus commodi, eaque non voluptas?
                            </div>
                            <p className="comments__user">
                                kikiki lololo
                            </p>
                            <p className="comments__date">12.12.1212</p>
                            <p className="comments__rating">
                                ✭✭✭
                            </p>
                        </div>
                        <div className="comments__card">
                            <div className="comments__text">
                                Lorem, ipsum dolor sit amet consectetur adipisicing elit. Consectetur repellat eos recusandae beatae cumque laudantium, distinctio sunt? Sed eligendi asperiores sint mollitia, necessitatibus aliquam nulla possimus commodi, eaque non voluptas?
                            </div>
                            <p className="comments__user">
                                kikiki lololo
                            </p>
                            <p className="comments__date">12.12.1212</p>
                            <p className="comments__rating">
                                ✭✭✭
                            </p>
                        </div>
                    </div>
                </div>
            </div>


        </div>
    )
}

export default Reviews